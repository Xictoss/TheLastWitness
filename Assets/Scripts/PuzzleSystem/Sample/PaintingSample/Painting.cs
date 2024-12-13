using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PuzzleSystem.Sample.PaintingSample
{
    public class Painting : MonoBehaviour
    {
        [SerializeField] private int paintingReference;
        [SerializeField] private GameObject placeInsctruction;
        [SerializeField] private PaintingPlayer paintingPlayer;
        [SerializeField] public Transform paintingShardAnchor;
        private int currentShardReference;
        public bool isValid { get; private set; }

        public void PuzzleEnd()
        {
            
        }

        private void GetShardReference() 
        { 
            if(transform.childCount > 0)
                currentShardReference = transform.GetChild(0).GetComponent<PaintingShard>().shardReferences;
        }

        public bool CheckReferences()
        {
            GetShardReference();
            return currentShardReference == paintingReference;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && paintingPlayer.isHoldingShard)
            {
                placeInsctruction.SetActive(true);
                other.GetComponent<PaintingPlayer>().currentPaintingInRange = this;
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                placeInsctruction.SetActive(false);
                other.GetComponent<PaintingPlayer>().currentPaintingInRange = null;
            }
        }
        
    }
}