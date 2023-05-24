using System.Collections;
using UnityEngine;

namespace Zoo3D
{
    public class Animal : MonoBehaviour
    {
        [SerializeField] private GameObject _balloon;//The text balloon of the animal
        [SerializeField] private bool _canDoTrick;//Variable you check if you animal can do a trick

        private int _nParticleSystems; //The amount of particle systems the are for 1 animal

        private ParticleSystem[] _particles; //Array for all the particle systems
        private RandomMovement _randomMovement; //Reference to the RandomMovement script


        //Variables for state
        [HideInInspector] public bool IsJumping = false;
        [HideInInspector] public bool IsEating = false;

        // Start is called before the first frame update
        void Start()
        {
            //Adds the animal to the list of all animals
            Manager.Instance.AllAnimals.Add(this.gameObject);

            _randomMovement = GetComponent<RandomMovement>();

            //Get the amount of particle systems in the object
            _nParticleSystems = GetComponentsInChildren<ParticleSystem>().Length;

            //Initialize the array with n spots
            _particles = new ParticleSystem[_nParticleSystems];

            //Add the particle systems to the array
            _particles = GetComponentsInChildren<ParticleSystem>();
        }

        private void Update()
        {
            //Checks if animal is eating or jumping and set movementspeed to 0
            //If not keep walking
            if (IsEating || IsJumping)
            {
                _randomMovement.MovementSpeed = 0;
            }
            else if (!IsEating && !IsJumping)
            {
                _randomMovement.MovementSpeed = _randomMovement.StartMovementSpeed;
            }

            //Stops the particles from displaying when not eating
            if (!IsEating || IsJumping)
            {
                _particles[0].Stop();
                _particles[1].Stop();
            }
            //Sets the variables in the animator to the correct state
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
            //Rotate the animal in 360 degrees
            for (int i = 0; i < 360; i++)
            {
                transform.localRotation = Quaternion.Euler(0, i, 0);
                yield return new WaitForEndOfFrame();
            }
        }

    }
}