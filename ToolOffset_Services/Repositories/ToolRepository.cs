using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Tools;
using ToolOffset_Services.Interfaces;

namespace ToolOffset_Services.Repositories
{
    public class ToolRepository : IToolRepository
    {
        private XDocument _document;
        private string _path;

        public void Add(Tool item)
        {
            LoadXml();

            var result = (from tool in _document.Element("Tools").Elements("Tool")
                          where Convert.ToInt32(tool.Attribute("ID").Value) == item.ToolNo
                          select tool).FirstOrDefault();

            if (result != null)
                throw new Exception("ID already in use");

            _document.Element("Tools").Add(ConvertToXElement(item));

            var orderedResult = from el in _document.Element("Tools").Elements("Tool")
                                orderby Convert.ToInt32(el.Attribute("ID").Value)
                                select el;

            _document.Element("Tools").ReplaceAll(orderedResult);

            _document.Save(_path);
        }

        public void Delete(int id)
        {
            LoadXml();

            _document.Element("Tools").Elements("Tool")
                .Where(a => Convert.ToInt32(a.Attribute("ID").Value) == id)
                .Remove();

            _document.Save(_path);
        }

        public Tool Get(int id)
        {
            LoadXml();

            return (from elem in _document.Element("Tools").Elements("Tool")
                    where Convert.ToInt32(elem.Attribute("ID").Value) == id
                    select (ConvertToTool(elem))).FirstOrDefault();
        }

        public IEnumerable<Tool> GetAll()
        {
            LoadXml();

            return (from tool in _document.Element("Tools").Elements("Tool")
                         select (ConvertToTool(tool))).ToList();
        }

        public void Update(Tool item)
        {
            LoadXml();

            var result = (from tool in _document.Element("Tools").Elements("Tool")
                          where Convert.ToInt32(tool.Attribute("ID").Value) == item.ToolNo
                          select tool).FirstOrDefault();

            if (result == null)
                throw new Exception("Id not found");

            var xElementTool = ConvertToXElement(item);

            result.ReplaceWith(xElementTool);

            _document.Save(_path);
        }

        public ToolRepository()
        {
            _document = new XDocument();

            if (Properties.Settings.Default.ToolXMLPath == "")
                InitializePath();

            _path = Properties.Settings.Default.ToolXMLPath;
            LoadXml();
        }

        private XElement ConvertToXElement(Tool tool)
        {
            return new XElement("Tool", new XAttribute("ID", tool.ToolNo),
                new XElement("Name", tool.Name),
                new XElement("Comment", tool.Comment),
                new XElement("ToolType", (int)tool.ToolType),
                new XElement("Default", tool.ToolOffsetDefault),
                new XElement("Quantity", tool.Quantity),
                new XElement("ToolOffsets",
                                from offset in tool.ToolOffsets
                                select (new XElement("ToolOffset", new XAttribute("ID", offset.ID),
                                    new XElement("Name", offset.Name),
                                    new XElement("Length", offset.Length),
                                    new XElement("Width", offset.Width),
                                    new XElement("XRadiusOffset", offset.XRadiusOffset),
                                    new XElement("ZRadiusOffset", offset.ZRadiusOffset),
                                    new XElement("RadiusCompPattern", (int)offset.RadiusCompPattern)))));
        }

        private Tool ConvertToTool(XElement toolElement)
        {
            return new Tool(
                Convert.ToInt32(toolElement.Attribute("ID").Value),
                toolElement.Element("Name").Value,
                toolElement.Element("Comment").Value,
                (ToolType)Convert.ToInt32(toolElement.Element("ToolType").Value),
                new List<ToolOffset>(from xElement in toolElement.Element("ToolOffsets").Elements("ToolOffset")
                                     select new ToolOffset(
                                         Convert.ToInt32(xElement.Attribute("ID").Value),
                                         xElement.Element("Name").Value,
                                         Convert.ToDouble(xElement.Element("Length").Value),
                                         Convert.ToDouble(xElement.Element("Width").Value),
                                         Convert.ToDouble(xElement.Element("XRadiusOffset").Value),
                                         Convert.ToDouble(xElement.Element("ZRadiusOffset").Value),
                                         (RadiusCompPattern)Convert.ToInt32(xElement.Element("RadiusCompPattern").Value))).ToList(),
                Convert.ToInt32(toolElement.Element("Default").Value),
                Convert.ToInt32(toolElement.Element("Quantity").Value));
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
    }
}
