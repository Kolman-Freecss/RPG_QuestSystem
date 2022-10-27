using System.Collections.Generic;
using UnityEngine;

namespace Kolman_Freecss.QuestSystem
{
    public class GameManager : MonoBehaviour
    {
        public List<Story> stories = new List<Story>();
        private static GameManager _instance;
        public Story currentStory;
        
        void Awake()
        {
            ManageSingleton();
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