using UnityEngine;
using UnityEngine.UI;

namespace Zoo
{
    class Hippo : MonoBehaviour
    {
        public string Name;
        [SerializeField]
        private GameObject _balloon;
        [SerializeField]
        private Text _text;

        public void SayHello()
        {
            _balloon.SetActive(true);
            _text.text = "splash";
        }

        public void EatLeaves()
        {
            _balloon.SetActive(true);
            _text.text = "munch munch lovely";
        }

        public void EatMeat()
        {
            _balloon.SetActive(true);
            _text.text = "munch munch lovely meat";
        }
    }

}
