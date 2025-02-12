using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreToUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTmp;
    private int currentScore = 0;
    private int targetScore = 0;
    private float scoreChangeDuration = 1f; // Длительность анимации изменения очков

    void Start()
    {
        scoreTmp = GetComponent<TextMeshProUGUI>();
        ScoreManager.Reset();
        scoreTmp.text = "0";
    }

    void Update()
    {
        targetScore = Mathf.RoundToInt(ScoreManager.Score);

        if (currentScore != targetScore)
        {
            StartCoroutine(ChangeScoreSmoothly(targetScore));
        }
    }

    IEnumerator ChangeScoreSmoothly(int target)
    {
        float timer = 0f;
        int startScore = currentScore;

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
