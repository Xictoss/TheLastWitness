using TheLastWitness.Core.Camera;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TheLastWitness.Core.Player
{
    
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        private const float SPEED_MULTIPLIER = 1;
        public CharacterController CharacterController { get; private set; }
        public bool IsCrouching { get; private set; }
        
        [Header("Movement")]
        [SerializeField] private float speed = 8f;
        [SerializeField] private float sprintMultiplier = 2f;
        [SerializeField] private float acceleration = 16f;
        [SerializeField] private float deceleration = 32f;
        [Header("Physic")] 
        [SerializeField] private float gravity;
        [Header("Crouch")]
        [SerializeField] private float crounchMultiplier = 0.5f;
        [SerializeField] private float crouchHeight = 1.5f;

        
        private bool isMoving;
        private Vector2 targetVelocity;
        private float verticalVelocity;

        private float baseHeight;
        
        
        // ChannelKey crouchkey = ChannelKey.GetUniqueChannelKey(); (créer une clée unique pour les channels)
        private void Awake()
        {
            CharacterController = GetComponent<CharacterController>();
            baseHeight = CharacterController.height;
        }
        
        private void FixedUpdate()
        {
            verticalVelocity -= gravity * Time.deltaTime;
            
            Vector3 forward = Vector3.ProjectOnPlane(GameCamera.Forward, transform.up).normalized;
            Vector3 right = Vector3.Cross(transform.up, forward).normalized;
            Vector3 velocity = forward * targetVelocity.y + right * targetVelocity.x + Vector3.up * verticalVelocity;

            if (IsCrouching)
            {
                velocity *= crounchMultiplier;
            }
            
            CollisionFlags collisionFlags = CharacterController.Move(velocity * (SPEED_MULTIPLIER * Time.deltaTime));

            bool isGrounded = (collisionFlags & CollisionFlags.Below) != 0;
            
            if (isGrounded)
            {
                verticalVelocity = 0;
            }
            if (!isGrounded)
            {
                IsCrouching = false;
            }

            CharacterController.height = IsCrouching ? crouchHeight : baseHeight;
            float diff = CharacterController.height - baseHeight;
            CharacterController.center = new Vector3(0, diff * .5f, 0);

        }
        
        public void OnMoveInput(InputAction.CallbackContext context)
        {
            Vector2 input = context.ReadValue<Vector2>();
            //Debug.Log(input);

            isMoving = input.sqrMagnitude != 0;
            targetVelocity = input * speed;
        }

        public void OnCrouchInput(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                IsCrouching = !IsCrouching;
            }
        }
    }
}