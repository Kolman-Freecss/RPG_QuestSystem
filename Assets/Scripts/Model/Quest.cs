namespace Kolman_Freecss.QuestSystem
{
    public class Quest
    {
        private QuestSO _questSo;
        private QuestStatus _status;
        private int _currentStep;
        private int _currentObjective;
    
        public Quest(QuestSO questSo)
        {
            _questSo = questSo;
            _status = QuestStatus.Inactive;
        }
    
        /*public void UpdateStatus()
        {
            if (_status == QuestStatus.Inactive)
            {
                if (CheckStartCondition())
                {
                    _status = QuestStatus.Active;
                    _currentStep = 0;
                    _currentObjective = 0;
                }
            }
            else if (_status == QuestStatus.Active)
            {
                if (CheckEndCondition())
                {
                    _status = QuestStatus.Completed;
                }
                else
                {
                    if (CheckObjectiveCondition())
                    {
                        _currentObjective++;
                    }
                }
            }
        }
    
        private bool CheckStartCondition()
        {
            return _questSo.StartCondition.Check();
        }
    
        private bool CheckEndCondition()
        {
            return _questSo.EndCondition.Check();
        }
    
        private bool CheckObjectiveCondition()
        {
            return _questSo.Steps[_currentStep].Objectives[_currentObjective].Check();
        }*/
        
        
        
    }

}