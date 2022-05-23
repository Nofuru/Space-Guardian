using UnityEngine;

namespace Shooting
{
    public class BulletMovement : MonoBehaviour
    {
        private WaitForSeconds _waitBeforeNextMove = new WaitForSeconds(0.01f);
        private const float Speed = 15f;

        private void FixedUpdate()
        {
            transform.position += new Vector3(0f, Speed * Time.fixedDeltaTime);
        }
    }
}
