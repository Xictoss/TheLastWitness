using PuzzleSystem.Core;
using PuzzleSystem.Core.Interfaces;
using PuzzleSystem.Sample.TableauSample;
using TheLastWitness.Core.Menu;
using UnityEngine;
using TMPro;


namespace PuzzleSystem.Sample.PaintingSample
{
    public class PaintingPuzzleHandler : MonoBehaviour, IPuzzleHandler<PaintingContext>
    {
        public PaintingContext GetContext()
        {
            throw new System.NotImplementedException();
        }
    }
}