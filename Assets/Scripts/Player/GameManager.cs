using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kolman_Freecss.QuestSystem
{
    public class GameManager : MonoBehaviour
    {
        public List<Story> stories = new List<Story>();
        private static GameManager _instance;
        public Story currentStory;
        public List<QuestGiver> questGivers = new List<QuestGiver>();
        
        void Awake()
        {
            ManageSingleton();
            questGivers = FindObjectsOfType<QuestGiver>().ToList();
        }

        public void NextQuest()
        {
            currentStory.NextQuest();
            refreshQuestGivers();
        }
        
        void refreshQuestGivers()
        {
            questGivers.Find(q => q.HasQuest(currentStory.CurrentQuest));
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