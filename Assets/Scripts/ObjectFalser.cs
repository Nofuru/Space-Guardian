using UnityEngine;

public class ObjectFalser : MonoBehaviour
{
    private GameObject _object;

    private void OnTriggerEnter(Collider other)
    {
        _object = other.gameObject;
        
        _object.SetActive(false);
    }
}
