using UnityEngine;
using UnityEngine.UI;

namespace Zoo
{
    class Giraffe : MonoBehaviour
    {
        [SerializeField]
        private GameObject _balloon;
        [SerializeField]
        private Text _text;
        public string Name;


        public void SayHello()
        {
            _balloon.SetActive(true);
            _text.text = "giraffe giraffe";
        }

        public void EatLeaves()
        {
            _balloon.SetActive(true);
            _text.text = "delicious delicous, yum yum";
        }
    }
}