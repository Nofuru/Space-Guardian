using UnityEngine;

namespace Destroyers
{
    public class DeathEffectDestroyer : MonoBehaviour
    {
        private const float TimeBeforeDestroy = 0.5f;
        private void Start()
        {
            Destroy(gameObject, TimeBeforeDestroy);
        }
    }
}
