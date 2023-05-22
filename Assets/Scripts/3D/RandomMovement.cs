using UnityEngine;

namespace Zoo3D
{
    public class RandomMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;

        private Vector3 _tempPos;
        private Vector3 _newPos;

        // Start is called before the first frame update
        void Start()
        {
            GetNewPos();
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position == _newPos)
                GetNewPos();
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _newPos, _movementSpeed * Time.deltaTime);
                FaceTarget();
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
