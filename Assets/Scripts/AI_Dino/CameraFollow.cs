using System;
using UnityEngine;

namespace AI_Dino {
    
    public class CameraFollow : MonoBehaviour {

        private Camera myCamera;
        public Player player;
        

        private void Start() {
            myCamera = transform.GetComponent<Camera>();
        }

        private void FixedUpdate()
        {
            float offset = player.transform.position.x + 3;
            transform.position = new Vector3(offset, transform.position.y, transform.position.z);
        }
        
    }

}