/* 
    ------------------- Code Monkey -------------------
    
    Thank you for downloading the Code Monkey Utilities
    I hope you find them useful in your projects
    If you have any questions use the contact form
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using UnityEngine;

namespace EndlessRunner.Scripts {
    
    public class CameraFollowSetup : MonoBehaviour {

        [SerializeField] private CameraFollow cameraFollow;
        [SerializeField] private Transform followTransform;
        [SerializeField] private float zoom;

        private void Start() {
            if (followTransform == null) {
                Debug.LogError("followTransform is null! Intended?");
                // cameraFollow.Setup(() => Vector3.zero, () => zoom, true, true);
            } else {
                // cameraFollow.Setup(() => followTransform.position, () => zoom, true, true);
            }
        }
    }

}