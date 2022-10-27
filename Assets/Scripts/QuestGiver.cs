using System.Collections.Generic;
using UnityEngine;

namespace Kolman_Freecss.QuestSystem
{
    public class QuestGiver : MonoBehaviour
    {
        [Header("Quest Info")] [SerializeField]
        private List<QuestSO> _quests = new List<QuestSO>();

        public List<QuestSO> Quests
        {
            get => _quests;
        }

        private QuestSO currentQuest;
    }
}