using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace KnowledgeBase.Base
{
	public class Answer:IXmlSerializable
	{
        public Answer(string nameAnswer)
        {
            _nameAnswer = nameAnswer;
            _factsAnswer = new List<CombinationFact>();
        }
        public Answer()
        {
            _factsAnswer = new List<CombinationFact>();
        }
        
		string _nameAnswer;
		List<CombinationFact> _factsAnswer;

		public string NameAnswer { get => _nameAnswer; }

		public IReadOnlyList<CombinationFact> GetCombinationFacts => _factsAnswer; //Найти комбинацию фактов

		public void AddCombinationFact(List<CombinationFact> facts)//Добавить комбинацию фактов
		{
			for (int i = 0; i < facts.Count; i++)
				_factsAnswer.Add(facts[i]);
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
					case "nameAnswer":
						_nameAnswer = reader.ReadElementString();
						break;
					case "CombinationFact":
						var combinationFact = new CombinationFact();
						combinationFact.ReadXml(reader);
						_factsAnswer.Add(combinationFact);
						break;
					default: reader.Read(); break;
				}
			}
			reader.Read();
		}

        public void WriteXml(XmlWriter writer)
        {
			writer.WriteStartElement("Answer");
			writer.WriteStartElement("nameAnswer");
			writer.WriteString(NameAnswer);
			writer.WriteEndElement();
			writer.WriteStartElement("CombinationsFact");
			for (int indexer = 0; indexer < _factsAnswer.Count; indexer++)
            {
				_factsAnswer[indexer].WriteXml(writer);
            }
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
    }

}
