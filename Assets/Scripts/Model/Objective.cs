using UnityEngine;

namespace Kolman_Freecss.QuestSystem
{
    [System.Serializable]
    public class Objective
    {
        public bool isCompleted;

        private int _currentAmount;
        
        public int CurrentAmount
        {
            get { return _currentAmount; }
        }

        [SerializeField] private int _requiredAmount;

        public int RequiredAmount
        {
            get => _requiredAmount;
        }
        
        public void UpdateAmount(int amount)
        {
            if (_currentAmount < _requiredAmount)
            {
                _currentAmount += amount;
            }
            else
            {
                isCompleted = true;
            }
        }
        
        /*public void ResetAmount()
        {
            _currentAmount = 0;
        }*/
    }
}