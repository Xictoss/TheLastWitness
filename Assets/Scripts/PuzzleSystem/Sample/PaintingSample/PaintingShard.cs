using UnityEngine;

namespace PuzzleSystem.Sample.PaintingSample
{
    public class PaintingShard : MonoBehaviour
    {
        public int shardReferences;
        [SerializeField] private Collider paintingShardCollider;
        [SerializeField] public Rigidbody paintingShardRigidbody;
        [SerializeField] private GameObject instructions;
        [SerializeField] private PaintingPlayer paintingPlayer;
        
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && paintingPlayer.isHoldingShard == false)
            {
                instructions.SetActive(true);
                var player = other.GetComponent<PaintingPlayer>();
                player.shardInRange = this;
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                instructions.SetActive(false);
                var player = other.GetComponent<PaintingPlayer>();
                player.shardInRange = null;
            }
        }
    }
}