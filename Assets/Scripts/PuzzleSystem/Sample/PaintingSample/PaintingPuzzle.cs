using PuzzleSystem.Core;
using PuzzleSystem.Core.Interfaces;
using PuzzleSystem.Sample.TableauSample;
using UnityEngine;

namespace PuzzleSystem.Sample.PaintingSample
{
    public class PaintingPuzzle : Puzzle <PaintingContext>
    {
        [SerializeField] private Transform _door;
        
        
        public override void Begin(ref PaintingContext context)
        {
            
        }

        public override bool Refresh(ref PaintingContext context)
        {
            for (int i = 0; i < context.Paintings.Length; i++)
            {
                if (!context.Paintings[i].CheckReferences())
                {
                    return false;
                }
            }
            return true;
        }

        public override void End(ref PaintingContext context, bool isSuccess)
        {
            if (context.Paintings.Length > 0)
            {
                context.Paintings[3].PuzzleEnd();
            }
        }
    }
}