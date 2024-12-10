using PuzzleSystem.Core.Interfaces;
using PuzzleSystem.Sample.TableauSample;

namespace PuzzleSystem.Sample.PaintingSample
{
    public struct PaintingContext : IPuzzleContext
    {
        public Painting[] Paintings;
        public PaintingShard[] PaintingShards;

    }
}