using UnityEngine;

namespace PuzzleSystem.Core.Data
{
    public abstract class PuzzleData : ScriptableObject
    {
        [field: SerializeField]
        public string PuzzleName { get; private set; }

        public abstract void Begin();

        public abstract bool Refresh();

        public abstract void End(bool isSuccess);


        public Puzzle ToPuzzle()
        {
            return new Puzzle(this);
        }
    }
}