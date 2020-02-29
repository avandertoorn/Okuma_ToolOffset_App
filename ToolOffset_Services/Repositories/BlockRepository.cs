using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        private List<BlockAssembly> _blocks;

        public void Add(BlockAssembly item)
        {
            var result = (from block in _document.Element("Blocks").Elements("Block")
                          where Convert.ToInt32(block.Attribute("ID").Value) == item.Block.ID
                          select block).FirstOrDefault();

            if (result != null)
                throw new Exception("ID already in use");

            _document.Element("Blocks").Add(ConvertBlockAssemblyToXElement(item));

            var orderedResult = from el in _document.Element("Blocks").Elements("Block")
                                orderby Convert.ToInt32(el.Attribute("ID").Value)
                                select el;

            _document.Element("Blocks").ReplaceAll(orderedResult);

            _document.Save(_path);

            BlocksListCheck();
            _blocks.Add(item);
        }

        public void Delete(int id)
        {
            _document.Element("Blocks").Elements("Block")
                .Where(a => Convert.ToInt32(a.Attribute("ID").Value) == id)
                .Remove();

            _document.Save(_path);

            BlocksListCheck();
            _blocks.RemoveAll(a => a.Block.ID == id);
        }

        public BlockAssembly Get(int id)
        {
            BlocksListCheck();
            return _blocks.FirstOrDefault(a => a.Block.ID == id);
        }

        public IEnumerable<BlockAssembly> GetAll()
        {
            BlocksListCheck();
            return _blocks;
        }

        public void Update(BlockAssembly item, int originalId)
        {
            var result = (from block in _document.Element("Blocks").Elements("Block")
                          where Convert.ToInt32(block.Attribute("ID").Value) == originalId
                          select block).FirstOrDefault();

            if (result == null)
                throw new Exception("Id not found");

            var xElementBlock = ConvertBlockAssemblyToXElement(item);

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
            _blocks = new List<BlockAssembly>(GetAllFromXml());
        }

        private XElement ConvertBlockAssemblyToXElement(BlockAssembly blockAssembly)
        {
            return new XElement("Block", new XAttribute("ID", blockAssembly.Block.ID),
                new XElement("Name", blockAssembly.Block.Name),
                new XElement("Comment", blockAssembly.Block.Comment),
                new XElement("BlockType", (int)blockAssembly.Block.BlockType),
                new XElement("Quantity", blockAssembly.Quantity),
                new XElement("Positions",
                    from position in blockAssembly.Positions
                    select ConvertPositionToExelement(position)));
        }

        private XElement ConvertPositionToExelement(Position position)
        {
            return new XElement("Position", new XAttribute("ID", position.BlockPosition.ID),
                        new XElement("Name", position.BlockPosition.Name),
                        new XElement("Side", (int)position.BlockPosition.Side),
                        new XElement("Type", (int)position.BlockPosition.Hand),
                        new XElement("XOffset", position.BlockPosition.XOffset),
                        new XElement("YOffset", position.BlockPosition.YOffset),
                        new XElement("ZOffset", position.BlockPosition.ZOffset));
        }

        private BlockAssembly ConverToBlockAssembly(XElement blockElement)
        {
            return new BlockAssembly(
                new Block(
                    Convert.ToInt32(blockElement.Attribute("ID").Value),
                    blockElement.Element("Name").Value,
                    blockElement.Element("Comment").Value,
                    (BlockType)Convert.ToInt32(blockElement.Element("BlockType").Value)),
                new List<Position>(from positionElement in blockElement.Element("Positions").Elements("Position")
                                   select ConvertToPosition(positionElement)));
        }

        private Position ConvertToPosition(XElement positionElement)
        {
            return new Position(new BlockPosition(
                                        Convert.ToInt32(positionElement.Attribute("ID").Value),
                                        positionElement.Element("Name").Value,
                                        (BlockPositionSide)Convert.ToInt32(positionElement.Element("Side").Value),
                                        (BlockPositionHand)Convert.ToInt32(positionElement.Element("Type").Value),
                                        Convert.ToDouble(positionElement.Element("XOffset").Value),
                                        Convert.ToDouble(positionElement.Element("YOffset").Value),
                                        Convert.ToDouble(positionElement.Element("ZOffset").Value)));
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

        private IEnumerable<BlockAssembly> GetAllFromXml()
        {
            return _document.Element("Blocks").Elements("Block").Select(
                a => ConverToBlockAssembly(a));
        }

        private void BlocksListCheck()
        {
            if (_blocks == null)
            {
                LoadXml();
                _blocks = new List<BlockAssembly>(GetAllFromXml());
            }
        }
    }
}
