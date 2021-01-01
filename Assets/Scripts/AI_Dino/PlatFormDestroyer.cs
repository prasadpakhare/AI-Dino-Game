using UnityEngine;

namespace AI_Dino
{
    public class PlatFormDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.name == "platform")
            {
                Destroy(other.gameObject);
            }
        }
    }
}
