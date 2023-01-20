using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace KnowledgeBase.Base
{

	public class CombinationFact : IXmlSerializable
	{
		List<Fact> _factsRule;

		public CombinationFact()
		{
			_factsRule = new List<Fact>();
		}
		public CombinationFact(List<Fact> facts)
		{
			_factsRule = new List<Fact>();
			for (int i = 0; i < facts.Count; i++)
				AddFact(facts[i].NameFact, facts[i].StateOfFact);
		}
		public IReadOnlyList<Fact> GetFacts => _factsRule; //Найти факт
		public void AddFact(string nameFact, bool? stateOfFact)//Добавить факт
		{
			Fact fact = new Fact(nameFact, stateOfFact);
			_factsRule.Add(fact);
		}

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

					case "Fact":
						var factsRuele = new Fact();
						factsRuele.ReadXml(reader);
						_factsRule.Add(factsRuele);
						break;
					default: reader.Read(); break;
				}
			}
			reader.Read();
			if (reader.LocalName == "CombinationsFact") { reader.Read(); }
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement("CombinationFact");
			for (int indexer = 0; indexer < _factsRule.Count; indexer++)
			{
				_factsRule[indexer].WriteXml(writer);
			}
			writer.WriteEndElement();
		}
	}
}

