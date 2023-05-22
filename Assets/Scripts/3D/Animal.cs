using System.Collections;
using UnityEngine;

namespace Zoo3D
{
    public class Animal : MonoBehaviour
    {
        [SerializeField] private GameObject _balloon;
        [SerializeField] private bool _canDoTrick;

        private ParticleSystem[] _particles;
        private int _nSystems;

        // Start is called before the first frame update
        void Start()
        {
            Manager.Instance.AllAnimals.Add(this.gameObject);
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
            _particles[1].Play();
        }

        public virtual void EatLeave()
        {
            _balloon.SetActive(true);
            _particles[0].Play();
        }

        public virtual void DoTrick()
        {
            if (_canDoTrick)
                StartCoroutine(Trick());
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