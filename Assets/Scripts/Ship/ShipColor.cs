using System.Collections.Generic;
using UnityEngine;

namespace Ship
{
    public class ShipColor : MonoBehaviour
    {
        public GameObject ship;
        [SerializeField] private List<Material> colors = new List<Material>();

        private void Start()
        {
            if (ColorKeeper.savedColor > 0)
            {
                ship.GetComponent<Renderer>().material = colors[ColorKeeper.savedColor];
            }
        }
    }
}
