using System;
using UnityEngine;
using Random = System.Random;

namespace Enemies
{
    public class EnemyLoop : MonoBehaviour
    {
        private readonly Random _random = new Random();

        private const int BottomBoundX = -2;
        private const int BottomBoundY = 6;
        private const int UpperBoundX = 2;
        private const int UpperBoundY = 8;

        #region Singleton

        public static EnemyLoop instance;
        private void Awake()
        {
            instance = this;
        }

        #endregion

        public GameObject SpawnFromPool(string enemyTag)
        {
            var randomPosition = new Vector3(_random.Next(BottomBoundX, UpperBoundX), _random.Next(BottomBoundY, UpperBoundY), 0);
            
            if (!CreateEnemy.enemyPoolDictionary.ContainsKey(enemyTag))
            {
                throw new IndexOutOfRangeException();
            }

            var enemyToSpawn = CreateEnemy.enemyPoolDictionary[enemyTag].Dequeue();

            enemyToSpawn.SetActive(true);
            enemyToSpawn.transform.position = randomPosition;

            CreateEnemy.enemyPoolDictionary[enemyTag].Enqueue(enemyToSpawn);

            return enemyToSpawn;
        }
    }
}
