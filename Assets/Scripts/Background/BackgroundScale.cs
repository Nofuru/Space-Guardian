using UnityEngine;

namespace Background
{
    public class BackgroundScale : MonoBehaviour
    {
        private void Start()
        {
            if (Camera.main == null) return;
            var height = Camera.main.orthographicSize * 2f;
            var width = height * Screen.width / Screen.height;

            transform.localScale = gameObject.name == "Background" ? new Vector3(width, height, 0) : new Vector3(width + 3f, 5, 0);
        }

    }
}