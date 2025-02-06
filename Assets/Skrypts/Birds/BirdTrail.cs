using UnityEngine;

public class BirdTrail : MonoBehaviour
{

    [SerializeField] private GameObject dot;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LaunchBird lb;
    [SerializeField] private BirdStates birdState;


    [SerializeField] private float offsetTime = 0.1f;
    [SerializeField] private float offsetAfterLaunch = 0.5f;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        birdState = GetComponent<BirdStates>();
        timer = offsetAfterLaunch;
    }

    // Update is called once per frame
    void Update()
    {
        if (birdState != null && birdState.isLaunched && !birdState.isCrashed)
        {
            if (timer <= 0f)
            {
                Instantiate(dot, transform.position, Quaternion.identity);
                timer = offsetTime;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdState.isCrashed = true;
    }
}
