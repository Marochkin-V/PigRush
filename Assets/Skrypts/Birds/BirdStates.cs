using UnityEngine;

public class BirdStates : MonoBehaviour
{

    public bool isTouched;
    public bool isLaunched;
    public bool isReady;
    public bool inLauncher;
    public bool isCrashed;
    public bool abilityUsed;

    private void Start()
    {
        isTouched = false;
        isLaunched = false;
        isReady = false;
        inLauncher = false;
        isCrashed = false;
        abilityUsed = false;
    }

}
