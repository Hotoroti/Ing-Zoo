using System.Collections;
using UnityEngine;

namespace Zoo3D
{
    public class Animal : MonoBehaviour
    {
        [SerializeField] private GameObject _balloon;
        [SerializeField] private bool _canDoTrick;

        private int _nSystems;

        private float _jumpForce = 2;

        private ParticleSystem[] _particles;
        private RandomMovement _randomMovement;
        private Rigidbody _rig;

        [HideInInspector]
        public bool IsJumping = false;
        public bool IsEating = false;

        // Start is called before the first frame update
        void Start()
        {
            Manager.Instance.AllAnimals.Add(this.gameObject);
            _randomMovement = GetComponent<RandomMovement>();
            _rig = GetComponent<Rigidbody>();
            _nSystems = GetComponentsInChildren<ParticleSystem>().Length;
            _particles = new ParticleSystem[_nSystems];
            _particles = GetComponentsInChildren<ParticleSystem>();
        }

        private void Update()
        {
            if (IsEating || IsJumping)
            {
                _randomMovement.MovementSpeed = 0;
            }
            else if (!IsEating && !IsJumping)
            {
                _randomMovement.MovementSpeed = _randomMovement.StartMovementSpeed;
            }

            if (!IsEating || IsJumping)
            {
                _particles[0].Stop();
                _particles[1].Stop();
            }
            _randomMovement.Animator.SetBool("IsEating", IsEating);
            _randomMovement.Animator.SetBool("IsJumping", IsJumping);
        }
        public virtual void SayHello()
        {
            _balloon.SetActive(true);
        }

        public virtual void EatMeat()
        {
            _balloon.SetActive(true);
            IsEating = true;
            _particles[1].Play();
        }

        public virtual void EatLeave()
        {
            _balloon.SetActive(true);
            IsEating = true;
            _particles[0].Play();
        }

        public virtual void DoTrick()
        {
            if (_canDoTrick)
                StartCoroutine(Trick());
        }

        IEnumerator Trick()
        {
            _randomMovement.MovementSpeed = 0;
            for (int i = 0; i < 360; i++)
            {
                transform.localRotation = Quaternion.Euler(0, i, 0);
                yield return new WaitForEndOfFrame();
            }
            _randomMovement.MovementSpeed = _randomMovement.StartMovementSpeed;
        }

    }
}