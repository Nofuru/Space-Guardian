using Enemies;
using UnityEngine;

namespace Shooting
{
    public class OnHitActions : MonoBehaviour
    {
        [SerializeField] private GameObject impactEffect;
        
        private const int Damage = 400;

        private void OnTriggerEnter(Collider hitInfo)
        {
            var enemy = hitInfo.GetComponent<OnEnemyTriggerEnterActions>();

            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
            }

            Instantiate(impactEffect, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}