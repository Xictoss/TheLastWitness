using PuzzleSystem.Core;
using PuzzleSystem.Core.Interfaces;
using PuzzleSystem.Sample.TableauSample;
using TheLastWitness.Core.Menu;
using UnityEngine;
using TMPro;


namespace PuzzleSystem.Sample.PaintingSample
{
    
    
    public class PaintingPuzzleHandler : MonoBehaviour, IPuzzleHandler<PaintingContext>
    {
        [Header("References")]
        [SerializeField] private GameObject instructions;
        [SerializeField] private Painting[] _paintings;
        [SerializeField] private PaintingShard[] _shards;
        
        private PaintingPuzzle puzzle;
        
        private void Start()
        {
            puzzle = new PaintingPuzzle();
            PuzzleManager.Instance.StartPuzzle(puzzle, this);
        }
        
        
        
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
        }
        
        public PaintingContext GetContext()
        {
            return new PaintingContext
            {
                Paintings = _paintings,
            };
        }
        
    }
}