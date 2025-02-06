using System.Timers;
using UnityEngine;

public class DotDisapper : MonoBehaviour
{

    [SerializeField] private float offsetTime = GlobalValues.DotTrailDisappearOffset;
    [SerializeField] private float timeToDisappear = 1f;
    [SerializeField] private Vector3 initialScale;
    private float timer = 0;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (offsetTime > 0f)
        {
            offsetTime -= Time.deltaTime;
        }
        else
        {
            transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, timer);
            if (timer <= timeToDisappear)
                timer += Time.deltaTime;
            else
                Destroy(gameObject);
        }
    }
}
