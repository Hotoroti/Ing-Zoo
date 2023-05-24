using UnityEngine;
using UnityEngine.UI;

namespace Zoo
{
    class Zebra : MonoBehaviour
    {
        [SerializeField]
        private GameObject _balloon;
        [SerializeField]
        private Text _text;
        public string Name;


        public void SayHello()
        {
            _balloon.SetActive(true);
            _text.text = "zebra zebra";
        }

        public void EatLeaves()
        {
            _balloon.SetActive(true);
            _text.text = "munch munch zank yee bra";
        }
    }
}
