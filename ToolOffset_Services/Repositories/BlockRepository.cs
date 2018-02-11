using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Linq;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Tools;
using ToolOffset_Services.Interfaces;

namespace ToolOffset_Services.Repositories
{
    public class BlockRepository : IBlockRepository
    {
        private string _path;
        private XDocument _document;

        public void Add(BlockAssembly item)
        {
            LoadXml();

            var result = (from block in _document.Element("Blocks").Elements("Block")
                          where Convert.ToInt32(block.Attribute("ID").Value) == item.Block.ID
                          select block).FirstOrDefault();

            if (result != null)
                throw new Exception("ID already in use");

            _document.Element("Blocks").Add(ConvertToXElement(item));

            var orderedResult = from el in _document.Element("Blocks").Elements("Block")
                                orderby Convert.ToInt32(el.Attribute("ID").Value)
                                select el;

            _document.Element("Blocks").ReplaceAll(orderedResult);

            _document.Save(_path);
        }

        public void Delete(int id)
        {
            LoadXml();

            _document.Element("Blocks").Elements("Block")
                .Where(a => Convert.ToInt32(a.Attribute("ID").Value) == id)
                .Remove();

            _document.Save(_path);
        }

        public BlockAssembly Get(int id)
        {
            LoadXml();

            return (from elem in _document.Element("Blocks").Elements("Block")
                    where Convert.ToInt32(elem.Attribute("ID").Value) == id
                    select (ConverToBlockAssembly(elem))).FirstOrDefault();
        }

        public IEnumerable<BlockAssembly> GetAll()
        {
            LoadXml();

            return (from elem in _document.Element("Blocks").Elements("Block")
                    select (ConverToBlockAssembly(elem))).ToList();
        }

        public void Update(BlockAssembly item)
        {
            LoadXml();

            var result = (from block in _document.Element("Blocks").Elements("Block")
                          where Convert.ToInt32(block.Attribute("ID").Value) == item.Block.ID
                          select block).FirstOrDefault();

            if (result == null)
                throw new Exception("Id not found");

            var xElementBlock = ConvertToXElement(item);

            result.ReplaceWith(xElementBlock);

            _document.Save(_path);
        }

        public BlockRepository()
        {
            _document = new XDocument();

            if (Properties.Settings.Default.BlockXMLPath == "")
                InitializePath();

            _path = Properties.Settings.Default.BlockXMLPath;
            LoadXml();
        }

        private XElement ConvertToXElement(BlockAssembly blockAssembly)
        {
            return new XElement("Block", new XAttribute("ID", blockAssembly.Block.ID),
                new XElement("Name", blockAssembly.Block.Name),
                new XElement("Comment", blockAssembly.Block.Comment),
                new XElement("BlockType", (int)blockAssembly.Block.BlockType),
                new XElement("Quantity", blockAssembly.Quantity),
                new XElement("Positions",
                    from pos in blockAssembly.Positions
                    select new XElement("Position", new XAttribute("ID", pos.BlockPosition.ID),
                        new XElement("Name", pos.BlockPosition.Name),
                        new XElement("Side", (int)pos.BlockPosition.Side),
                        new XElement("Type", (int)pos.BlockPosition.Type),
                        new XElement("XOffset", pos.BlockPosition.XOffset),
                        new XElement("YOffset", pos.BlockPosition.YOffset),
                        new XElement("ZOffset", pos.BlockPosition.ZOffset))));
        }

        private BlockAssembly ConverToBlockAssembly(XElement blockElement)
        {
            return new BlockAssembly(
                new Block(
                    Convert.ToInt32(blockElement.Attribute("ID").Value),
                    blockElement.Element("Name").Value,
                    blockElement.Element("Comment").Value,
                    (BlockType)Convert.ToInt32(blockElement.Element("BlockType").Value)),
                new List<Position>(from xElement in blockElement.Element("Positions").Elements("Position")
                                   select new Position(
                                       new BlockPosition(
                                           Convert.ToInt32(xElement.Attribute("ID").Value),
                                           xElement.Element("Name").Value,
                                           (BlockPositionSide)Convert.ToInt32(xElement.Element("Side").Value),
                                           (BlockPositionHand)Convert.ToInt32(xElement.Element("Type").Value),
                                           Convert.ToDouble(xElement.Element("XOffset").Value),
                                           Convert.ToDouble(xElement.Element("YOffset").Value),
                                           Convert.ToDouble(xElement.Element("ZOffset").Value)))));
        }

        private void InitializePath()
        {
            var path = Directory.GetCurrentDirectory();
            path += @"\Blocks.xml";
            Properties.Settings.Default.BlockXMLPath = path;
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
                new XComment("Block Models"),
                new XElement("Blocks"));

            _document.Save(_path);
        }
    }
}
