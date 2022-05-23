using UnityEngine;

namespace Destroyers
{
    public class ImpactEffectDestroyer : MonoBehaviour
    {
        private const float TimeBeforeDestroy = 0.05f;
        private void Start()
        {
            Destroy(gameObject, TimeBeforeDestroy);
        }
    }
}
