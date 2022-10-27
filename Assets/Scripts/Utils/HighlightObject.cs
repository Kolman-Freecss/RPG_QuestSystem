using System.Linq;
using UnityEngine;

namespace Kolman_Freecss.QuestSystem
{
    public class HighlightObject : MonoBehaviour
    {
        public Color highlightColor = Color.yellow;
        public Color defaultColor = Color.white;
        public bool highlightOnMouseOver = true;
        
        public void Highlight()
        {
            if (gameObject.GetComponent<Renderer>() != null)
            {
                gameObject.GetComponent<Renderer>().material.color = highlightColor;
            }
            else
            {
                gameObject.GetComponentsInChildren<Renderer>().ToList().ForEach(r => r.material.color = highlightColor);
            }
        }
        
        public void UnHighlight()
        {
            if (gameObject.GetComponent<Renderer>() != null)
            {
                gameObject.GetComponent<Renderer>().material.color = defaultColor;
            }
            else
            {
                gameObject.GetComponentsInChildren<Renderer>().ToList().ForEach(r => r.material.color = defaultColor);
            }
        }
        
    }
}