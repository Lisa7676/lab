using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace KnowledgeBase.Base
{	
	public  class Rule:IXmlSerializable
	{
		string _nameRule;
		string _nameQuestion;

		List<CombinationFact> _factsRuele;
		List<Fact> _mutableFact;

        public Rule(string nameRule, string nameQuestion)
        {
            _nameRule = nameRule;
            _nameQuestion = nameQuestion;
            _factsRuele = new List<CombinationFact>();
            _mutableFact = new List<Fact>();
            IsUsed = false;
        }
        public Rule()
        {
            _factsRuele = new List<CombinationFact>();
            _mutableFact = new List<Fact>();
            IsUsed = false;
        }
        public string NameRule => _nameRule; //Имя правила
        public string NameQuestion => _nameQuestion; //Вопрос

        public bool IsUsed;
        public void Used()
        {
            IsUsed = true;
        }

        public void UnUsed()
        {
            IsUsed = false;
        }
       

		public IReadOnlyList<CombinationFact> GetCombinationFacts => _factsRuele; //Получить комбинацию фактов

		public IReadOnlyList<Fact> GetMutableFacts => _mutableFact; //Получить факты из рабочей области

		public void AddMutableFact(string nameFact,bool? stateOfFact) //Добавить факт
        {
			_mutableFact.Add(new Fact(nameFact, stateOfFact));
        }

		public void AddCombinationFact(List<CombinationFact> facts)//Добавить комбинацию фактов
		{	
			for(int i=0;i<facts.Count;i++)
			_factsRuele.Add(facts[i]);			
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
					case "nameRule":
						_nameRule = reader.ReadElementString();
						break;
					case "CombinationFact":
						var combinationFact = new CombinationFact();
						combinationFact.ReadXml(reader);
						_factsRuele.Add(combinationFact);
						break;
					case "nameQuestion":
						_nameQuestion = reader.ReadElementString();
						break;
					case "MutableFact":
						var fact = new Fact();
						fact.ReadXml(reader);
						_mutableFact.Add(fact);
						break;
					default: reader.Read(); break;
				}
			}
			reader.Read();
			if (reader.LocalName == "Rule") { reader.Read(); }
			if (reader.LocalName == "Rules") { reader.Read(); }
		}

        public void WriteXml(XmlWriter writer)
        {
			writer.WriteStartElement("Rule");
			writer.WriteStartElement("nameRule");
			writer.WriteString(NameRule);
			writer.WriteEndElement();
			writer.WriteStartElement("nameQuestion");
			writer.WriteString(NameQuestion);
			writer.WriteEndElement();
			writer.WriteStartElement("CombinationsFact");
			for (int index = 0; index < _factsRuele.Count; index++)
            {
				_factsRuele[index].WriteXml(writer);
            }
			writer.WriteEndElement();
			writer.WriteStartElement("MutablesFact");
			for (int index = 0; index < _mutableFact.Count; index++)
			{
				writer.WriteStartElement("MutableFact");
				_mutableFact[index].WriteXml(writer);
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
    }
}
