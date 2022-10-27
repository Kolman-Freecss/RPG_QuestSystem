using System.Collections.Generic;
using UnityEngine;

namespace Kolman_Freecss.QuestSystem
{
    [CreateAssetMenu(fileName = "New Story", menuName = "Quest System/Story")]
    public class StorySO : ScriptableObject
    {
        public int id;
        public new string name;
        public string description;
        public List<QuestSO> quests;
        public List<StorySO> SubStories;
        public StorySO ParentStory;
        public bool isMainStory;
        public bool isSubStory;
    }
}