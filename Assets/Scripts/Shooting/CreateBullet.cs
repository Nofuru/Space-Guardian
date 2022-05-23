using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shooting
{
    public class CreateBullet : MonoBehaviour
    {
        [Serializable]
        public class Pool
        {
            public int bulletIndex;
            public GameObject preFab;
            public int size;
            
        }
        [SerializeField] private List<Pool> pools;

        public static int poolLength;

        public static Dictionary<int, Queue<GameObject>> bulletPoolDictionary;
        private void Awake()
        {
            poolLength = pools.Count;
            bulletPoolDictionary = new Dictionary<int, Queue<GameObject>>();

            foreach (var pool in pools)
            {
                var bulletPool = new Queue<GameObject>();

                for (var i = 0; i < pool.size; i++)
                {
                    var bullet = Instantiate(pool.preFab);
                    bullet.SetActive(false);
                    bulletPool.Enqueue(bullet);
                }

                bulletPoolDictionary.Add(pool.bulletIndex, bulletPool);
            }
        }
    }
}