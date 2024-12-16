using System;
using UnityEngine;

namespace PuzzleSystem.Sample.CoffinSample
{
    public class Tape : MonoBehaviour
    {
        [SerializeField] public int tapeReference;
        
        [Header("References")]
        [SerializeField] private GameObject instructions;
        [SerializeField] public Rigidbody tapeRigidbody;
        [SerializeField] private SoundBoxPlayer soundBoxPlayer;

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && soundBoxPlayer.isHoldingTape == false)
            {
                instructions.SetActive(true);
                var player = other.GetComponent<SoundBoxPlayer>();
                player.TapeInRange = this;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                instructions.SetActive(false);
                var player = other.GetComponent<SoundBoxPlayer>();
                player.TapeInRange = null;
            }
        }
    }
}