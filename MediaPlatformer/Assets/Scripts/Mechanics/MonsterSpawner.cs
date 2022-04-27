using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer.Mechanics
{
    public class MonsterSpawner : MonoBehaviour
    {
        public GameObject enemyToSpawn;
        public PatrolPath path;
        public int maxAmountOfEnemies = 5;
        public float timeBetweenEnemies = 10f;

        float elapsedTime = 0f;
        List<EnemyController> enemiesList;

        private void Awake()
        {
            enemiesList = new List<EnemyController>();
        }

        private void Update()
        {
            for (int i = 0; i < enemiesList.Count; i++)
            {
                if (enemiesList[i] == null || enemiesList[i]._collider.enabled == false)
                {
                    enemiesList.RemoveAt(i);
                    --i;
                }
            }

            elapsedTime += Time.deltaTime;

            if (elapsedTime >= timeBetweenEnemies)
            {
                elapsedTime = 0f;
                if (maxAmountOfEnemies <= 0 || enemiesList.Count < maxAmountOfEnemies)
                {
                    SpawnEnemy();
                }
            }
        }

        public void SpawnEnemy()
        {
            EnemyController enemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity, transform).GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemiesList.Add(enemy);
                enemy.path = path;
            }
        }
    }
}
