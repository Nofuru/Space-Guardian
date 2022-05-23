using LoadScenes;
using Enemies;
using UnityEngine;

namespace Ship
{
    public class OnShipTriggerEnterActions : MonoBehaviour
    {
        [SerializeField] private GameObject impactEffect;
        [SerializeField] private GameObject deathEffect;
        
        private int _health = 1000;
        private const int ShipDamageOnHit = 350;

        private void OnTriggerEnter(Collider hitInfo)
        {
            var enemy = hitInfo.GetComponent<OnEnemyTriggerEnterActions>();

            if (enemy != null)
            {
                TakeDamage(ShipDamageOnHit);
                enemy.Die();
                enemy.PerformActionsOnRam();
            }
            Instantiate(impactEffect, transform.position, transform.rotation);
        }

        private void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health > 0) return;
            Die();
            LoadGameOverScene.GameOverLoader();
        }
        
        private void Die()
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
