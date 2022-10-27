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

        public void AcceptQuest()
        {
            
        }
        
        public void CompleteQuest()
        {
            
        }
        
    }
}