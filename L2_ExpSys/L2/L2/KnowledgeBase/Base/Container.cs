using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace KnowledgeBase.Base
{
    public class Container:IXmlSerializable
    {
        public Container()
        {
            rules = new List<Rule>();
            answers = new List<Answer>();
        }
        List<Rule> rules;
        List<Answer> answers;

        public void AddRules(string nameRule, string nameAnswer, List<CombinationFact> factRule, List<Fact> mutableFacts) //Добавить правило
        {
            Rule rule = new Rule(nameRule, nameAnswer);
            rule.AddCombinationFact(factRule);
            for (int index = 0; index < mutableFacts.Count; index++)
                rule.AddMutableFact(mutableFacts[index].NameFact, mutableFacts[index].StateOfFact);
            rules.Add(rule);
        }
        public void AddAnswer(string nameAnswer, List<CombinationFact> factsAnswer) //Добавить ответ
        {
            Answer answer = new Answer(nameAnswer);
            for (int index = 0; index < factsAnswer.Count; index++)
                answer.AddCombinationFact(factsAnswer);
            answers.Add(answer);
        }
        public IReadOnlyList<Rule> GetRules => rules; //Вернуть правила

        public IReadOnlyList<Answer> GetAnswers => answers; //Вернуть ответы
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
                    case "Rule":
                        var rule = new Rule();
                        rule.ReadXml(reader);
                        rules.Add(rule);
                        break;
                    case "Answer":
                        var answer = new Answer();
                        answer.ReadXml(reader);
                        answers.Add(answer);
                        break;
                    default: reader.Read(); break;
                }
            }
            reader.Read();

        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Rules");
            for(int index = 0; index < rules.Count; index++)
            {
                rules[index].WriteXml(writer);
            }
            writer.WriteEndElement();
            writer.WriteStartElement("Answers");
            for (int index = 0; index < answers.Count; index++)
            {
                answers[index].WriteXml(writer);
            }
            writer.WriteEndElement();
        }
    }
}
