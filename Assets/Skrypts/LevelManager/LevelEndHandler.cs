using UnityEngine;

public class LevelEndHandler : MonoBehaviour
{

    [SerializeField] private GameObject EndLevelPanel;
    private EndLevelPanelsController endLevelPanelsController;

    private GameObject PigPool;
    private GameObject BirdPool;

    private void Start()
    {
        PigPool = GameObject.Find("PigPool");
        BirdPool = GameObject.Find("BirdPool");

        endLevelPanelsController = EndLevelPanel.GetComponent<EndLevelPanelsController>();
    }

    public void LevelCompleted()
    {
        CountBirds();
        Debug.Log("Level Completed! Score: " + Mathf.Round(ScoreManager.Score).ToString());
        endLevelPanelsController.LevelCompleted();
    }

    public void LevelFailed()
    {
        Debug.Log("Level Failed!");
        endLevelPanelsController.Defeat();
    }

    public void CheckResults()
    {
        if (PigPool.transform.childCount == 0)
        {
            LevelCompleted();
        }
        else
        {
            LevelFailed();
        }
    }
                
    private void CountBirds()
    {
        foreach (Transform child in BirdPool.transform)
        {
            if (child.TryGetComponent<BirdStates>(out BirdStates state))
            {
                if (!state.isLaunched)
                {
                    ScoreManager.AddScore(GlobalValues.BirdScoreAmount);
                    Debug.Log("Score Added by bird in pool");
                }
            }
        }
    }
}
