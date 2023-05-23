using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform _cameraPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = _cameraPosition.position;
    }
}
