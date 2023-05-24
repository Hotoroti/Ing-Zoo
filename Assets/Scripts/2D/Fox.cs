using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Zoo
{
    class Fox : MonoBehaviour
    {
        [SerializeField]
        private GameObject _balloon;
        [SerializeField]
        private Text _text;
        public string Name;


        public void SayHello()
        {
            _balloon.SetActive(true);
            _text.text = "What does the fox say";
        }

        public void EatMeat()
        {
            _balloon.SetActive(true);
            _text.text = "Nom Nom Nom Nom Nom";
        }

        public void PerformTrick()
        {
            StartCoroutine(DoTrick());
        }

        IEnumerator DoTrick()
        {
            for (int i = 0; i < 360; i++)
            {
                transform.localRotation = Quaternion.Euler(i, 0, 0);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
