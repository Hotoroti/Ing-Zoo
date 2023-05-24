using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Zoo
{
    class Tiger : MonoBehaviour
    {
        public string Name;
        [SerializeField]
        private GameObject _balloon;
        [SerializeField]
        private Text _text;


        public void SayHello()
        {
            _balloon.SetActive(true);
            _text.text = "rraaarww";
        }

        public void EatMeat()
        {
            _balloon.SetActive(true);
            _text.text = "nomnomnom thx wubalubadubdub";
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
