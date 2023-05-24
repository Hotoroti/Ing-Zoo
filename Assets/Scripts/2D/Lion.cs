﻿using UnityEngine;
using UnityEngine.UI;

namespace Zoo
{
    class Lion : MonoBehaviour
    {
        [SerializeField]
        private GameObject _balloon;
        [SerializeField]
        private Text _text;
        public string Name;


        public void SayHello()
        {
            _balloon.SetActive(true);
            _text.text = "roooaoaaaaar";
        }

        public void EatMeat()
        {
            _balloon.SetActive(true);
            _text.text = "nomnomnom thx mate";
        }
    }
}
