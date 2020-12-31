using UnityEngine;

namespace EndlessRunner.Scripts
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
