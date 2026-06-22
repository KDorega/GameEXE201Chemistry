//using UnityEngine;
//using UnityEngine.InputSystem;

//public class ShowInfoAfterReaction : MonoBehaviour
//{
//    public ReactionFrames reactionFrames;

//    void Update()
//    {
//        if (Mouse.current.leftButton.wasPressedThisFrame)
//        {
//            Vector2 mousePos =
//                Camera.main.ScreenToWorldPoint(
//                    Mouse.current.position.ReadValue()
//                );

//            RaycastHit2D hit =
//                Physics2D.Raycast(mousePos, Vector2.zero);

//            if (
//                hit.collider != null &&
//                hit.collider.gameObject == gameObject &&
//                reactionFrames.reactionFinished
//            )
//            {
//                reactionFrames.infoButton.SetActive(true);
//            }
//        }
//    }
//}