namespace Kolman_Freecss.QuestSystem
{
    public class Objective
    {
        private bool _isCompleted { get; set; }
        private int _currentAmount { get; set; }
        public int RequiredAmount { get; set; }

        public void CheckCompletion()
        {
            if (_currentAmount >= RequiredAmount)
            {
                _isCompleted = true;
            }
        }
    }
}