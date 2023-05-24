using UnityEngine;

namespace Zoo3D
{
    public class RandomMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed; //The movement speed of the animal

        private bool _isGrounded; //Bool for the animal to check if animal is on ground

        private Vector3 _tempPos; //The temporary pos for the animal to walk to
        private Vector3 _newPos; //The correct position for animal to walk to

        private Rigidbody _rig;
        public float MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }
        public float StartMovementSpeed; //The movementSpeed the animal started with
        public bool IsGrounded { get => _isGrounded; }

        public Animator Animator;
        // Start is called before the first frame update
        void Start()
        {
            StartMovementSpeed = _movementSpeed;
            _rig = GetComponent<Rigidbody>();
            GetNewPos();
        }

        // Update is called once per frame
        void Update()
        {
            //Sets the animator variable to the movementSpeed
            Animator.SetFloat("Idle Walk Run", _movementSpeed);

            //If animal reached the newPosition get a new position
            if (transform.position == _newPos)
                GetNewPos();
            else
            {
                //Moves the animal to the correct position
                transform.position = Vector3.MoveTowards(transform.position, _newPos, _movementSpeed * Time.deltaTime);

                FaceTarget();
            }

            //Ground check
            if (transform.position.y <= 0)
            {
                //Sets the animal on the ground
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                _isGrounded = true;
                _rig.velocity = Vector3.zero;
                _rig.useGravity = false;
            }
            else
            {
                _isGrounded = false;
                _rig.useGravity = true;
            }

        }

        private void FaceTarget()
        {
            //Get the direction animal need to look at
            Vector3 direction = (_newPos - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            //Changes the rotation of animal to the correct one
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
        private void GetNewPos()
        {
            //get the temporary pos inside a sphere
            _tempPos = Random.insideUnitSphere * Manager.Instance.Radius;
            //Sets the new position on the correct position on ground
            _newPos = new Vector3(_tempPos.x, 0, _tempPos.z);
        }
    }
}
