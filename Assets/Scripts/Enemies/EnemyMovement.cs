using UnityEngine;

namespace Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private float boost = 10f;

        private void FixedUpdate()
        {
            speed += boost;
            transform.position += new Vector3(0f, -speed * Time.fixedDeltaTime);
        }
    }
}
