using KnowledgeBase;
using KnowledgeBase.Base;
using L2;
using L2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface
{
    class LogicalMachine
    {
        public LogicalMachine()
        {
            knowledgeBase = KnowledgeBase.KnowledgeBase.GetKnowledge;
            AnswersWays = new List<string>();
        }
        KnowledgeBase.KnowledgeBase knowledgeBase;

        private Rule CurentRule;

        public string ResaltAnswer { get; private set; } //Результат
        
        public string CurQuestion { get; private set; } // Текущий вопрос пользователю

        public List<string> AnswersWays; // Список вариантов ответа, когда не да/нет
        
        public void SaveKnowladgeBase(string nameFile)
        {
            knowledgeBase.Save(nameFile);
        }
        public void LoadKnowladgeBase()
        {
            knowledgeBase.Load();
        }
        public void GetCurentRule() //Поиск подходящего правила
        {
            CurentRule = null;
            CurQuestion = null;
            AnswersWays.Clear();
            var RulersList = knowledgeBase.GetRules;
            var instanteMemoryCopy = knowledgeBase.GetFactWorkMemory;
            var fik = knowledgeBase.GetAnswers;

            foreach (var rul in RulersList)
            {
                if (!rul.IsUsed)
                {
                    if (instanteMemoryCopy.Count == 0 && rul.GetCombinationFacts.Count == 0 || rul.GetCombinationFacts.Count == 0)
                    {
                        CurentRule = rul;
                        rul.Used();
                        AddDataAboutSelectedRule();
                        break;
                    }
                    else if (instanteMemoryCopy.Count != 0)
                    {
                        bool isContainsNeededFacts = true;

                        foreach (var Combfact in rul.GetCombinationFacts)
                        {
                            isContainsNeededFacts = true;
                            foreach (var fact in Combfact.GetFacts)
                            {
                                if (isContainsNeededFacts)
                                {
                                    var factInMemory = instanteMemoryCopy.Where(f => f.NameFact == fact.NameFact).ToList();
                                    if (factInMemory.Count == 1)
                                    {
                                        if (factInMemory[0].StateOfFact != fact.StateOfFact) { isContainsNeededFacts = false; }
                                    }
                                    else { isContainsNeededFacts = false; }
                                }
                                else { break; }
                            }
                            if (isContainsNeededFacts)
                            {
                                CurentRule = rul;
                                rul.Used();
                                AddDataAboutSelectedRule();
                                break;
                            }
                        }
                        if (isContainsNeededFacts){break;}
                    }
                }
            }
        }
        public void AddDataFromUser(UserAnswer answer) //Заполняются факты, на которые влияют ответы пользователя
        {
            if(answer.Answer!=null)
            {
                var NewFact = CurentRule.GetMutableFacts[0];
                knowledgeBase.AddNewFactWorkMemory(NewFact.NameFact, (bool)answer.Answer);
            }
            else 
            {
                foreach( var fact in CurentRule.GetMutableFacts)
                {
                    if (fact.NameFact == answer.SelectedAnswer) { knowledgeBase.AddNewFactWorkMemory(fact.NameFact, true); }
                    else { knowledgeBase.AddNewFactWorkMemory(fact.NameFact, false); }
                }
            }
            CheckAnswers();
            if(ResaltAnswer == null)
            GetCurentRule();
        }

        private void AddDataAboutSelectedRule()
        {
            CurQuestion = CurentRule.NameQuestion;
            if (CurQuestion != "")
            {
                foreach (var a in CurentRule.GetMutableFacts)
                    AnswersWays.Add(a.NameFact);
            }
            else
            {
                var NewFact = CurentRule.GetMutableFacts[0];
                knowledgeBase.AddNewFactWorkMemory(NewFact.NameFact, (bool)NewFact.StateOfFact);
                CheckAnswers();
                GetCurentRule();
            }
        }
        private void CheckAnswers() //Проверка наличия ответа
        {
            var answers = knowledgeBase.GetAnswers;
            var instanteMemoryCopy = knowledgeBase.GetFactWorkMemory;
            foreach (var answ in answers) 
            { 
                bool isContainsNeededFacts = true;
                foreach (var Combfact in answ.GetCombinationFacts)
                {
                    isContainsNeededFacts = true;
                    foreach (var fact in Combfact.GetFacts)
                    {
                        if (isContainsNeededFacts)
                        {
                            var factInMemory = instanteMemoryCopy.Where(f => f.NameFact == fact.NameFact).ToList();
                            if (factInMemory.Count == 1)
                            {
                                if (factInMemory[0].StateOfFact != fact.StateOfFact) { isContainsNeededFacts = false; }
                            }
                            else
                            {
                                isContainsNeededFacts = false;
                                break;
                            }
                        }
                        else { break; }
                    }
                if (isContainsNeededFacts)
                {
                    ResaltAnswer = answ.NameAnswer;
                    break;
                }
                }
                if (isContainsNeededFacts) { break; }
            }
        }

        
        public void ShowGeneratedFacts() //Показать рабочую область
        {
            Form2 KBase = new Form2(knowledgeBase.GetFactWorkMemory.ToList());
            KBase.Show();
        }
        public void Restart() //Обнулить рабочую область
        {
            knowledgeBase.DropWorkMemory();
            foreach(var rul in knowledgeBase.GetRules)
            {
                rul.UnUsed();
            }
            ResaltAnswer = null;
        }

    }
    
   
}
