using UnityEngine;

public class PigPoolChecker : MonoBehaviour
{
    [SerializeField] private LevelEndHandler levelEndHandler;

    private bool isActive;

    private void Start()
    {
        levelEndHandler = GameObject.Find("GameManager").GetComponent<LevelEndHandler>();

        isActive = true;
    }

    void Update()
    {
        if (isActive)
        {
            if (gameObject.transform.childCount == 0)
            {
                Invoke("CheckResults", 3f);
                isActive = false;
            }
        }
    }

    private void CheckResults()
    {
        levelEndHandler.CheckResults();
    }
}
