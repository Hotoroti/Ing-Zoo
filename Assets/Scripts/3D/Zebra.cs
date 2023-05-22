using TMPro;
using UnityEngine;

namespace Zoo3D
{
    public class Zebra : Animal
    {
        [SerializeField] private TextMeshProUGUI _text;

        public override void SayHello()
        {
            base.SayHello();
            _text.text = "Ola Ola";
        }

        public override void EatLeave()
        {
            base.EatLeave();
            _text.text = "munch munch zank yee bra";
        }
    }
}
