using UnityEngine;
using UnityEngine.UI;
using Zoo;

public class Manager : MonoBehaviour
{
    private GameObject _pigObj;
    private GameObject _hippoObj;
    private GameObject _lionObj;
    private GameObject _tigerObj;
    private GameObject _zebraObj;
    private GameObject _giraffeObj;
    private GameObject _foxObject;

    private Pig _pigScript;
    private Zebra _zebraScript;
    private Lion _lionScript;
    private Tiger _tigerScript;
    private Hippo _hippoScript;
    private Giraffe _giraffeScript;
    private Fox _foxScript;

    [SerializeField] private InputField _nameInput;

    void GetFox()
    {
        _foxObject = GameObject.FindWithTag("Fox");
        _foxScript = _foxObject.GetComponent<Fox>();
    }
    void GetGiraffe()
    {
        _giraffeObj = GameObject.FindWithTag("Giraffe");
        _giraffeScript = _giraffeObj.GetComponent<Giraffe>();
    }
    void GetZebra()
    {
        _zebraObj = GameObject.FindWithTag("Zebra");
        _zebraScript = _zebraObj.GetComponent<Zebra>();
    }
    void GetTiger()
    {
        _tigerObj = GameObject.FindWithTag("Tiger");
        _tigerScript = _tigerObj.GetComponent<Tiger>();
    }
    void GetLion()
    {
        _lionObj = GameObject.FindWithTag("Lion");
        _lionScript = _lionObj.GetComponent<Lion>();
    }
    void GetHippo()
    {
        _hippoObj = GameObject.FindWithTag("Hippo");
        _hippoScript = _hippoObj.GetComponent<Hippo>();
    }
    void GetPig()
    {
        _pigObj = GameObject.FindWithTag("Pig");
        _pigScript = _pigObj.GetComponent<Pig>();
    }
    public void AllHerbivoresEat()
    {
        GetPig();
        GetHippo();
        GetZebra();
        GetGiraffe();

        _pigScript.EatLeaves();
        _hippoScript.EatLeaves();
        _zebraScript.EatLeaves();
        _giraffeScript.EatLeaves();
    }
    public void AllCarnivoresEat()
    {
        GetLion();
        GetTiger();
        GetHippo();
        GetFox();
        _foxScript.EatMeat();
        _hippoScript.EatMeat();
        _lionScript.EatMeat();
        _tigerScript.EatMeat();
    }
    public void AllAnimalsDoTricks()
    {
        GetPig();
        GetTiger();
        GetFox();
        _foxScript.PerformTrick();
        _tigerScript.PerformTrick();
        _pigScript.PerformTrick();
    }
    public void OneAnimalSayHello()
    {
        GetPig();
        GetTiger();
        GetZebra();
        GetLion();
        GetHippo();
        GetGiraffe();
        GetFox();
        string animalName = _nameInput.text;
        if (animalName.ToLower() == "pig") _pigScript.SayHello();
        else if (animalName.ToLower() == "lion") _lionScript.SayHello();
        else if (animalName.ToLower() == "zebra") _zebraScript.SayHello();
        else if (animalName.ToLower() == "tiger") _tigerScript.SayHello();
        else if (animalName.ToLower() == "hippo") _hippoScript.SayHello();
        else if (animalName.ToLower() == "giraffe") _giraffeScript.SayHello();
        else if (animalName.ToLower() == "fox") _foxScript.SayHello();
        else
        {
            _tigerScript.SayHello();
            _hippoScript.SayHello();
            _pigScript.SayHello();
            _lionScript.SayHello();
            _zebraScript.SayHello();
            _giraffeScript.SayHello();
            _foxScript.SayHello();
        }
    }
}

