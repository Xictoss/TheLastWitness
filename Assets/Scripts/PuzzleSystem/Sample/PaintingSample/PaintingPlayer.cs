using UnityEngine;
using UnityEngine.InputSystem;

namespace PuzzleSystem.Sample.PaintingSample
{
    public class PaintingPlayer : MonoBehaviour
    {
        [SerializeField] private Transform handPosition;
        private PaintingShard currentShardHolded;
        public PaintingShard shardInRange;
        public Painting currentPaintingInRange;
        
        [SerializeField] public bool isHoldingShard;
        public bool isInRange;
        
        public void OnTryToHold(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (!isHoldingShard && shardInRange != null)
                {
                    Debug.Log("attrape");
                    currentShardHolded = shardInRange;
                    currentShardHolded.transform.position = handPosition.position;
                    currentShardHolded.transform.parent = handPosition;
                    currentShardHolded.paintingShardRigidbody.isKinematic = true;
                    isHoldingShard = true;
                }
            }
        }
        
        
        
        public void OnTryToPaint(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (isHoldingShard && currentPaintingInRange != null)
                {
                    Debug.Log("Pose sur le tableau");
                    Debug.Log(currentShardHolded);
                    Debug.Log(currentPaintingInRange);
                    currentShardHolded.transform.position = currentPaintingInRange.paintingShardAnchor.transform.position;
                    currentShardHolded.transform.parent = currentPaintingInRange.paintingShardAnchor;
                    isHoldingShard = false;
                }
            }
        }
        
        public void OnDeposit(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (isHoldingShard)
                {
                    Debug.Log("lache");
                    currentShardHolded.paintingShardRigidbody.isKinematic = false;
                    isHoldingShard = false;
                    currentShardHolded.transform.parent = null;
                    currentShardHolded = null;
                }
            }
        }
        
    }
}