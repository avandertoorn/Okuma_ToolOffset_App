using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models;
using ToolOffset_Models.Models.Tools;
using ToolOffset_Services.Interfaces;

namespace ToolOffset_Services.Repositories
{
    public class ToolRepository : IToolRepository
    {
        private XDocument _document;
        private string _path;

        private List<Tool> _tools;

        public void Add(Tool item)
        {
            var result = (from tool in _document.Element("Tools").Elements("Tool")
                          where Convert.ToInt32(tool.Attribute("ID").Value) == item.ToolNo
                          select tool).FirstOrDefault();

            if (result != null)
                throw new Exception("ID already in use");

            _document.Element("Tools").Add(ConvertToolToXElement(item));

            var orderedResult = from el in _document.Element("Tools").Elements("Tool")
                                orderby Convert.ToInt32(el.Attribute("ID").Value)
                                select el;

            _document.Element("Tools").ReplaceAll(orderedResult);

            ToolListCheck();
            _document.Save(_path);
        }

        public void Delete(int id)
        {
            _document.Element("Tools").Elements("Tool")
                .Where(a => Convert.ToInt32(a.Attribute("ID").Value) == id)
                .Remove();

            _document.Save(_path);

            ToolListCheck();
            _tools.RemoveAll(a => a.ToolNo == id);
        }

        public Tool Get(int id)
        {
            ToolListCheck();
            return _tools.FirstOrDefault(a => a.ToolNo == id);
        }

        public IEnumerable<Tool> GetAll()
        {
            ToolListCheck();
            return _tools;
        }

        public void Update(Tool item, int originalId)
        {
            var originalXelement = (from tool in _document.Element("Tools").Elements("Tool")
                                    where Convert.ToInt32(tool.Attribute("ID").Value) == originalId
                                    select tool).FirstOrDefault();

            if (originalXelement == null)
                throw new Exception("Id not found");

            var newXelement = ConvertToolToXElement(item);

            originalXelement.ReplaceWith(newXelement);

            _document.Save(_path);
        }

        public ToolRepository()
        {
            _document = new XDocument();

            if (Properties.Settings.Default.ToolXMLPath == "")
                InitializePath();

            _path = Properties.Settings.Default.ToolXMLPath;
            LoadXml();
            _tools = new List<Tool>(GetAllFromXml());
        }

        private XElement ConvertToolToXElement(Tool tool)
        {
            return new XElement("Tool", new XAttribute("ID", tool.ToolNo),
                        new XElement("Name", tool.Name),
                        new XElement("Comment", tool.Comment),
                        new XElement("ToolType", (int)tool.ToolType),
                        new XElement("Default", tool.ToolOffsetDefault),
                        new XElement("Quantity", tool.Quantity),
                        new XElement("ToolToolOffsets",
                                from offset in tool.ToolOffsets
                                select ConvertToolOffsetToXElement(offset)));
        }

        private XElement ConvertToolOffsetToXElement(ToolOffset toolOffset)
        {
            return new XElement("ToolOffset", new XAttribute("ID", toolOffset.ID),
                        new XElement("Name", toolOffset.Name),
                        new XElement("Length", toolOffset.Length),
                        new XElement("Width", toolOffset.Width),
                        new XElement("XRadiusOffset", toolOffset.XRadiusOffset),
                        new XElement("ZRadiusOffset", toolOffset.ZRadiusOffset),
                        new XElement("RadiusCompPattern", (int)toolOffset.RadiusCompPattern));
        }

        private Tool ConvertToTool(XElement toolElement)
        {
            return new Tool(
                Convert.ToInt32(toolElement.Attribute("ID").Value),
                toolElement.Element("Name").Value,
                toolElement.Element("Comment").Value,
                (ToolType)Convert.ToInt32(toolElement.Element("ToolType").Value),
                new List<ToolOffset>(from xElement in toolElement.Element("ToolToolOffsets").Elements("ToolOffset")
                                     select ConvertToToolOffset(xElement)),
                Convert.ToInt32(toolElement.Element("Default").Value),
                Convert.ToInt32(toolElement.Element("Quantity").Value));
        }

        private ToolOffset ConvertToToolOffset(XElement toolOffsetElement)
        {

            return new ToolOffset(
                Convert.ToInt32(toolOffsetElement.Attribute("ID").Value),
                toolOffsetElement.Element("Name").Value,
                Convert.ToDouble(toolOffsetElement.Element("Length").Value),
                Convert.ToDouble(toolOffsetElement.Element("Width").Value),
                Convert.ToDouble(toolOffsetElement.Element("XRadiusOffset").Value),
                Convert.ToDouble(toolOffsetElement.Element("ZRadiusOffset").Value),
                (RadiusCompPattern)Convert.ToInt32(toolOffsetElement.Element("RadiusCompPattern").Value));
        }

        private void InitializePath()
        {
            var path = Directory.GetCurrentDirectory();
            path += @"\Tools.xml";
            Properties.Settings.Default.ToolXMLPath = path;
            Properties.Settings.Default.Save();
        }

        private void LoadXml()
        {
            if (!File.Exists(_path))
                CreateXml();

            _document = XDocument.Load(_path);
        }

        private void CreateXml()
        {
            _document = new XDocument(
                new XDeclaration("1.0", "utf-8", "true"),
                new XComment("Tool Models"),
                new XElement("Tools"));

            _document.Save(_path);
        }

        private IEnumerable<Tool> GetAllFromXml()
        {
            return _document.Element("Tools").Elements("Tool").Select(
                a => ConvertToTool(a));
        }

        private void ToolListCheck()
        {
            if (_tools == null)
            {
                LoadXml();
                _tools = new List<Tool>(GetAllFromXml());
            }
        }
    }
}
