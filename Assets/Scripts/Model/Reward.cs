using UnityEngine;

namespace Kolman_Freecss.QuestSystem
{
    public class Reward
    {
        [SerializeField] int _gold;

        public int Gold
        {
            get { return _gold; }
        }

        [SerializeField] int _exp;

        public int Exp
        {
            get { return _exp; }
        }
    }
}