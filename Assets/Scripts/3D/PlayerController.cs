using UnityEngine;

namespace Zoo3D
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _movementSpeed;

        [SerializeField] private float _groundDrag;

        [Header("Ground Check")]
        [SerializeField] private float _playerHeight;
        [SerializeField] private LayerMask _whatIsGround;


        [SerializeField] private Transform _orientation;

        private float _horizontalInput;
        private float _verticalInput;

        private bool _isGrounded;

        private Vector3 _moveDirection;

        private Rigidbody _rig;

        private void Start()
        {
            _rig = GetComponent<Rigidbody>();
            _rig.freezeRotation = true;
        }

        private void Update()
        {
            //Ground check
            _isGrounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight / 2 + .2f, _whatIsGround);

            MyInput();
            SpeedControl();

            //Handle drag
            if (_isGrounded)
                _rig.drag = _groundDrag;
            else
                _rig.drag = 0;
        }

        private void FixedUpdate()
        {
            if (_isGrounded)
                MovePlayer();
        }
        private void MyInput()
        {
            //Get the inputs for movement
            _horizontalInput = Input.GetAxisRaw("Horizontal");
            _verticalInput = Input.GetAxisRaw("Vertical");
        }

        private void MovePlayer()
        {
            //Calculate movement direction
            _moveDirection = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;

            //Moves the player int the direction with the speed
            _rig.AddForce(_moveDirection * _movementSpeed, ForceMode.Force);
        }

        private void SpeedControl()
        {
            //The velocity the rigidbody has at the moment
            Vector3 flatVel = new Vector3(_rig.velocity.x, 0, _rig.velocity.z);

            //Limit velocity if needed
            if (flatVel.magnitude > _movementSpeed)
            {
                //Calculate what max velocity should be
                Vector3 limitedVel = flatVel.normalized * _movementSpeed;
                //Sets the velocity to the limited velocity
                _rig.velocity = new Vector3(limitedVel.x, _rig.velocity.y, limitedVel.z);
            }

        }
    }
}
