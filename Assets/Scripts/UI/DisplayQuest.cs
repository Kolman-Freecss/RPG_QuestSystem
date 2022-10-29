using System;
using TMPro;
using UnityEngine;

namespace Kolman_Freecss.QuestSystem
{
    public class DisplayQuest : MonoBehaviour
    {
        [Header("Quest")]
        [SerializeField]
        TextMeshProUGUI questName;
        
        [SerializeField]
        TextMeshProUGUI questDescription;
        
        [SerializeField]
        TextMeshProUGUI objectiveDescription;
        
        [SerializeField]
        TextMeshProUGUI objectiveProgress;
        
        [SerializeField]
        TextMeshProUGUI questReward;
        
        GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Update()
        {
            if (_gameManager.currentStory != null && _gameManager.currentStory.CurrentQuest != null)
            {
                DisplayQuestInfo(_gameManager.currentStory.CurrentQuest);
            }
        }

        public void DisplayQuestInfo(Quest quest)
        {
            questName.text = quest.QuestSO.TitleValue;
            questDescription.text = quest.QuestSO.DescriptionValue;
            objectiveDescription.text = quest.QuestSO.ObjectivesValue;
            objectiveProgress.text = "";
            quest.QuestSO.Objectives.ForEach(o => objectiveProgress.text += o.CurrentAmount + "/" + o.RequiredAmount);
            questReward.text = quest.QuestSO.RewardValue.ToString();
        }
        
        public void OnAcceptQuest()
        {
            _gameManager.AcceptQuest();
            CloseQuest();
        }
        
        public void OnCompleteQuest()
        {
            _gameManager.NextQuest();
            CloseQuest();
        }
        
        /*public void OnDeclineQuest()
        {
            _gameManager.DeclineQuest();
        }*/
        
        public void OnExit()
        {
            CloseQuest();
        }
        
        public void CloseQuest()
        {
            gameObject.SetActive(false);
        }
        
    }
}