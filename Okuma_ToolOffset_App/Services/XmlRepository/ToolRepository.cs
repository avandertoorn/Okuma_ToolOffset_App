using Okuma_ToolOffset_App.Models.AppModels;
using Okuma_ToolOffset_App.Models.AppModels.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Okuma_ToolOffset_App.Services.XmlRepository
{
    public class ToolRepository : IRepository<Tool>
    {
        private XDocument _doc;
        private string _path;

        public ToolRepository()
        {
            if (Properties.Settings.Default.ToolsXMLPath == "")
            {
                string path = Directory.GetCurrentDirectory();
                path = path + @"\Tools.xml";
                Properties.Settings.Default.ToolsXMLPath = path;
            }

            _path = Properties.Settings.Default.ToolsXMLPath;

            if (!File.Exists((Properties.Settings.Default.ToolsXMLPath)))
                CreateXml();

            _doc = XDocument.Load(Properties.Settings.Default.ToolsXMLPath);
        }

        public IEnumerable<Tool> GetAll()
        {
            IEnumerable<Tool> tools
                = (from _tool in _doc.Element("Tools").Elements("Tool")
                   select new Tool
                   {
                       ToolNo = Convert.ToInt32(_tool.Attribute("ID").Value),
                       Name = _tool.Element("Name").Value,
                       Comment = _tool.Element("Comment").Value,
                       Length = Convert.ToDouble(_tool.Element("Length").Value),
                       Width = Convert.ToDouble(_tool.Element("Width").Value),
                       XRadiusOffset = Convert.ToDouble(_tool.Element("XRadiusOffset").Value),
                       ZRadiusOffset = Convert.ToDouble(_tool.Element("ZRadiusOffset").Value),
                       RadiusCompPattern = Convert.ToInt32(_tool.Element("RadiusCompPattern").Value),
                       ToolType = (ToolTypeEnum)Convert.ToInt32(_tool.Element("ToolType").Value)

                   });
            return tools;
        }

        public Tool GetByID(int ID)
        {
            XElement data
                = _doc.Element("Tools").Elements("Tool")
                .Where(a => Convert.ToInt32(a.Attribute("ID").Value) == ID)
                .FirstOrDefault();

            if (data != null)
            {
                Tool tool = new Tool
                {
                    ToolNo = Convert.ToInt32(data.Attribute("ID").Value),
                    Name = data.Element("Name").Value,
                    Comment = data.Element("Comment").Value,
                    Length = Convert.ToDouble(data.Element("Length").Value),
                    Width = Convert.ToDouble(data.Element("Width").Value),
                    XRadiusOffset = Convert.ToDouble(data.Element("XRadiusOffset").Value),
                    ZRadiusOffset = Convert.ToDouble(data.Element("ZRadiusOffset").Value),
                    RadiusCompPattern = Convert.ToInt32(data.Element("RadiusCompPattern").Value),
                    ToolType = (ToolTypeEnum)Convert.ToInt32(data.Element("ToolType").Value)

                };
                return tool;
            }

            else
                throw new Exception("ID not found");

        }

        public void Insert(Tool item)
        {
            XElement result = _doc.Element("Tools").Elements("Tool")
                .Where(a => Convert.ToInt32(a.Attribute("ID").Value) == item.ToolNo)
                .FirstOrDefault();

            if (result == null)
            {
                _doc.Element("Tools").Add(
                new XElement("Tool", new XAttribute("ID", item.ToolNo),
                    new XElement("Name", item.Name),
                    new XElement("Comment", item.Comment),
                    new XElement("Length", item.Length),
                    new XElement("Width", item.Width),
                    new XElement("XRadiusOffset", item.XRadiusOffset),
                    new XElement("ZRadiusOffset", item.ZRadiusOffset),
                    new XElement("RadiusCompPattern", item.RadiusCompPattern),
                    new XElement("ToolType", (int)item.ToolType)));

                IOrderedEnumerable<XElement> results = from XElement el in _doc.Element("Tools").Elements("Tool")
                                                       orderby Convert.ToInt32(el.Attribute("ID").Value)
                                                       select el;

                _doc.Element("Tools").ReplaceAll(results.ToArray());
                _doc.Save(_path);
            }
            else
                throw new Exception("ID already used");
        }

        public void Update(Tool item)
        {
            XElement tool = _doc.Element("Tools").Elements("Tool")
                .Where(a => Convert.ToInt32(a.Attribute("ID").Value) == item.ToolNo)
                .FirstOrDefault();

            if (tool != null)
            {
                tool.SetElementValue("Name", item.Name);
                tool.SetElementValue("Comment", item.Comment);
                tool.SetElementValue("Length", item.Length);
                tool.SetElementValue("Width", item.Width);
                tool.SetElementValue("XRadiusOffset", item.XRadiusOffset);
                tool.SetElementValue("ZRadiusOffset", item.ZRadiusOffset);
                tool.SetElementValue("RadiusCompPattern", item.RadiusCompPattern);
                tool.SetElementValue("ToolType", (int)item.ToolType);
                _doc.Save(_path);
            }
            else
                throw new Exception("ID not found");
        }

        public void Delete(int ID)
        {
            _doc.Element("Tools").Elements("Tool")
                .Where(a => Convert.ToInt32(a.Attribute("ID").Value) == ID)
                .Remove();
            _doc.Save(_path);
        }

        private void CreateXml()
        {
            _doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "true"),
                new XComment("Tool Model"),
                new XElement("Tools"));
            _doc.Save(_path);
        }
    }
}
