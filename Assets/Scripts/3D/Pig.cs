using TMPro;
using UnityEngine;

namespace Zoo3D
{
    public class Pig : Animal
    {
        [SerializeField] private TextMeshProUGUI _text;

        public override void SayHello()
        {
            base.SayHello();
            _text.text = "Knorr Knorr";
        }

        public override void EatLeave()
        {
            base.EatLeave();
            _text.text = "Munch Munch Oink";
        }
    }
}
