using System;
using LTX.ChanneledProperties;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TheLastWitness.Core.Menu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject MainCanvas;
        [SerializeField] private GameObject[] PanelList;
        
        public MenuState menuState;
        public enum MenuState
        {
            None = -1,
            Pause = 0,
            Options = 1,
            
        }

        [SerializeField] private InputAction _inputAction;
        private void Awake()
        {
            _inputAction.performed += OnPausedInput;
            _inputAction.Enable();
        }

        private void OnPausedInput(InputAction.CallbackContext context)
        {
            
            if (menuState == MenuState.Options)
            {
                SwitchMenuState(MenuState.Pause);
            }
            else if (menuState == MenuState.Pause)
            {
                SwitchMenuState(MenuState.None);
            }
            else
            {
                SwitchMenuState(MenuState.Pause);
            }

            
        }

        public void OnStateSwitch(int index)
        {
            SwitchMenuState((MenuState) index);
        }

        private void SwitchMenuState(MenuState newMenuState)
        {
            for (int i = 0; i < PanelList.Length; i++)
            {
                PanelList[i].SetActive(false);
            }
            
            menuState = newMenuState;
            switch (menuState)
            {
                case MenuState.Pause:
                    MainCanvas.SetActive(true);
                    GameController.CursorVisibility.ChangeChannelPriority(this, PriorityTags.High);
                    GameController.CursorLockMode.ChangeChannelPriority(this, PriorityTags.High);
                    Time.timeScale = 0f;
                    break;
                case MenuState.Options:
                    break;
                case MenuState.None:
                    MainCanvas.SetActive(false);
                    GameController.CursorVisibility.ChangeChannelPriority(this, PriorityTags.None);
                    GameController.CursorLockMode.ChangeChannelPriority(this, PriorityTags.None);
                    Time.timeScale = 1f;

                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            PanelList[(int)menuState].SetActive(true);
        }

        private void OnEnable()
        {
            GameController.CursorVisibility.AddPriority(this, PriorityTags.None, true);
            GameController.CursorLockMode.AddPriority(this, PriorityTags.None, CursorLockMode.None);
        } 
        
        private void OnDisable()
        {
            //Enlever channel
            GameController.CursorVisibility.RemovePriority(this);
            GameController.CursorLockMode.RemovePriority(this);
        }

    }
}
