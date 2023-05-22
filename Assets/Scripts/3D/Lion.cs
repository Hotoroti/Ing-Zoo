using TMPro;
using UnityEngine;

namespace Zoo3D
{
    public class Lion : Animal
    {
        [SerializeField] private TextMeshProUGUI _text;

        public override void SayHello()
        {
            base.SayHello();
            _text.text = "Yo yo";
        }

        public override void EatMeat()
        {
            base.EatMeat();
            _text.text = "nomnomnom thanks mate";
        }
    }
}
