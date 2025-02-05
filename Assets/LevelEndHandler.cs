using UnityEngine;

public class LevelEndHandler : MonoBehaviour
{

    public void LevelCompleted()
    {
        Debug.Log("Level Completed! Score: " + Mathf.Round(ScoreManager.Score).ToString());
    }

    public void LevelFailed()
    {
        Debug.Log("Level Failed!");
    }
                
}
