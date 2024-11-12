using UnityEngine;
using UnityEngine.InputSystem;

namespace TheLastWitness.Core.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        private Vector2 targetCamVelocity;
        
        [SerializeField] private Vector2 crouchHeadHeight;
        [SerializeField] private float crouchSmoothness;

        //création des variables//
        // [SerializeField,Range(0,20)] private float deceleration;
        [SerializeField] private float speed;
        [SerializeField, Range(0,1)] private float xModifier = 1;
        [SerializeField, Range(0,1)] private float yModifier = 1;
        [SerializeField] private int minY = -80;
        [SerializeField] private int maxY = 80;
        [SerializeField] private Transform head;

        private PlayerController playerController;
        //------//
        private void Awake()
        {
            playerController = GetComponentInParent<PlayerController>();
        }

        private void Start()
        {
            //sortir la cam du player//
            transform.SetParent(null);
        }

        private void Update()
        {
            //empeche la cam de dépasser en haut et en bas (pas de back/frontflips mdr)
            float x = transform.eulerAngles.x + targetCamVelocity.x * speed;
            if (x >= 180)
                x -= 360;
            //--------//
            
            x = Mathf.Clamp(x, minY, maxY);
            float y = transform.eulerAngles.y + targetCamVelocity.y * speed;
            transform.eulerAngles = new Vector3(x, y);
            // float xSpeed = Mathf.LerpAngle();
            // targetCamVelocity = Vector2.Lerp(Vector2.zero, targetCamVelocity, deceleration * Time.deltaTime);
            // Debug.Log(targetCamVelocity);
            float targetHeight = crouchHeadHeight.x;
            
            if (playerController.PlayerMovement.IsCrouching)
            {
                targetHeight = crouchHeadHeight.y;
            }

            Vector3 vector3 = head.localPosition;
            vector3.y = Mathf.Lerp(targetHeight,head.localPosition.y,crouchSmoothness * Time.deltaTime);
            head.localPosition = vector3;
            
        }

        // recuperer l'input du joueur et l'ajouter au vector 2 en y et en x //
        public void OnLookX(InputAction.CallbackContext context)
        {
            targetCamVelocity.y = context.ReadValue<float>() * xModifier;
        }

        public void OnLookY(InputAction.CallbackContext context)
        {
            targetCamVelocity.x = context.ReadValue<float>() * yModifier;
        }
        //--------//
    }
}