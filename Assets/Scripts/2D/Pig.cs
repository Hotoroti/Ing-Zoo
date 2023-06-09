﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Zoo
{
    class Pig : MonoBehaviour
    {
        public string Name;
        [SerializeField]
        private GameObject _balloon;
        [SerializeField]
        private Text _text;

        public void SayHello()
        {
            _balloon.SetActive(true);
            _text.text = "oink oink";
        }

        public void EatLeaves()
        {
            _balloon.SetActive(true);
            _text.text = "munch munch oink";
        }

        public void EatMeat()
        {
            _balloon.SetActive(true);
            _text.text = "nomnomnom oink thx";
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
