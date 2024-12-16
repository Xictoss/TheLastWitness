using System;
using PuzzleSystem.Core;
using PuzzleSystem.Core.Interfaces;
using UnityEngine;

namespace PuzzleSystem.Sample.CoffinSample
{
    public class SoundBoxPuzzleHandler : MonoBehaviour, IPuzzleHandler<SoundBoxContext>
    {
        [Header("References")]
        [SerializeField] private Tape[] _tapes;
        [SerializeField] private SoundBox[] _soundBox;
        
        private SoundBoxPuzzle _soundBoxPuzzle;
        public SoundBoxContext GetContext()
        {
            return new SoundBoxContext
            {
                Tapes = _tapes,
                SoundBox = _soundBox,
            };
        }

        private void Start()
        {
            _soundBoxPuzzle = new SoundBoxPuzzle();
            PuzzleManager.Instance.StartPuzzle(_soundBoxPuzzle, this);

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