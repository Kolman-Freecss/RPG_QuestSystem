using System.Collections.Generic;

namespace Kolman_Freecss.QuestSystem
{
    public class Story
    {
        public int id;
        public string Name;
        public string Description;
        public List<Quest> Quests = new List<Quest>();
        public Quest CurrentQuest;
        public List<Story> SubStories = new List<Story>();
        public Story ParentStory;
        public bool IsCompleted;
        public bool IsMainStory;
        public bool IsSubStory;
        public bool IsUnlocked;
        public bool IsLocked;

        public Story(StorySO storySo)
        {
            id = storySo.id;
            Name = storySo.name;
            Description = storySo.description;
            //TODO Add id Strategy
            storySo.quests.ForEach(x => Quests.Add(new Quest(x, x.StoryStep)));
            storySo.SubStories.ForEach(x => SubStories.Add(new Story(x)));
            IsCompleted = false;
            IsMainStory = storySo.isMainStory;
            IsSubStory = storySo.isSubStory;
            IsUnlocked = false;
            IsLocked = false;
        }

        public void StartStory()
        {
            NextQuest();
        }

        public Quest CompleteQuest()
        {
            CurrentQuest.UpdateStatus();
            if (CurrentQuest.IsCompleted())
            {
                NextQuest();
            }

            return CurrentQuest;
        }

        public void CompleteStory()
        {
            IsCompleted = true;
        }
        
        public bool UpdateQuestObjectiveAmount(int amount)
        {
            return CurrentQuest.UpdateQuestObjectiveAmount(amount);
        }
        
        /*public bool UpdateQuestObjectiveAmount(int questId, int amount)
        {
        }*/

        /*public void UpdateQuestObjectiveAmount(int objectiveId, int amount)
        {
            
        }*/
        
        /**
         * Active the next quest by index of the story steps
         */
        public Quest NextQuest()
        {
            if (CurrentQuest == null)
            {
                CurrentQuest = GetQuestByStoryStep(0);
            }
            else
            {
                CurrentQuest = GetQuestByStoryStep(CurrentQuest.storyStep + 1);
            }

            return CurrentQuest;
        }

        private Quest GetQuestByStoryStep(int step)
        {
            return Quests.Find(q => q.storyStep == step);
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