using PuzzleSystem.Core.Interfaces;

namespace PuzzleSystem.Sample.CoffinSample
{
    public struct SoundBoxContext : IPuzzleContext
    {
        public Tape[] Tapes;
        public SoundBox[] SoundBox;
    }
}