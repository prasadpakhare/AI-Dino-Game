using UnityEngine;

namespace EndlessRunner.Scripts
{
    public class GameHandler_Setup : MonoBehaviour {

        [SerializeField] private CameraFollow cameraFollow;
        [SerializeField] private Player player;

        private void Start() {
            // cameraFollow.Setup(GetCameraPosition, () => 10f, true, true);
        }

        private Vector3 GetCameraPosition() {
            return player.GetPosition() + new Vector3(5, 0);
        }

    }
}
