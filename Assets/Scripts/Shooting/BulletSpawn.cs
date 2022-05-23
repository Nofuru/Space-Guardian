using System.Collections;
using UnityEngine;

namespace Shooting
{
    public class BulletSpawn : MonoBehaviour
    {
        public static int bulletIndex = 0;
        [SerializeField] private Transform firePoint;
        private const float Delay = 0.15f;

        private BulletLoop _bullet;
        private void Start()
        {
            _bullet = BulletLoop.instance;
            StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            for(;;) 
            {
                BulletLoop.SpawnFromPool(bulletIndex, firePoint.position);
                yield return new WaitForSeconds(Delay);
            }
        }
    
    }
}
