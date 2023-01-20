using KnowledgeBase.Base;
using System;
using System.Collections.Generic;

namespace KnowledgeBase
{
    class WorkMemory
    {
        public WorkMemory()
        {
            _temporaryFacts = new List<Fact>();
        }

        private List<Fact> _temporaryFacts;

        public IReadOnlyList<Fact>  TemporaryFacts => _temporaryFacts;

        public void AddFact(string nameFact,bool stateOfFact) //Добавить факт
        {
            var fact = new Fact(nameFact, stateOfFact);
            _temporaryFacts.Add(fact);
        }
    }
}
