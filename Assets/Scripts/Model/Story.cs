using System.Collections.Generic;

namespace Kolman_Freecss.QuestSystem
{
    public class Story
    {
        string Name { get; set; }
        string Description { get; set; }
        List<Quest> Quests { get; set; }
        List<Story> SubStories { get; set; }
        Story ParentStory { get; set; }
        bool IsCompleted { get; set; }
        bool IsMainStory { get; set; }
        bool IsSubStory { get; set; }
        bool IsUnlocked { get; set; }
        bool IsLocked { get; set; }
        
        /**
         * Quantity of steps in the story
         */
        public int GetQuestSteps()
        {
            return Quests.Count;
        }
        
    }
}