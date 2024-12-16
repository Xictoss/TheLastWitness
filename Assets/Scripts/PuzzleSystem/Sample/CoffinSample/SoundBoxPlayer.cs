using UnityEngine;
using UnityEngine.InputSystem;

namespace PuzzleSystem.Sample.CoffinSample
{
    public class SoundBoxPlayer : MonoBehaviour
    {
        [SerializeField] private Transform handPosition;
        private Tape currentTapeHolded;
        public Tape TapeInRange;
        public SoundBox currentSoundBoxInRange;
        
        [SerializeField] public bool isHoldingTape;
        
        public void OnTryToHold(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (!isHoldingTape && TapeInRange != null)
                {
                    currentTapeHolded = TapeInRange;
                    currentTapeHolded.transform.position = handPosition.position;
                    currentTapeHolded.transform.parent = handPosition;
                    currentTapeHolded.tapeRigidbody.isKinematic = true;
                    isHoldingTape = true;
                }
            }
        }
        
        public void OnTryToPaint(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (isHoldingTape && currentTapeHolded != null && currentSoundBoxInRange != null)
                {
                    currentTapeHolded.transform.position = currentSoundBoxInRange.soundBoxTapeAnchor.transform.position;
                    currentTapeHolded.transform.parent = currentSoundBoxInRange.soundBoxTapeAnchor;
                    isHoldingTape = false;
                    currentTapeHolded = null;
                }
            }
        }
        
        public void OnDeposit(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (isHoldingTape)
                {
                    currentTapeHolded.tapeRigidbody.isKinematic = false;
                    isHoldingTape = false;
                    currentTapeHolded.transform.parent = null;
                    currentTapeHolded = null;
                }
            }
        }
    }
}