using PuzzleSystem.Core.Data;
using UnityEngine;

namespace PuzzleSystem.Sample.RadioSample
{
    [CreateAssetMenu(menuName = "NomDuJeu/Puzzle/Radio")]
    public class RadioPuzzleData : PuzzleData
    {
        [SerializeField]
        private AudioClip successSound;

        public override void Begin()
        {

        }

        public override bool Refresh()
        {
            return RadioSetup.Instance.radio.HasBattery;
        }

        public override void End(bool isSuccess)
        {
            if (isSuccess)
            {
                RadioSetup.Instance.radio.PlayClip(successSound);
            }
        }
    }
}