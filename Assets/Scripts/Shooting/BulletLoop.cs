using System;
using UnityEngine;

namespace Shooting
{
    public class BulletLoop : MonoBehaviour
    {
        #region Singleton

        public static BulletLoop instance;
        private void Awake()
        {
            instance = this;
        }

        #endregion

        public static GameObject SpawnFromPool(int bulletIndex, Vector3 position)
        {
            if (!CreateBullet.bulletPoolDictionary.ContainsKey(bulletIndex))
            {
                throw new IndexOutOfRangeException();
            }

            var bulletToSpawn = CreateBullet.bulletPoolDictionary[bulletIndex].Dequeue();

            bulletToSpawn.SetActive(true);
            bulletToSpawn.transform.position = position;

            CreateBullet.bulletPoolDictionary[bulletIndex].Enqueue(bulletToSpawn);

            return bulletToSpawn;
        }
    }
}
