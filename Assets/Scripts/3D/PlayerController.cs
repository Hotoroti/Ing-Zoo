using UnityEngine;

namespace Zoo3D
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Speed Settings")]
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;


        //Rotation variables
        private float _rotationSpeedH;
        private float _rotationSpeedV;
        private float _yaw = 0.0f;
        private float _pitch = 0.0f;

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
            if (Physics.Raycast(transform.position, Vector3.down, out _hit, 1.2f, LayerMask.GetMask("Ground")))
            {
                Debug.Log("Hit ground");
                transform.position = new Vector3(transform.position.x, _hit.transform.position.y + 1f, transform.position.x);
                _rig.useGravity = false;
            }
            else
                _rig.useGravity = true;
        }

        void Movement()
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * _movementSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += -transform.forward * _movementSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * _movementSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += -transform.right * _movementSpeed * Time.deltaTime;
            }
        }

        void Rotation()
        {
            _yaw += _rotationSpeedH * Input.GetAxis("Mouse X");
            _pitch -= _rotationSpeedV * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(_pitch, _yaw, 0);
        }
    }
}
