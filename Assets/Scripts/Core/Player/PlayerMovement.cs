using System;
using LTX.ChanneledProperties;
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
        
        [Header("Crouch")]
        [SerializeField] private float crounchMultiplier = 0.5f;
        
        private bool isMoving;
        private Vector2 targetVelocity;
        
        // ChannelKey crouchkey = ChannelKey.GetUniqueChannelKey(); (créer une clée unique pour les channels)
        private void Awake()
        {
            CharacterController = GetComponent<CharacterController>();
        }
        private void FixedUpdate()
        {
            
            Vector3 forward = Vector3.ProjectOnPlane(GameCamera.Forward, transform.up).normalized;
            Vector3 right = Vector3.Cross(transform.up, forward).normalized;
            Vector3 velocity = forward * targetVelocity.y + right * targetVelocity.x;

            if (IsCrouching)
            {
                velocity *= crounchMultiplier;
            }
            
            bool isGrounded = CharacterController.SimpleMove(velocity * SPEED_MULTIPLIER);
            if (!isGrounded && IsCrouching)
            {
                IsCrouching = false;
            }
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
                IsCrouching = true;
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                IsCrouching = false;
            }
        }
    }
}