using System;
using UnityEngine;

namespace PuzzleSystem.Sample.RadioSample
{
    public class PlayerExample : MonoBehaviour
    {
        private Battery battery;

        private void Update()
        {
            // Ramasser
            if (Input.GetKeyDown(KeyCode.A))
            {
                battery = RadioSetup.Instance.battery;
            }

            // Donner
            if (Input.GetKeyDown(KeyCode.Z))
            {
                RadioSetup.Instance.radio.SetBattery(battery);
                battery = null;
            }

        }
    }
}