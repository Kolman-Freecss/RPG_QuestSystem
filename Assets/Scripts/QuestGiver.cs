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

        private void Awake()
        {
            QuestsSO.ForEach(x => Quests.Add(new Quest(x, x.StoryStep)));
        }

        void Start()
        {
            CurrentQuest = Quests[0];
        }
        
        public bool HasQuest(Quest quest)
        {
            return Quests.Contains(quest);
        }
        
        public bool HasQuest(int questId)
        {
            return Quests.Exists(x => x.ID == questId);
        }
        
        public void FinishQuest()
        {
            CurrentQuest = null;
        }

        public Quest CompleteQuest()
        {
            return CurrentQuest.CompleteQuest();
        }
        
        /**
         * Refresh the quest by quest id parameter
         */
        public void RefreshQuest(int questId)
        {
            Quest qs = Quests.Find(x => x.ID == questId).UpdateStatus();
            if (qs.Status == QuestStatus.NotStarted)
            {
                CurrentQuest = qs;
            }
        }
        
    }
}