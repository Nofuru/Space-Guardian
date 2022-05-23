using UnityEngine;

namespace Enemies
{
    public class OnEnemyTriggerEnterActions : MonoBehaviour
    {
        [SerializeField] private GameObject deathEffect;

        private const float PointsForKill = 1024;
        private int _health = 1500;
        private ScoreCounter _score;
        private Wallet _wallet;

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health > 0) return;
            Die();
            PerformActionsOnKIll();
        }
        
        public void PerformActionsOnRam()
        {
            _score.AddPoints(PointsForKill);
            _wallet.AddMoney(_wallet.defaultEnemyPricePerRam);
            _wallet.ShowOnScreen();
        }

        public void Die()
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            _health = 1000;
            gameObject.SetActive(false);
        }

        private void PerformActionsOnKIll()
        {
            _score.AddPoints(PointsForKill);
            _wallet.AddMoney(_wallet.defaultEnemyPrice);
            _wallet.ShowOnScreen();
            _wallet.AddKillPoint(_wallet.defaultEnemyValue);
            _wallet.CheckForBulletUpgrade();
        }

        private void Start()
        {
            _score = ScoreCounter.instance;
            _wallet = Wallet.instance;
        }
    }
}