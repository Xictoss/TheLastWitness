using PuzzleSystem.Core;
using UnityEngine;

namespace PuzzleSystem.Sample.TableauSample
{
    public class TableauPuzzle : Puzzle<TableauContext>
    {
        private AudioClip audioClip;

        public TableauPuzzle(AudioClip audioClip)
        {
            this.audioClip = audioClip;
        }
        
        public override void Begin(ref TableauContext context)
        {
            
        }

        public override bool Refresh(ref TableauContext context)
        {
            return context.playerCode == context.codeToMatch;
        }

        public override void End(ref TableauContext context, bool isSuccess)
        {
            context.tableau.PuzzleEnd(audioClip);
        }
    }
}