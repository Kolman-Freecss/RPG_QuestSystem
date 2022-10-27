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

        public Quest CurrentQuest { get; }

        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        void Start()
        {
            Quests.ForEach(q => q.storyId = q.QuestSO.storyId);
        }
        
        public bool HasQuest(Quest quest)
        {
            return Quests.Contains(quest);
        }

        public void AcceptQuest()
        {
            CurrentQuest.UpdateStatus();
            _gameManager.currentStory.AcceptQuest();
        }
        
        public void CompleteQuest()
        {
            CurrentQuest.UpdateStatus();
            _gameManager.NextQuest();
        }
        
    }
}