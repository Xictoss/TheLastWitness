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
        
        [Header("Code")]
        [SerializeField] private string codeToMatch;
        public TMP_InputField playerInput;
        
        [Header("Audio")]
        [SerializeField] private AudioClip audioClip;
        
        private TableauPuzzle puzzle;
        private bool isPuzzleActive;
        private bool isPuzzleDone;
        
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

        private void PuzzleState(IPuzzleRunner runner)
        {
            if (runner.Puzzle.GetType() == typeof(TableauPuzzle))
            {
                isPuzzleActive = !isPuzzleActive;
                menu.SwitchMenuState(isPuzzleActive ? MenuManager.MenuState.TableauInput : MenuManager.MenuState.None);

                if (!isPuzzleActive)
                {
                    isPuzzleDone = true;
                    instructions.SetActive(false);
                }
            }
        }
        
        private void Update()
        {
            if (isPuzzleDone) return;
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                puzzle = new TableauPuzzle(audioClip);
                PuzzleManager.Instance.StartPuzzle(puzzle, this);
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