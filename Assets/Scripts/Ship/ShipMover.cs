using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Ship
{
    public class ShipMover : MonoBehaviour
    {
        private ShipMover _instance;
        private Camera _cameraMain;
        private ShipMovement _touchInput;

        private void Awake()
        {
            _touchInput = new ShipMovement();
            _cameraMain = Camera.main;
            
            _instance = this;
        }

        private void Start()
        {
            StartCoroutine(Mover());
        }

        private void OnEnable()
        {
            _touchInput.Enable();
        }

        private void OnDisable()
        {
            _touchInput.Disable();
        }

        private IEnumerator Mover()
        {
            for (;;)
            {
                //Debug.Log(EventSystem.current.IsPointerOverGameObject());
                if (!EventSystem.current.IsPointerOverGameObject()) 
                    Move(_touchInput.Ship.Move.ReadValue<Vector2>());
                
                yield return new WaitForFixedUpdate();
            }
        }

        private void Move(Vector2 position)
        {
            var screenCoordinates = new Vector3(position.x, position.y, _cameraMain.nearClipPlane);
            var worldCoordinates = _cameraMain.ScreenToWorldPoint(screenCoordinates);
            worldCoordinates.z = 0;
            transform.position = worldCoordinates;
        }
    }
}