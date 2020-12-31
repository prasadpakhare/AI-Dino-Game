using System;
using UnityEngine;

namespace EndlessRunner.Scripts {

    /*
     * Script to handle Camera Movement and Zoom
     * Place on Camera GameObject
     * */
    public class CameraFollow : MonoBehaviour {

        private Camera myCamera;
        private Func<Vector3> GetCameraFollowPositionFunc;
        private Func<float> GetCameraZoomFunc;
        public Player player;

        // public void Setup(Func<Vector3> GetCameraFollowPositionFunc, Func<float> GetCameraZoomFunc, bool teleportToFollowPosition, bool instantZoom) {
        //     this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
        //     this.GetCameraZoomFunc = GetCameraZoomFunc;
        //
        //     if (teleportToFollowPosition) {
        //         Vector3 cameraFollowPosition = GetCameraFollowPositionFunc();
        //         cameraFollowPosition.z = transform.position.z;
        //         transform.position = cameraFollowPosition;
        //     }
        //
        //     if (instantZoom) {
        //         // myCamera.orthographicSize = GetCameraZoomFunc();
        //     }
        // }

        private void Start() {
            myCamera = transform.GetComponent<Camera>();
        }

        private void FixedUpdate()
        {
            float offset = player.transform.position.x + 3;
            transform.position = new Vector3(offset, transform.position.y, transform.position.z);
        }

        // public void SetCameraFollowPosition(Vector3 cameraFollowPosition) {
        //     SetGetCameraFollowPositionFunc(() => cameraFollowPosition);
        // }
        //
        // public void SetGetCameraFollowPositionFunc(Func<Vector3> GetCameraFollowPositionFunc) {
        //     this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
        // }
        //
        // private void Update() {
        //     HandleMovement();
        // }
        //
        // private void HandleMovement() {
        //     if (GetCameraFollowPositionFunc == null) return;
        //     Vector3 cameraFollowPosition = GetCameraFollowPositionFunc();
        //     cameraFollowPosition.z = transform.position.z;
        //
        //     Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
        //     float distance = Vector3.Distance(cameraFollowPosition, transform.position);
        //     float cameraMoveSpeed = 3f;
        //
        //     if (distance > 0) {
        //         Vector3 newCameraPosition = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;
        //
        //         float distanceAfterMoving = Vector3.Distance(newCameraPosition, cameraFollowPosition);
        //
        //         if (distanceAfterMoving > distance) {
        //             // Overshot the target
        //             newCameraPosition = cameraFollowPosition;
        //         }
        //
        //         transform.position = newCameraPosition;
        //     }
        // }
    }

}