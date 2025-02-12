using UnityEngine;

public class EndLevelPanelsController : MonoBehaviour
{
    [SerializeField] private GameObject BirdsWinElements;
    [SerializeField] private GameObject PigsWinElements;

    //private void Start()
    //{
    //    gameObject.SetActive(false);
    //    BirdsWinElements.SetActive(false);
    //    PigsWinElements.SetActive(false);
    //}

    public void LevelCompleted()
    {
        gameObject.SetActive(true);
        BirdsWinElements.SetActive(true);
        PigsWinElements.SetActive(false);
        BirdsWinElements.GetComponentInChildren<ScoreInWinUI>()?.Count();
    }

    public void Defeat()
    {
        gameObject.SetActive(true);
        PigsWinElements.SetActive(true);
        BirdsWinElements.SetActive(false);
    }
}