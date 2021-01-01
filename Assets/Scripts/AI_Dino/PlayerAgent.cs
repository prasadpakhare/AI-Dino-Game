using System;
using Unity.MLAgents;
using UnityEngine;

namespace AI_Dino
{
    public class PlayerAgent : Agent
    {
        [SerializeField] private LevelCreator levelCreator;
        private Player player;
        private Vector3 startPos;
        private bool isJumpReady = false;
        private const float JUMP_AMOUNT = 35f;
        [SerializeField] private KeyCode jump;

        public override void Initialize()
        {
            player = GetComponent<Player>();
            startPos = player.transform.position;
            player.OnDied += PlayerDied;
        }

        public override void OnActionReceived(float[] actions)
        {
            // if (Math.Abs(actions[0] - 1) < Mathf.Epsilon) // 0 is doing nothing and 1 is Jump
            //     Jump();
            if ((Mathf.FloorToInt(actions[0]) == 1) && isJumpReady) // 0 is doing nothing and 1 is Jump
            {
                Jump();
            }
        }

        private void Jump()
        {
            if (isJumpReady)
            {
                player.rigidbody2d.velocity = Vector2.up * JUMP_AMOUNT;
            }
        }

        public override void OnEpisodeBegin()
        {
            //Reset Game
            Reset();
        }

        public override void Heuristic(float[] actionsOut)
        {
            actionsOut[0] = 0;
            if (Input.GetKey(jump))
                actionsOut[0] = 1;
        }

        private void PlayerDied(object sender, EventArgs e)
        {
        
        }




        private void OnCollisionStay2D(Collision2D other)
        {
            if (player.boxCollider2d.IsTouching(other.collider) && other.collider.name == "platform")
            {
                isJumpReady = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (!player.boxCollider2d.IsTouching(other.collider) && other.collider.name == "platform")
            {
                isJumpReady = false;
            }
        }

    
        private void FixedUpdate()
        {
            if (isJumpReady)
            {
                RequestDecision();
            }

            AddReward(0.0001f);
        }

        private void Reset()
        {
            player.transform.position = startPos;
            player.rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
            isJumpReady = true;
            player.isDead = false;
        }
    }
}