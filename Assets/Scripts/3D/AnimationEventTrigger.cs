using UnityEngine;
using Zoo3D;

public class AnimationEventTrigger : MonoBehaviour
{
    private Animal _animal;

    private void Start()
    {
        _animal = GetComponentInParent<Animal>();
    }
    //This method is called in the eat animation when event is reached
    public void GoToJumpAnimation()
    {
        _animal.IsJumping = true;
        _animal.IsEating = false;
    }

    //This method is called in the jump animation when event is reached
    public void GoToWalkIng()
    {
        _animal.IsJumping = false;
        _animal.IsEating = false;
    }
}
