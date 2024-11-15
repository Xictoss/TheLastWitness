using System;
using LTX.Singletons;
using PuzzleSystem.Core;
using UnityEngine;

namespace PuzzleSystem.Sample.RadioSample
{
    public class RadioSetup : MonoSingleton<RadioSetup>
    {
        [SerializeField]
        public Radio radio;
        [SerializeField]
        public Battery battery;
        [SerializeField]
        public PlayerExample player;

        [SerializeField]
        private RadioPuzzleData puzzleData;

        private Puzzle puzzle;

        /// <summary>
        /// Creation puzzle
        /// </summary>
        private void Start()
        {
            puzzle = new Puzzle(puzzleData);

            PuzzleManager.Instance.StartPuzzle(puzzle);
        }

        /// <summary>
        /// Quelque chose a changé
        /// </summary>
        public void SetDirty()
        {
            puzzle.SetDirty();
        }
    }
}