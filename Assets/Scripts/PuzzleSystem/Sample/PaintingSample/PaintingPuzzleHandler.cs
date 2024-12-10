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
        [SerializeField] private Painting _painting1;
        [SerializeField] private Painting _painting2;
        [SerializeField] private Painting _painting3;
        [SerializeField] private Painting _painting4;
        
        private PaintingPuzzle puzzle;
        
        private void Start()
        {
            puzzle = new PaintingPuzzle();
            PuzzleManager.Instance.StartPuzzle(puzzle, this);
        }
        
        public PaintingContext GetContext()
        {
            return new PaintingContext
            {
                Painting1 = _painting1,
                Painting2 = _painting2,
                Painting3 = _painting3,
                Painting4 = _painting4
            };
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
        
    }
}