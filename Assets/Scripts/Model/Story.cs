using System.Collections.Generic;

namespace Kolman_Freecss.QuestSystem
{
    public class Story
    {
        public string Name;
        public string Description;
        public List<Quest> Quests;
        public Quest CurrentQuest;
        public List<Story> SubStories;
        public Story ParentStory;
        public bool IsCompleted;
        public bool IsMainStory;
        public bool IsSubStory;
        public bool IsUnlocked;
        public bool IsLocked;

        /**
         * Active the next quest by index of the story steps
         */
        public void NextQuest()
        {
            if (CurrentQuest == null)
            {
                CurrentQuest = Quests[0];
            }
            else
            {
                CurrentQuest = GetQuestByStoryStep(CurrentQuest.QuestSO.StoryStep + 1);
                CurrentQuest.ActiveQuest();
            }
        }

        private Quest GetQuestByStoryStep(int step)
        {
            return Quests.Find(q => q.QuestSO.StoryStep == step);
        }

        /**
         * Quantity of steps in the story
         */
        public int GetQuestSteps()
        {
            return Quests.Count;
        }

        public void AcceptQuest()
        {
            CurrentQuest.StartQuest();
        }

        public void Unlock()
        {
            IsUnlocked = true;
            IsLocked = false;
        }
    }
}