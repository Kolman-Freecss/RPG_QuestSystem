using System.Collections.Generic;
using UnityEngine;

namespace Kolman_Freecss.QuestSystem
{
    public class QuestGiver : MonoBehaviour
    {
        [Header("Quest Info")] [SerializeField]
        private List<Quest> _quests = new List<Quest>();

        public List<Quest> Quests
        {
            get => _quests;
        }

        public Quest CurrentQuest { get; }

        public GameManager gameManager;
        
        void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
            _quests.ForEach(q => q.storyId = q.QuestSO.storyId);
        }
        
        public bool HasQuest(Quest quest)
        {
            return _quests.Contains(quest);
        }

        public void AcceptQuest()
        {
            CurrentQuest.UpdateStatus();
            gameManager.currentStory.AcceptQuest();
        }
        
        public void CompleteQuest()
        {
            CurrentQuest.UpdateStatus();
            gameManager.NextQuest();
        }
        
    }
}