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
            _questGivers = FindObjectsOfType<QuestGiver>().ToList();
        }

        private void Start()
        {
            storiesSO.ForEach(storySO =>
            {
                stories.Add(new Story(storySO));
            });
            //TODO : Add a way to choose the story
            currentStory = stories[0];
        }

        public void NextQuest()
        {
            currentStory.NextQuest();
            refreshQuestGivers();
        }
        
        void refreshQuestGivers()
        {
            _questGivers.Find(q => q.HasQuest(currentStory.CurrentQuest));
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