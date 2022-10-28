using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kolman_Freecss.QuestSystem
{
    public class QuestGiver : MonoBehaviour
    {
        [Header("Quest Info")]
        public List<QuestSO> QuestsSO = new List<QuestSO>();
        
        private List<Quest> Quests = new List<Quest>();

        public Quest CurrentQuest;

        void Start()
        {
            QuestsSO.ForEach(x => Quests.Add(new Quest(x)));
            CurrentQuest = Quests[0];
        }
        
        public bool HasQuest(Quest quest)
        {
            return Quests.Contains(quest);
        }
        
    }
}