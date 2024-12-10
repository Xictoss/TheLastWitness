using PuzzleSystem.Core;
using PuzzleSystem.Core.Interfaces;
using PuzzleSystem.Sample.TableauSample;

namespace PuzzleSystem.Sample.PaintingSample
{
    public class PaintingPuzzle : Puzzle <PaintingContext>
    {
        
        
        
        public override void Begin(ref PaintingContext context)
        {
            
        }

        public override bool Refresh(ref PaintingContext context)
        {
            throw new System.NotImplementedException();
        }

        public override void End(ref PaintingContext context, bool isSuccess)
        {
            throw new System.NotImplementedException();
        }
    }
}