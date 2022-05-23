using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class CreateEnemy : MonoBehaviour
    {
        [Serializable]
        public class Pool
        {
            public string enemyTag;
            public GameObject preFab;
            public int size;
        }
        
        public List<Pool> pools;

        public static Dictionary<string, Queue<GameObject>> enemyPoolDictionary;
        private void Awake()
        {
            enemyPoolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (var pool in pools)
            {
                var enemyPool = new Queue<GameObject>();

                for (var i = 0; i < pool.size; i++)
                {
                    var enemy = Instantiate(pool.preFab);
                    enemy.SetActive(false);
                    enemyPool.Enqueue(enemy);
                }

                enemyPoolDictionary.Add(pool.enemyTag, enemyPool);
            }
        }


    }
}
