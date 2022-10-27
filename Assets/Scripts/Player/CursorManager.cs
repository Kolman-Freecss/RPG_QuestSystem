using UnityEngine;

namespace Kolman_Freecss.QuestSystem
{
    public class CursorManager : MonoBehaviour
    {
        [Header("Cursor Settings")] public Texture2D defaultCursor;
        public Texture2D questNotStartedCursor;
        public Texture2D questStartedCursor;
        public Texture2D questCompletedCursor;

        Camera _currentCamera;
        GameObject _previousObject;

        private void Awake()
        {
            ResetCursor();
        }

        void Update()
        {
            if (!_currentCamera)
            {
                _currentCamera = Camera.main;
                return;
            }

            MousePosition();
        }

        void MousePosition()
        {
            RaycastHit info;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out info, 100, LayerMask.GetMask("NPC")))
            {
                HighlightGameObject(info);
                SetCursor(info);
            }
            else
            {
                UnHighlightGameObject();
                ResetCursor();
            }
        }

        private void ResetCursor()
        {
            Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
        }

        private void SetCursor(RaycastHit info)
        {
            QuestGiver qg = info.collider.gameObject.GetComponent<QuestGiver>();
            if (qg)
            {
                if (qg.CurrentQuest.IsStarted())
                {
                    Cursor.SetCursor(questStartedCursor, Vector2.zero, CursorMode.Auto);
                }
                else if (qg.CurrentQuest.IsCompleted())
                {
                    Cursor.SetCursor(questCompletedCursor, Vector2.zero, CursorMode.Auto);
                }
                else if (qg.CurrentQuest.IsNotStarted())
                {
                    Cursor.SetCursor(questNotStartedCursor, Vector2.zero, CursorMode.Auto);
                }
                else
                {
                    Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
                }
            }
        }

        /**
     * Highlights the game object that the mouse is hovering over
     */
        void HighlightGameObject(RaycastHit info)
        {
            if (_previousObject != info.collider.gameObject)
            {
                if (_previousObject)
                {
                    _previousObject.GetComponent<HighlightObject>().UnHighlight();
                }

                _previousObject = info.collider.gameObject;
            }
            else
            {
                HighlightObject infoHighlightObject = info.collider.gameObject.GetComponent<HighlightObject>();
                if (infoHighlightObject)
                {
                    infoHighlightObject.Highlight();
                }
            }
        }

        void UnHighlightGameObject()
        {
            if (_previousObject)
            {
                _previousObject.GetComponent<HighlightObject>().UnHighlight();
            }

            _previousObject = null;
        }
    }
}