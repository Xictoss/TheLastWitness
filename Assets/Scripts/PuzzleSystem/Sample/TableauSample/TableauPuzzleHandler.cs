using PuzzleSystem.Core;
using PuzzleSystem.Core.Interfaces;
using TheLastWitness.Core.Menu;
using UnityEngine;
using TMPro;

namespace PuzzleSystem.Sample.TableauSample
{
    public class TableauPuzzleHandler : MonoBehaviour, IPuzzleHandler<TableauContext>
    {
        [Header("References")]
        [SerializeField] private Tableau tableau;
        [SerializeField] private GameObject instructions;
        [SerializeField] private MenuManager menu;
        [SerializeField] private TableauPlayer player;
        
        
        [Header("Code")]
        [SerializeField] private string codeToMatch;
        public TMP_InputField playerInput;
        
        [Header("Audio")]
        [SerializeField] private AudioClip audioClip;
        
        private TableauPuzzle puzzle;
        private bool isPuzzleActive;
        
        private void OnEnable()
        {
            PuzzleManager.Instance.OnPuzzleStarted += PuzzleState;
            PuzzleManager.Instance.OnPuzzleStopped += PuzzleState;
        }
        
        private void OnDisable()
        {
            PuzzleManager.Instance.OnPuzzleStopped -= PuzzleState;
            PuzzleManager.Instance.OnPuzzleStarted -= PuzzleState;
        }

        private void Start()
        {
            puzzle = new TableauPuzzle(audioClip);
            PuzzleManager.Instance.StartPuzzle(puzzle, this);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (isPuzzleActive && player.isInRange)
                {
                    if (menu.menuState == MenuManager.MenuState.TableauInput)
                    {
                        menu.SwitchMenuState(MenuManager.MenuState.None);
                        playerInput.text = "";
                    }
                    else if (menu.menuState == MenuManager.MenuState.None)
                    {
                        menu.SwitchMenuState(MenuManager.MenuState.TableauInput);
                    }
                }
            }
            
            //Debug.Log();
        }

        private void PuzzleState(IPuzzleRunner runner)
        {
            if (runner.Puzzle.GetType() == typeof(TableauPuzzle))
            {
                isPuzzleActive = !isPuzzleActive;

                if (!isPuzzleActive)
                {
                    menu.SwitchMenuState(MenuManager.MenuState.None);
                }
            }
        }
        
        public TableauContext GetContext()
        {
            return new TableauContext
            {
                tableau = tableau,
                codeToMatch = codeToMatch,
                playerCode = playerInput.text
            };
        }
    }
}