using UnityEngine;

namespace Zoo3D
{
    public class RandomMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        private bool _isGrounded;

        private Vector3 _tempPos;
        private Vector3 _newPos;

        private Rigidbody _rig;
        public float MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }
        public float StartMovementSpeed;
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
            Animator.SetFloat("Idle Walk Run", _movementSpeed);
            if (transform.position == _newPos)
                GetNewPos();
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _newPos, _movementSpeed * Time.deltaTime);

                FaceTarget();
            }

            if (transform.position.y <= 0)
            {
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
            Vector3 direction = (_newPos - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
        private void GetNewPos()
        {
            _tempPos = Random.insideUnitSphere * Manager.Instance.Radius;
            _newPos = new Vector3(_tempPos.x, 0, _tempPos.z);
        }
    }
}
