using UnityEngine;

namespace Background
{
    public class BackgroundLoop : MonoBehaviour
    {
        private const float Speed = 0.1f;
        private Vector2 _offset = Vector2.zero;
        private Material _material;
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");

        private void Start()
        {
            _material = GetComponent<Renderer>().material;
            _offset = _material.GetTextureOffset(MainTex);
        }
    
        private void Update()
        {
            _offset.y += Speed * Time.deltaTime;
            _material.SetTextureOffset(MainTex, _offset);
        }
    }
}