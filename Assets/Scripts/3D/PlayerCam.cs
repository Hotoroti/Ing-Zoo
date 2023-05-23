using UnityEngine;

namespace Zoo3D
{
    public class PlayerCam : MonoBehaviour
    {
        //Sensitivity
        [SerializeField] private float _sensX;
        [SerializeField] private float _sensY;

        //Orientation of player
        [SerializeField] private Transform _orientation;

        //The rotation of camera
        private float _xRotation;
        private float _yRotation;

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            //Get mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _sensY;

            _yRotation += mouseX;
            _xRotation -= mouseY;
            //Can not look up and down more than 90 degrees
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            //Rotate cam and orientation
            transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
            _orientation.rotation = Quaternion.Euler(0, _yRotation, 0);
        }
    }
}
