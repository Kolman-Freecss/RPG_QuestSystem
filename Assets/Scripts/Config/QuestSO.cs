using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kolman_Freecss.QuestSystem
{
    [CreateAssetMenu(fileName = "New Quest", menuName = "Quest System/Quest")]
    public class QuestSO : ScriptableObject
    {
        [FormerlySerializedAs("title")] [SerializeField]
        string _title;

        public string TitleValue
        {
            get => _title;
        }

        [FormerlySerializedAs("description")] [TextArea(2, 6)] [SerializeField]
        string _description;

        public string DescriptionValue
        {
            get => _description;
        }

        [FormerlySerializedAs("_objectives")] [FormerlySerializedAs("objectives")] [TextArea(2, 6)] [SerializeField]
        string _objectiveText;

        public string ObjectivesValue
        {
            get => _objectiveText;
        }
        
        [FormerlySerializedAs("objectives")] [SerializeField]
        List<Objective> _objectives;
        
        public List<Objective> Objectives
        {
            get => _objectives;
        }
        
        [FormerlySerializedAs("storyStep")] [SerializeField]
        int _storyStep;
        
        public int StoryStep
        {
            get => _storyStep;
        }

        // Implement your rewards here. By default it will add Reward model inside the component
        [FormerlySerializedAs("reward")] [SerializeField]
        Reward _reward;

        public Reward RewardValue
        {
            get => _reward;
        }

        public int storyId;


    }
}