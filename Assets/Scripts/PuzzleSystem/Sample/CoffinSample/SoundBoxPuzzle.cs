using PuzzleSystem.Core;
using UnityEngine;

namespace PuzzleSystem.Sample.CoffinSample
{
    public class SoundBoxPuzzle : Puzzle<SoundBoxContext>
    {
        public override void Begin(ref SoundBoxContext context)
        {
        }

        public override bool Refresh(ref SoundBoxContext context)
        {
            for (int i = 0; i < context.SoundBox.Length; i++)
            {
                if (!context.SoundBox[i].CheckReferences())
                {
                    return false;
                }
            }
            return true;
        }

        public override void End(ref SoundBoxContext context, bool isSuccess)
        {
            if (context.SoundBox.Length > 0)
            {
                Debug.Log("on termine");
                context.SoundBox[2].PuzzleEnd();
            }
        }
    }
}