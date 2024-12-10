using System;
using UnityEngine;

namespace PuzzleSystem.Sample.PaintingSample
{
    public class Painting : MonoBehaviour
    {
        
        [SerializeField] private GameObject instructions;
        [SerializeField] private PaintingPlayer paintingPlayer;

        private bool isHoldingShard;

        private void Awake()
        {
            bool isHoldingShard = paintingPlayer.isHoldingShard;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && isHoldingShard)
            {
                instructions.SetActive(true);
                other.GetComponent<PaintingPlayer>().isInRange = true;
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                instructions.SetActive(false);
                other.GetComponent<PaintingPlayer>().isInRange = false;
            }
        }
    }
}