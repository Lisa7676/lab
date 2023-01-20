using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using KnowledgeBase.Base;

namespace KnowledgeBase 
{
    
    class KnowledgeBase //класс БЗ
    {
        WorkMemory workMemory;
        Container container;

        public void AddRules(string nameRule, string nameAnswer, List<CombinationFact> factRule, List<Fact> mutableFacts) //Добавить правило
        {
            container.AddRules(nameRule, nameAnswer, factRule, mutableFacts);
        }
        public void AddAnswer(string nameAnswer, List<CombinationFact> factsAnswer)//Добавить ответ
        {
            container.AddAnswer(nameAnswer, factsAnswer);
        }

        public IReadOnlyList<Rule> GetRules => container.GetRules; //Вернуть правила из БЗ

        public IReadOnlyList<Answer> GetAnswers => container.GetAnswers; //Вернуть ответы из БЗ

        public IReadOnlyList<Fact> GetFactWorkMemory => workMemory.TemporaryFacts; //Вернуть факты из Рабочей области

        private static KnowledgeBase knowledge = null;

        private KnowledgeBase()
        {
            workMemory = new WorkMemory();
            container = new Container();
        }

        public static KnowledgeBase GetKnowledge
        {
            get
            {
                if (knowledge == null)
                    knowledge = new KnowledgeBase();
                return knowledge;
            }
        }
        public void DropWorkMemory() //Обнулить рабочую область
        {
            workMemory = new WorkMemory();
        }
        public void AddNewFactWorkMemory(string nameFact, bool stateOfFact) //Добавить факт в рабочую область
        {
            workMemory.AddFact(nameFact, stateOfFact);
        }
        public void Load(string filename = "KnowledgeBase.xml")
        {
            var binFormatter = new XmlSerializer(typeof(Container));
            if (filename != null)
            {
                using (var file = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    container = (Container)binFormatter.Deserialize(file);
                    file.Close();
                }

            }
        }

        public void Save(string fileName)
        {
            try
            {
                if (fileName != null)
                {
                    var binFormatter = new XmlSerializer(typeof(Container));
                    using (var file = new FileStream(fileName, FileMode.CreateNew))
                    {
                        binFormatter.Serialize(file, container);
                        file.Close();
                    }
                }
            }
            catch (System.IO.IOException) { MessageBox.Show("Данный файл уже существует"); }
        }

    }
}
