using UnityEngine;

public static class ScoreManager
{
    private static float score = 0;

    public static float Score => score;

    public static void AddScore(float points)
    {
        score += points;
    }

    public static void Reset()
    {
        score = 0;
    }
}