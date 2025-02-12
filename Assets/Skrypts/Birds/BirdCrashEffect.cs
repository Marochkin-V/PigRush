using UnityEngine;

public class BirdCrashEffect : MonoBehaviour
{

    [SerializeField] private ParticleSystem touchEff;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (touchEff != null)
        {
            Instantiate(touchEff, transform.position, Quaternion.identity);
        }
    }
}
