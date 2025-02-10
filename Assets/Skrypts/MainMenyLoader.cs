using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenyLoader : MonoBehaviour
{
    [Header("Only in MainMenu Scene Needed")]
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject Levels;

    public void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (GlobalValues.GoToLevelList)
            {
                MainMenu.SetActive(false);
                Levels.SetActive(true);
            }
            else
            {
                MainMenu.SetActive(true);
                Levels.SetActive(false);
            }
            GlobalValues.GoToLevelList = false;
        }
    }
}
