using DG.Tweening;
using UnityEngine;

namespace PuzzleSystem.Sample.TableauSample
{
    public class Tableau : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private GameObject instructions;
        
        public void PuzzleEnd(AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();

            Vector3 targetPos = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
            transform.parent.DOMove(targetPos, 1.5f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                instructions.SetActive(true);
                other.GetComponent<TableauPlayer>().isInRange = true;
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                instructions.SetActive(false);
                other.GetComponent<TableauPlayer>().isInRange = false;
            }
        }
    }
}