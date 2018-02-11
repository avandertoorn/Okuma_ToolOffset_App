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
    public class ToolBlockRepository : IRepository<ToolBlock>
    {
        private XDocument _doc;
        private string _path;

        public ToolBlockRepository()
        {
            if (Properties.Settings.Default.ToolBlocksXMLPath == "")
            {
                string path = Directory.GetCurrentDirectory();
                path = path + @"\ToolBlocks.xml";
                Properties.Settings.Default.ToolBlocksXMLPath = path;
            }

            _path = Properties.Settings.Default.ToolBlocksXMLPath;

            if (!File.Exists((Properties.Settings.Default.ToolBlocksXMLPath)))
                CreateXml();

            _doc = XDocument.Load(Properties.Settings.Default.ToolBlocksXMLPath);
        }

        public IEnumerable<ToolBlock> GetAll()
        {
            IEnumerable<ToolBlock> toolBlocks
                = (from _toolBlock in _doc.Element("ToolBlocks").Elements("ToolBlock")
                   select new ToolBlock
                   {
                       ID = Convert.ToInt32(_toolBlock.Attribute("ID").Value),
                       Name = _toolBlock.Element("Name").Value,
                       Comment = _toolBlock.Element("Comment").Value,
                       BlockType = (BlockTypeEnum)Convert.ToInt32(_toolBlock.Element("BlockType").Value),
                       Positions = new List<BlockPosition>
                       (from _positions in _toolBlock.Element("Positions").Elements("Position")
                        select new BlockPosition
                        {
                            ID = Convert.ToInt32(_positions.Attribute("ID").Value),
                            Name = _positions.Element("Name").Value,
                            Side = (BlockSideEnum)Convert.ToInt32(_positions.Element("Side").Value),
                            Type = (BlockPositionTypeEnum)Convert.ToInt32(_positions.Element("Type").Value),
                            XOffset = Convert.ToDouble(_positions.Element("XOffset").Value),
                            YOffset = Convert.ToDouble(_positions.Element("YOffset").Value),
                            ZOffset = Convert.ToDouble(_positions.Element("ZOffset").Value)
                        })
                   });
            return toolBlocks;
        }

        public ToolBlock GetByID(int ID)
        {
            XElement data
                = _doc.Element("ToolBlocks").Elements("ToolBlock")
                .Where(a => Convert.ToInt32(a.Attribute("ID").Value) == ID)
                .FirstOrDefault();
            if (data != null)
            {
                ToolBlock toolBlock
                = new ToolBlock
                {
                    ID = Convert.ToInt32(data.Attribute("ID").Value),
                    Name = data.Element("Name").Value,
                    Comment = data.Element("Comment").Value,
                    BlockType = (BlockTypeEnum)Convert.ToInt32(data.Element("BlockType").Value),
                    Positions = new List<BlockPosition>
                       (from _positions in data.Element("Positions").Elements("Position")
                        select new BlockPosition
                        {
                            ID = Convert.ToInt32(_positions.Attribute("ID").Value),
                            Name = _positions.Element("Name").Value,
                            Side = (BlockSideEnum)Convert.ToInt32(_positions.Element("Side").Value),
                            Type = (BlockPositionTypeEnum)Convert.ToInt32(_positions.Element("Type").Value),
                            XOffset = Convert.ToDouble(_positions.Element("XOffset").Value),
                            YOffset = Convert.ToDouble(_positions.Element("YOffset").Value),
                            ZOffset = Convert.ToDouble(_positions.Element("ZOffset").Value)
                        })
                };
                return toolBlock;
            }

            else
                throw new Exception("ID not found");
        }

        public void Insert(ToolBlock item)
        {
            XElement result = _doc.Element("ToolBlocks").Elements("ToolBlock")
                .Where(a => Convert.ToInt32(a.Attribute("ID").Value) == item.ID)
                .FirstOrDefault();

            if (result == null)
            {
                _doc.Element("ToolBlocks").Add(
                new XElement("ToolBlock", new XAttribute("ID", item.ID),
                    new XElement("Name", item.Name),
                    new XElement("Comment", item.Comment),
                    new XElement("BlockType", (int)item.BlockType),
                    new XElement("Positions",
                        from BlockPosition position in item.Positions
                        select new XElement("Position", new XAttribute("ID", position.ID),
                            new XElement("Name", position.Name),
                            new XElement("Side", (int)position.Side),
                            new XElement("Type", (int)position.Type),
                            new XElement("XOffset", position.XOffset),
                            new XElement("YOffset", position.YOffset),
                            new XElement("ZOffset", position.ZOffset)))));

                IOrderedEnumerable<XElement> results = from XElement el in _doc.Element("ToolBlocks").Elements("ToolBlock")
                                                       orderby Convert.ToInt32(el.Attribute("ID").Value)
                                                       select el;

                _doc.Element("ToolBlocks").ReplaceAll(results.ToArray());
                _doc.Save(_path);
            }
            else
                throw new Exception("ID already used");
        }

        public void Update(ToolBlock item)
        {
            XElement toolBlock = _doc.Element("ToolBlocks").Elements("ToolBlock")
                .Where(a => Convert.ToInt32(a.Attribute("ID").Value) == item.ID)
                .FirstOrDefault();

            if (toolBlock == null)
                throw new Exception("Id not found");
            else
            {
                toolBlock.SetElementValue("Name", item.Name);
                toolBlock.SetElementValue("Comment", item.Comment);
                toolBlock.SetElementValue("BlockType", (int)item.BlockType);
                toolBlock.Element("Positions").ReplaceAll(
                    from BlockPosition position in item.Positions
                    select new XElement("Position", new XAttribute("ID", position.ID),
                        new XElement("Name", position.Name),
                        new XElement("Side", (int)position.Side),
                        new XElement("Type", (int)position.Type),
                        new XElement("XOffset", position.XOffset),
                        new XElement("YOffset", position.YOffset),
                        new XElement("ZOffset", position.ZOffset)));
            }
            _doc.Save(_path);
        }

        public void Delete(int ID)
        {
            _doc.Element("ToolBlocks").Elements("ToolBlock")
                .Where(a => Convert.ToInt32(a.Attribute("ID").Value) == ID)
                .Remove();
            _doc.Save(_path);
        }

        private void CreateXml()
        {
            _doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "true"),
                new XComment("ToolBlock Model"),
                new XElement("ToolBlocks"));
            _doc.Save(_path);
        }
    }
}
