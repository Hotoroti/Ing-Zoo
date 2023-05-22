using TMPro;
using UnityEngine;

namespace Zoo3D
{
    public class Hippo : Animal
    {
        [SerializeField] private TextMeshProUGUI _text;

        public override void SayHello()
        {
            base.SayHello();
            _text.text = "Gutten Tag";
        }

        public override void EatLeave()
        {
            base.EatLeave();
            _text.text = "Munch Munch Lovely";
        }

        public override void EatMeat()
        {
            base.EatMeat();
            _text.text = "Munch Munch Lovely meat";
        }
    }
}
