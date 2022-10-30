using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Kolman_Freecss.QuestSystem
{
    public class RPG_QuestSystemInputs : MonoBehaviour
    {
        [Header("Mouse Cursor Settings")]
        public bool click;
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

        public void OnFire(InputValue value)
        {
            FireInput(value.isPressed);
        }

        public void FireInput(bool newFireState)
        {
            click = newFireState;
        }
        
    }
	
}