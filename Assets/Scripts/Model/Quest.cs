﻿namespace Kolman_Freecss.QuestSystem
{
    public class Quest
    {
        private int _id;
        public int ID
        {
            get { return _id; }
        }
        
        private QuestSO _questSo;
        public QuestSO QuestSO
        {
            get { return _questSo; }
        }
        
        private QuestStatus _status;
        public int storyId;
        
        public Quest(QuestSO questSo)
        {
            _questSo = questSo;
            _status = QuestStatus.Inactive;
            storyId = questSo.storyId;
        }
        
        public Quest(QuestSO questSo, int questId)
        {
            _id = questId;
            _questSo = questSo;
            _status = QuestStatus.Inactive;
            storyId = questSo.storyId;
        }
        
        public void ActiveQuest()
        {
            _status = QuestStatus.NotStarted;
        }
        
        public void StartQuest()
        {
            _status = QuestStatus.Started;
        }
        
        public void CompleteQuest()
        {
            _status = QuestStatus.Completed;
        }
    
        public void UpdateStatus()
        {
            if (_status.Equals(QuestStatus.NotStarted))
            {
                //if (CheckStartCondition())
                //{
                    _status = QuestStatus.Started;
                //}
            }
            else if (_status == QuestStatus.Started)
            {
                if (CheckEndCondition())
                {
                    _status = QuestStatus.Completed;
                }
            }
        }
        
        /*private bool CheckStartCondition()
        {
            return _questSo.StartCondition.CheckCondition();
        }*/
        
        private bool CheckEndCondition()
        {
            bool endCondition = true;
            _questSo.Objectives.ForEach(o =>
            {
                if (!o.isCompleted)
                {
                    endCondition = false;
                }
            });
            return endCondition;
        }
        
        public bool IsNotStarted()
        {
            return _status == QuestStatus.NotStarted;
        }
        
        public bool IsStarted()
        {
            return _status == QuestStatus.Started;
        }
        
        public bool IsCompleted()
        {
            return QuestStatus.Completed.Equals(_status);
        }
        
    }

}