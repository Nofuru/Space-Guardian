using System.Collections;
using UnityEngine;

namespace Enemies
{
    public class EnemySpawn : MonoBehaviour
    {
        private const float DelayBetweenSpawn = 1;
        private EnemyLoop _enemy;

        private void Start()
        {
            _enemy = EnemyLoop.instance;
            StartCoroutine(SpawnEnemy());
        } 
        private IEnumerator SpawnEnemy()
        {
            for(;;) 
            {
                yield return new WaitForSeconds(DelayBetweenSpawn);
                _enemy.SpawnFromPool("DefaultEnemy");
            }
        }
    }
}
