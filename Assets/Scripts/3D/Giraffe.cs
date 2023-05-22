using TMPro;
using UnityEngine;

namespace Zoo3D
{
    public class Giraffe : Animal
    {
        [SerializeField] private TextMeshProUGUI _text;

        public override void SayHello()
        {
            base.SayHello();
            _text.text = "Hi Hi";
        }

        public override void EatLeave()
        {
            base.EatLeave();
            _text.text = "Delicious Delicious, yum, yum";
        }
    }
}
