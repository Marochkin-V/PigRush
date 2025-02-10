using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaunchBird : MonoBehaviour
{
    [Header("States")]
    [SerializeField] private BirdStates birdState;

    [Header("Launch Settings")]
    [SerializeField] private GameObject joint;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float maxDistance;
    [SerializeField] private float maxForce;
    [SerializeField] private float mass;

    [Header("LifeTime & Puf")]
    [SerializeField] private ParticleSystem puffEf;
    [SerializeField] private float timeToLive = 5f;
    private float timer;

    private Vector2 mousePosition;

    void Start()
    {
        birdState = GetComponent<BirdStates>();

        joint = GameObject.Find("Joint");
        rb = GetComponent<Rigidbody2D>();

        timer = timeToLive;
    }

    void Update()
    {
        if (!birdState.isLaunched)
        {
            CheckIfToched();

            GetReady();

            Stretch();
        }
        
        if(birdState.isCrashed)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            Puf();
        }
    }

    private void CheckIfToched()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                if (birdState.inLauncher)
                {
                    birdState.isTouched = true;
                }
                else
                {
                    if (!Slingshot.isLoaded)
                    {
                        birdState.isReady = true;
                        Slingshot.isLoaded = true;
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (birdState.isTouched)
            {
                Fire();
                birdState.isLaunched = true;
                birdState.isTouched = false;
                Slingshot.isLoaded = false;
            }
        }
    }

    private void GetReady()
    {
        if (birdState.isReady)
        {
            transform.position = joint.transform.position;
            birdState.isReady = false;
            birdState.inLauncher = true;
        }
    }

    private void Stretch()
    {
        if (birdState.isTouched && birdState.inLauncher)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance((Vector2)mousePosition, (Vector2)joint.transform.position) < maxDistance)
            {
                transform.position = mousePosition;
            }
            else
            {
                Vector2 direction = (mousePosition - (Vector2)joint.transform.position).normalized;
                transform.position = (Vector2)joint.transform.position + direction * maxDistance;
            }
        }
    }

    private void Fire()
    {
        float strangth = Vector2.Distance((Vector2)transform.position, (Vector2)joint.transform.position) / maxDistance * maxForce;
        Vector2 direction = (joint.transform.position - transform.position).normalized;

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.mass = mass;
        rb.AddForce(strangth * direction * mass, ForceMode2D.Force);
    }

    public void Puf()
    {
        Instantiate(puffEf, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdState.isLaunched) birdState.isCrashed = true;
    }
}
