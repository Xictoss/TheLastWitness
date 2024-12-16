using System;
using DG.Tweening;
using UnityEngine;

namespace PuzzleSystem.Sample.CoffinSample
{
    public class SoundBox : MonoBehaviour
    {
        [SerializeField] private int soundBoxReference;
        [SerializeField] private GameObject placeInsctruction;
        [SerializeField] private SoundBoxPlayer soundBoxPlayer;
        [SerializeField] public Transform soundBoxTapeAnchor;
        
        [SerializeField] private Transform door;
        [SerializeField] private Collider doorCollider;
        
        private int currentTapeReference;
        
        private void OnTriggerEnter(Collider other)
        {
            
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && soundBoxPlayer.isHoldingTape)
            {
                placeInsctruction.SetActive(true);
                other.GetComponent<SoundBoxPlayer>().currentSoundBoxInRange = this;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                placeInsctruction.SetActive(false);
                other.GetComponent<SoundBoxPlayer>().currentSoundBoxInRange = null;
            }
        }

        public void PuzzleEnd()
        {
            doorCollider.enabled = false;
            
            Vector3 targetPos = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z + 2f);
            door.DOMove(targetPos, .2f);
        }

        public bool CheckReferences()
        {
            GetTapeReference(); 
            return currentTapeReference == soundBoxReference;
        }
        private void GetTapeReference()
        {
            if(transform.childCount > 0)
                currentTapeReference = transform.GetChild(0).GetComponent<Tape>().tapeReference;
        }

    }
}