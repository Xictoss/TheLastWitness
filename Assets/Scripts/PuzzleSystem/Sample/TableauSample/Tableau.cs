using DG.Tweening;
using UnityEngine;

namespace PuzzleSystem.Sample.TableauSample
{
    public class Tableau : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        
        public void PuzzleEnd(AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();

            Vector3 targetPos = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
            transform.DOMove(targetPos, 1.5f);
        }
    }
}