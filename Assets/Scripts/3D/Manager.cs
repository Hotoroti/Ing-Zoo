using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Zoo3D
{
    public class Manager : MonoBehaviour
    {
        #region Singleton
        public static Manager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        #endregion

        [SerializeField] private EventSystem _eventSystem;
        [SerializeField] private GameObject _setObject;

        [SerializeField] private float _radius;
        [SerializeField] private TMP_InputField _input;

        private List<Animal> _animalScript = new List<Animal>();

        public float Radius { get => _radius; }
        public List<GameObject> AllAnimals = new List<GameObject>();

        private void Update()
        {
            if (_eventSystem.currentSelectedGameObject == null)
                _eventSystem.SetSelectedGameObject(_setObject);
        }

        void GetAllAnimals()
        {
            foreach (GameObject obj in AllAnimals)
                _animalScript.Add(obj.GetComponent<Animal>());
        }

        void GetAnimalOnName(string name)
        {
            foreach (GameObject obj in AllAnimals)
            {
                if (name == "")
                {
                    _animalScript.Add(obj.GetComponent<Animal>());
                }
                else if (obj.CompareTag(name))
                {
                    _animalScript.Add(obj.GetComponent<Animal>());
                }
            }
        }

        void GetAnimalOnGroup(string group)
        {
            foreach (GameObject obj in AllAnimals)
                if (obj.layer == LayerMask.NameToLayer(group))
                    _animalScript.Add(obj.GetComponent<Animal>());
        }

        public void AnimalSayHello()
        {
            GetAnimalOnName(_input.text);
            foreach (Animal script in _animalScript)
                script.SayHello();

            _animalScript.Clear();
        }

        public void AnimalDoTrick()
        {
            GetAllAnimals();
            foreach (Animal script in _animalScript)
                script.DoTrick();

            _animalScript.Clear();
        }

        public void AnimalEatLeave()
        {
            GetAnimalOnGroup("Herbivore");
            GetAnimalOnGroup("Omnivore");
            foreach (Animal script in _animalScript)
                script.EatLeave();

            _animalScript.Clear();
        }

        public void AnimalEatMeat()
        {
            GetAnimalOnGroup("Carnivore");
            GetAnimalOnGroup("Omnivore");
            foreach (Animal script in _animalScript)
                script.EatMeat();

            _animalScript.Clear();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Radius);
        }
    }
}
