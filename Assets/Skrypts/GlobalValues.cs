using System.Collections.Generic;
using UnityEngine;

public static class GlobalValues
{
    public static float BirdHitMultiplier = 2f;
    public static float ObjectCollisionForceMultiplier = 1f;
    public static float MinDamageInPrecent = 0.05f;
    public static float DotTrailDisappearOffset = 15f;

    public static float PigScoreAmount = 500f;

    public static bool GoToLevelList = false;

    public static Dictionary<string, string> BirdVSBlockForse = new Dictionary<string, string>()
    {
        {"Blue", "Glass" },
        {"Black", "Stone" },
        {"Yellow", "Wood" }
    };
    private static float mult = 3f;

    public static float BirdVSBlockMult(string birdTag, string blockTag)
    {
        string block;
        if (BirdVSBlockForse.TryGetValue(birdTag, out block))
        {
            if (block == blockTag)
            {
                return mult;
            }
        }

        return 1.0f;
    }
}
