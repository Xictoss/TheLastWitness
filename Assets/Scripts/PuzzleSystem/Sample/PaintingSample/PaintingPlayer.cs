using UnityEngine;
using UnityEngine.InputSystem;

namespace PuzzleSystem.Sample.PaintingSample
{
    public class PaintingPlayer : MonoBehaviour
    {
        public bool isHoldingShard;
        public bool isInRange;
        public Transform handPosition;
        public PaintingShard shardInRange;

        private PaintingShard currentShard;
        
        private void OnTryToHold(InputAction.CallbackContext context)
        {
            if (!isHoldingShard && shardInRange != null)
            {
                shardInRange.transform.parent = handPosition;
                currentShard = shardInRange;
            }
        }

        private void OnDeposit(InputAction.CallbackContext context)
        {
            if (currentShard)
            {
                currentShard.transform.parent = null;
                currentShard = null;
            }
        }
    }
}