using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace KnowledgeBase.Base
{
	public class Fact:IXmlSerializable
	{
		public Fact(string nameFact, bool? stateFact)
		{
			_nameFact = nameFact;
			_stateOfFact = stateFact;

		}
		public Fact()
        {

        }

		string _nameFact;
		bool? _stateOfFact;

		public string NameFact => _nameFact;

		public bool? StateOfFact { get => _stateOfFact; set => _stateOfFact = value; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
			reader.Read();
			while (reader.NodeType != XmlNodeType.EndElement)
			{
				switch (reader.LocalName)
				{
					case "nameFact":
						_nameFact = reader.ReadElementString();
						break;
					case "dataFact":
                        try
                        {
                            _stateOfFact = Convert.ToBoolean(reader.ReadElementString());
                        }
                        catch (System.FormatException) { _stateOfFact = null; }
                        break;
					default: reader.Read(); break;
				}
			}
			reader.Read();
			if (reader.LocalName == "MutableFact") { reader.Read(); }
		}

        public void WriteXml(XmlWriter writer)
        {
			writer.WriteStartElement("Fact");
			writer.WriteStartElement("nameFact");
			writer.WriteString(NameFact);
			writer.WriteEndElement();
			writer.WriteStartElement("dataFact");
			writer.WriteString(Convert.ToString(StateOfFact));
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
    }
}
