using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ToolOffset_LatheUtilities.LatheModels
{
    public class SimulationLatheRepository
    {
        public SimulationLatheRepository()
        {
            _filePath = Path.Combine(Environment.CurrentDirectory, FILENAME);
            document = new XDocument();
            if (!File.Exists(_filePath))
            {
                CreateXML();
            }
            document = XDocument.Load(_filePath);
        }

        private const string FILENAME = @"LatheAppMachineSettingsSim.xml";
        private readonly string _filePath;
        private XDocument document;

        public IEnumerable<MachineToolOffset> GetAll()
        {
            document = XDocument.Load(_filePath);
            return (from xmle in document.Element("MachineToolOffsets").Elements()
                    select new MachineToolOffset
                    {
                        ID = Convert.ToInt32(xmle.Attribute("ID").Value),
                        XOffset = Convert.ToDouble(xmle.Element("XOffset").Value),
                        YOffset = Convert.ToDouble(xmle.Element("YOffset").Value),
                        ZOffset = Convert.ToDouble(xmle.Element("ZOffset").Value),
                        XRadiusOffset = Convert.ToDouble(xmle.Element("XRadiusOffset").Value),
                        ZRadiusOffset = Convert.ToDouble(xmle.Element("ZRadiusOffset").Value),
                        RadiusCompPattern = Convert.ToInt32(xmle.Element("RadiusCompPattern").Value),
                        XWearOffset = Convert.ToDouble(xmle.Element("XWearOffset").Value),
                        ZWearOffset = Convert.ToDouble(xmle.Element("ZWearOffset").Value)
                    });
        }

        public MachineToolOffset GetOffset(int id)
        {
            document = XDocument.Load(_filePath);
            return (from xmle in document.Element("MachineToolOffsets").Elements()
                    where Convert.ToInt32(xmle.Attribute("ID").Value) == id
                    select new MachineToolOffset
                    {
                        ID = Convert.ToInt32(xmle.Attribute("ID").Value),
                        XOffset = Convert.ToDouble(xmle.Element("XOffset").Value),
                        YOffset = Convert.ToDouble(xmle.Element("YOffset").Value),
                        ZOffset = Convert.ToDouble(xmle.Element("ZOffset").Value),
                        XRadiusOffset = Convert.ToDouble(xmle.Element("XRadiusOffset").Value),
                        ZRadiusOffset = Convert.ToDouble(xmle.Element("ZRadiusOffset").Value),
                        RadiusCompPattern = Convert.ToInt32(xmle.Element("RadiusCompPattern").Value),
                        XWearOffset = Convert.ToDouble(xmle.Element("XWearOffset").Value),
                        ZWearOffset = Convert.ToDouble(xmle.Element("ZWearOffset").Value)
                    }).FirstOrDefault();
        }

        public void Update(MachineToolOffset offset, bool zeroWearOffset)
        {
            document = XDocument.Load(_filePath);
            XElement result = (from xmle in document.Element("MachineToolOffsets").Elements()
                               where Convert.ToInt32(xmle.Attribute("ID").Value) == offset.ID
                               select xmle).FirstOrDefault();
            if (result != null)
            {
                result.Element("XOffset").SetValue(offset.XOffset);
                result.Element("YOffset").SetValue(offset.YOffset);
                result.Element("ZOffset").SetValue(offset.ZOffset);
                result.Element("XRadiusOffset").SetValue(offset.XRadiusOffset);
                result.Element("ZRadiusOffset").SetValue(offset.ZRadiusOffset);
                result.Element("RadiusCompPattern").SetValue(offset.RadiusCompPattern);
                if (zeroWearOffset)
                    result.Element("XWearOffset").SetValue(0.000);
                if (zeroWearOffset)
                    result.Element("ZWearOffset").SetValue(0.000);
                document.Save(_filePath);
            }
        }

        public void Add(MachineToolOffset offset)
        {
            var result = (from xmle in document.Element("MachineToolOffsets").Elements()
                          where Convert.ToInt32(xmle.Attribute("ID").Value) == offset.ID
                          select xmle).FirstOrDefault();

            if (result == null)
            {
                document = XDocument.Load(_filePath);
                document.Element("MachineToolOffsets").Add(
                    new XElement("MachineToolOffset", new XAttribute("ID", offset.ID),
                    new XElement("XOffset", offset.XOffset),
                        new XElement("YOffset", offset.YOffset),
                        new XElement("ZOffset", offset.ZOffset),
                        new XElement("XRadiusOffset", offset.XRadiusOffset),
                        new XElement("ZRadiusOffset", offset.ZRadiusOffset),
                        new XElement("RadiusCompPattern", offset.RadiusCompPattern),
                        new XElement("XWearOffset", offset.XWearOffset),
                        new XElement("ZWearOffset", offset.ZRadiusOffset)));
                document.Save(_filePath);
            }
        }

        public void ResetOffset(int id)
        {
            document = XDocument.Load(_filePath);
            XElement result = (from xmle in document.Element("MachineToolOffsets").Elements()
                               where Convert.ToInt32(xmle.Attribute("ID").Value) == id
                               select xmle).FirstOrDefault();

            if (result != null)
            {
                result.Element("XOffset").SetValue(0.0);
                result.Element("YOffset").SetValue(0.0);
                result.Element("ZOffset").SetValue(0.0);
                result.Element("XRadiusOffset").SetValue(0.0);
                result.Element("ZRadiusOffset").SetValue(0.0);
                result.Element("RadiusCompPattern").SetValue(0);
                result.Element("XWearOffset").SetValue(0.000);
                result.Element("ZWearOffset").SetValue(0.000);
                document.Save(_filePath);
            }
        }

        private void CreateXML()
        {
            document = new XDocument(
                new XDeclaration("1.0", "utf-8", "true"),
                new XComment("Machine Tool Offset"),
                new XElement("MachineToolOffsets"));
            document.Save(_filePath);
        }
    }
}
