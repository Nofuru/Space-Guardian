using UnityEngine;

namespace Shooting
{
    public class BulletUpgrade : MonoBehaviour
    {
        private static readonly int MaxBulletIndex = CreateBullet.poolLength - 1;

        public static void Upgrade()
        {
            if (IsUpgradeAvailable())
            {
                BulletSpawn.bulletIndex += 1;
            }
            else
            {
                BulletSpawn.bulletIndex = MaxBulletIndex;
            }
        }
        
        private static bool IsUpgradeAvailable()
        {
            var tempBulletIndex = BulletSpawn.bulletIndex;
            return tempBulletIndex < MaxBulletIndex;
        }

    }
}
