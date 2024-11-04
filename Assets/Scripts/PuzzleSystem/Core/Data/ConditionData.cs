using UnityEngine;

namespace PuzzleSystem.Core.Data
{
    public abstract class ConditionData : ScriptableObject
    {
        public abstract bool IsComplete();
    }
}