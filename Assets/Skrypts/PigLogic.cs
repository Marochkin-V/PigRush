using UnityEngine;

public class PigLogic : BreakableObject
{
    protected override void Break()
    {
        ScoreManager.AddScore(GlobalValues.PigScoreAmount);
        base.Break();
    }
}
