using System;
using System.Collections;
using UnityEngine;

namespace AI_Dino
{
    public class Player : MonoBehaviour
    {
        private static Player instance;

        [SerializeField]
        public static Player Instance
        {
            get => instance;
        }

        private LayerMask platformsLayerMask;
        public event EventHandler OnDied;

        public event EventHandler OnStartedPlaying;

        // private Player_Base playerBase;
        public Rigidbody2D rigidbody2d;
        public BoxCollider2D boxCollider2d;
        public bool waitForStart;
        public bool isDead;
        public float moveSpeed = 9f;
        public GameObject tapToPlay;
        private Animator _animator;
        private PlayerAgent _playerAgent;

        private void Awake()
        {
            instance = this;
            rigidbody2d = transform.GetComponent<Rigidbody2D>();
            boxCollider2d = transform.GetComponent<BoxCollider2D>();
            waitForStart = true;
            isDead = false;
        }

        private void Start()
        {
            tapToPlay.SetActive(true);
            rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
            GetComponent<Animator>().SetTrigger("started");
            _playerAgent = GetComponent<PlayerAgent>();
        }
    

        private void Update()
        {
            if (isDead) return;
            if (waitForStart)
            {
                HandleMovement();
            }

            gameObject.transform.rotation = Quaternion.identity;
        }

        private bool isgrounded = false;


        private void HandleMovement()
        {
            StartCoroutine(HandleSpeedCoroutine());
            rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
        }

        IEnumerator HandleSpeedCoroutine()
        {
            if (transform.position.x > 100)
            {
                moveSpeed = 10;
            }

            yield return new WaitForSeconds(0f);
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "enemy")
            {
                Die();
                _playerAgent.SetReward(-1);
                _playerAgent.EndEpisode();
            }
        }

        private void Die()
        {
            isDead = true;
            _playerAgent.OnEpisodeBegin();
        }

        public void Reset()
        {
            rigidbody2d.velocity = Vector2.zero;
            rigidbody2d.bodyType = RigidbodyType2D.Static;
            transform.position = Vector3.zero;
        }
    }
}