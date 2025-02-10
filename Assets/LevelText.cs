using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelTxt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelTxt.text = SceneManager.GetActiveScene().buildIndex.ToString();
    }
}
