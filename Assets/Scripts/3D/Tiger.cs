using TMPro;
using UnityEngine;

namespace Zoo3D
{
    public class Tiger : Animal
    {
        [SerializeField] private TextMeshProUGUI _text;

        public override void SayHello()
        {
            base.SayHello();
            _text.text = "Oera Oera";
        }

        public override void EatMeat()
        {
            base.EatMeat();
            _text.text = "nomnomnom thx wubalubadubdub";
        }
    }
}
