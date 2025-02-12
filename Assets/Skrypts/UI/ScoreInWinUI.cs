using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreInWinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTmp;
    private int currentScore = 0;
    private int targetScore = 0;
    private float scoreChangeDuration = 3f;

    private void Start()
    {
        scoreTmp = GetComponent<TextMeshProUGUI>();
        scoreTmp.text = "0";
    }

    public void Count()
    {
        targetScore = Mathf.RoundToInt(ScoreManager.Score);
        StartCoroutine(ChangeScoreSmoothly(targetScore));
    }

    IEnumerator ChangeScoreSmoothly(int target)
    {
        float timer = 0f;
        int startScore = 0;

        while (timer < scoreChangeDuration)
        {
            timer += Time.deltaTime;
            float progress = timer / scoreChangeDuration;
            currentScore = Mathf.RoundToInt(Mathf.Lerp(startScore, target, progress));
            scoreTmp.text = currentScore.ToString();

            yield return null;
        }

        currentScore = target;
        scoreTmp.text = target.ToString();
    }
}
