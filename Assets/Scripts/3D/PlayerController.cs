using UnityEngine;

namespace Zoo3D
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Speed Settings")]
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;

        [Header("Keybinds")]
        [SerializeField] private KeyCode _forwardMovementKey;
        [SerializeField] private KeyCode _backMovementKey;
        [SerializeField] private KeyCode _leftMovementKey;
        [SerializeField] private KeyCode _rightMovementKey;

        //Rotation variables
        private float _rotationSpeedH;
        private float _rotationSpeedV;
        private float _yaw;
        private float _pitch;

        //Other
        private Rigidbody _rig;
        private Camera _camera;

        // Start is called before the first frame update
        void Start()
        {
            _rig = GetComponent<Rigidbody>();
            _camera = Camera.main;

            //Set rotation values
            _rotationSpeedH = _rotationSpeed;
            _rotationSpeedV = _rotationSpeed;

            //Lock cursor to middle of screen
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            transform.forward = _camera.transform.forward;
            GroundCheck();
            Movement();
            Rotation();
        }

        void GroundCheck()
        {
            RaycastHit _hit;
            if (Physics.Raycast(transform.position, Vector3.down, out _hit, 1.2f, LayerMask.GetMask("Grounds")))
            {
                transform.position = new Vector3(transform.position.x, _hit.transform.position.y + 1f, transform.position.x);
                _rig.useGravity = false;
            }
            else
                _rig.useGravity = true;
        }

        void Movement()
        {
            if (Input.GetKey(_forwardMovementKey))
                transform.position += transform.forward * _movementSpeed * Time.deltaTime;
            if (Input.GetKey(_backMovementKey))
                transform.position += -transform.forward * _movementSpeed * Time.deltaTime;
            if (Input.GetKey(_rightMovementKey))
                transform.position += transform.right * _movementSpeed * Time.deltaTime;
            if (Input.GetKey(_leftMovementKey))
                transform.position += -transform.right * _movementSpeed * Time.deltaTime;
        }

        void Rotation()
        {
            _yaw += _rotationSpeedH * Input.GetAxis("Mouse X");
            _pitch -= _rotationSpeedV * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(_pitch, _yaw, 0);
        }
    }
}
