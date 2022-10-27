using UnityEngine;

namespace Kolman_Freecss.QuestSystem
{
    [System.Serializable]
    public class Objective
    {
        public bool isCompleted;

        private int _currentAmount;

        [SerializeField] private int _requiredAmount;

        public int RequiredAmount
        {
            get => _requiredAmount;
        }

        public void CheckCompletion()
        {
            if (_currentAmount >= RequiredAmount)
            {
                isCompleted = true;
            }
        }
    }
}