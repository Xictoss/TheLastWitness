using PuzzleSystem.Core;
using PuzzleSystem.Core.Interfaces;

namespace PuzzleSystem.Sample.TableauSample
{
    public struct TableauContext : IPuzzleContext
    {
        public Tableau tableau;
        public string codeToMatch;
        public string playerCode;
    }
}