using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kolman_Freecss.QuestSystem
{
    public class GameManager : MonoBehaviour
    {
        public List<StorySO> storiesSO = new List<StorySO>();
        private List<Story> stories = new List<Story>();
        private static GameManager _instance;
        public Story currentStory;
        private List<QuestGiver> _questGivers = new List<QuestGiver>();
        
        void Awake()
        {
            ManageSingleton();
        }

        private void Start()
        {
            _questGivers = FindObjectsOfType<QuestGiver>().ToList();
            storiesSO.ForEach(storySO =>
            {
                stories.Add(new Story(storySO));
            });
            //TODO : Add a way to choose the story
            currentStory = stories[0];
            currentStory.StartStory();
            RefreshQuestGivers();
        }

        private void Update()
        {
            // ONLY!! Use it like hack to test the quest system            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currentStory.CurrentQuest.objectives[0].isCompleted)
                {
                    CompleteQuest();
                }
                else
                {
                    currentStory.CurrentQuest.objectives[0].UpdateAmount(1);
                }
            }
        }

        public void CompleteQuest()
        {
            UpdateStatusGiverByQuestId(currentStory.CurrentQuest.ID);
            currentStory.CompleteQuest();
            RefreshQuestGivers();
        }

        /**
         * Update the current story and the status of the current quest giver
         */
        public void AcceptQuest()
        {
            UpdateStatusGiverByQuestId(currentStory.CurrentQuest.ID);
            currentStory.AcceptQuest();
        }

        /**
         * Update the current story and the next quest givers
         */
        public void NextQuest()
        {
            UpdateStatusGiverByQuestId(currentStory.CurrentQuest.ID);
            currentStory.NextQuest();
            RefreshQuestGivers();
        }
        
        /**
         * Update the current quest of the quest givers
         */
        public Quest UpdateStatusGiverByQuestId(int questId)
        {
            return GetQuestGiverByQuestId(questId).CurrentQuest.UpdateStatus();
        }
        
        /**
         * Refresh the quest givers that are on the current steps in the current story 
         */
        void RefreshQuestGivers()
        {
            QuestGiver qg = GetQuestGiverByQuestId(currentStory.CurrentQuest.ID);
            if (qg != null)
            {
                qg.RefreshQuest(currentStory.CurrentQuest.ID);
            }
        }
        
        QuestGiver GetQuestGiverByQuestId(int questId)
        {
            return _questGivers.Find(q => q.HasQuest(questId));
        }
        
        void ManageSingleton()
        {
            if (_instance != null)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        
    }
}