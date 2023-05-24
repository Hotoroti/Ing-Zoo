using UnityEngine;

namespace Zoo
{
    class Spawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject lion, hippo, pig, tiger, zebra, giraffe, fox;
        private void Start()
        {
            Lion alex = Instantiate(lion, transform).GetComponent<Lion>();
            alex.Name = "alex";
            Hippo elsa = Instantiate(hippo, transform).GetComponent<Hippo>();
            elsa.name = "elsa";
            Pig dora = Instantiate(pig, transform).GetComponent<Pig>();
            dora.name = "dora";
            Tiger wally = Instantiate(tiger, transform).GetComponent<Tiger>();
            wally.Name = "wally";
            Zebra marty = Instantiate(zebra, transform).GetComponent<Zebra>();
            marty.Name = "marty";
            Giraffe melman = Instantiate(giraffe, transform).GetComponent<Giraffe>();
            melman.Name = "melman";
            Fox sweeper = Instantiate(fox, transform).GetComponent<Fox>();
            sweeper.Name = "sweeper";
        }
    }
}
