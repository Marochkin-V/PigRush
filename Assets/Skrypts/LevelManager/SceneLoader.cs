using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadScene(int sceneId)
    {
        Scene scene = SceneManager.GetSceneByBuildIndex(sceneId);
        SceneManager.LoadScene(sceneId);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToLevelList()
    {
        GlobalValues.GoToLevelList = true;
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        if (SceneManager.sceneCountInBuildSettings >= SceneManager.GetActiveScene().buildIndex)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            GoToLevelList();
    }
}
