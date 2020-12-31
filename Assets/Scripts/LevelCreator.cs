using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EndlessRunner.Scripts
{
    public class LevelCreator : MonoBehaviour
    {
        private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 100f;

        [SerializeField] private Transform levelPart_Start;
        [SerializeField] private List<Transform> levelPartList;
        [SerializeField] private Player player;
        [SerializeField] private GameObject enemy;

        private Vector3 lastEndPosition;

        private void Start()
        {
            Invoke("Init", 3);
        }

        public void Init()
        {
            lastEndPosition = levelPart_Start.Find("EndPosition").position;

            int startingSpawnLevelParts = 5;
            for (int i = 0; i < startingSpawnLevelParts; i++)
            {
                SpawnLevelPart();
            }

            SpawnLevelPart();
        }

        private void Update()
        {
            if (Vector3.Distance(player.GetPosition(), lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
            {
                // Spawn another level part
                SpawnLevelPart();
            }
        }

        private void SpawnLevelPart()
        {
            Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
            Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
            lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        }

        private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
        {
            Transform levelPartTransform =
                Instantiate(levelPart, new Vector3(spawnPosition.x, -2, 0), Quaternion.identity);
            Instantiate(enemy, new Vector3(spawnPosition.x + Random.Range(10, 20), -1, 0), Quaternion.identity);
            return levelPartTransform;
        }

        public float GetEnemyXPosition()
        {
            return enemy.transform.position.x;
        }
    }
}