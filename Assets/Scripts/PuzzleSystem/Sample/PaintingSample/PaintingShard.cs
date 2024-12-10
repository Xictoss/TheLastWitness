using UnityEngine;

namespace PuzzleSystem.Sample.PaintingSample
{
    public class PaintingShard : MonoBehaviour
    {
        [SerializeField] private string paintingReferences;
        [SerializeField] private Collider paintingShardCollider;
        [SerializeField] private GameObject instructions;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                instructions.SetActive(true);
                var player = other.GetComponent<PaintingPlayer>();
                player.isInRange = true;
                player.shardInRange = this;
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                instructions.SetActive(false);
                var player = other.GetComponent<PaintingPlayer>();
                player.isInRange = false;
                player.shardInRange = null;
            }
        }
    }
}