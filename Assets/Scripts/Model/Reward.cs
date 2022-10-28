using UnityEngine;

namespace Kolman_Freecss.QuestSystem
{
    [System.Serializable]
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

        public override string ToString()
        {
            return string.Format("Gold: {0}, Exp: {1}", _gold, _exp);
        }
    }
}