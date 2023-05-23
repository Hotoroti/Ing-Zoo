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

        public virtual void SayHello()
        {
            _balloon.SetActive(true);
        }

        public virtual void EatMeat()
        {
            _balloon.SetActive(true);
            StartCoroutine(Eat());
            _particles[1].Play();
        }

        public virtual void EatLeave()
        {
            _balloon.SetActive(true);
            StartCoroutine(Eat());
            _particles[0].Play();
        }

        public virtual void DoTrick()
        {
            if (_canDoTrick)
                StartCoroutine(Trick());
        }

        IEnumerator Eat()
        {
            float oldspeed = _randomMovement.MovementSpeed;
            _randomMovement.MovementSpeed = 0;

            for (int i = 0; i < 3; i++)
            {

                Debug.Log(gameObject.name + _particles.Length);
                _rig.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

                yield return new WaitForSeconds(4 / 2f);
            }

            _randomMovement.MovementSpeed = oldspeed;
        }
        IEnumerator Trick()
        {
            for (int i = 0; i < 360; i++)
            {
                transform.localRotation = Quaternion.Euler(0, i, 0);
                yield return new WaitForEndOfFrame();
            }
        }

    }
}