using LTX.ChanneledProperties;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TheLastWitness.Core.Player
{
    //Ne fonctionne que si le Script "playerMovement" est présent avec lui//
    [RequireComponent(typeof(PlayerMovement))]
    //-------------//
    public class PlayerController : MonoBehaviour
    {
        //création des variables pour le PlayerController
        public PlayerMovement PlayerMovement { get; private set; }
        public PlayerInput PlayerInput { get; private set; }
        public PlayerCamera PlayerCamera { get; private set; }
        //-------//

        private void Awake()
        {
            //récupérer les components du player
            PlayerMovement = GetComponent<PlayerMovement>();
            PlayerCamera = GetComponentInChildren<PlayerCamera>();
        }

        private void OnEnable()
        {
            //Ajout channel
            GameController.CursorVisibility.AddPriority(this, PriorityTags.Smallest, false);
            GameController.CursorLockMode.AddPriority(this, PriorityTags.Smallest, CursorLockMode.Locked);
        }

        private void OnDisable()
        {
            //Enlever channel
            GameController.CursorVisibility.RemovePriority(this);
            GameController.CursorLockMode.RemovePriority(this);
        }

        private void LateUpdate()
        {
            //alligné la joueur à la camera
            PlayerMovement.transform.forward = Vector3.ProjectOnPlane(PlayerCamera.transform.forward, Vector3.up);
        }
    }
}
