using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaunchBird : MonoBehaviour
{

    [SerializeField] private GameObject joint;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ParticleSystem puffEf;
    [SerializeField] private BirdStates birdState;

    [SerializeField] private float maxDistance;
    [SerializeField] private float maxForce;
    [SerializeField] private float mass;

    [SerializeField] private float timeToLive = 5f;
    private float timer;

    private Vector2 mousePosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GameObject.Find("Joint");
        birdState = GetComponent<BirdStates>();

        timer = timeToLive;
    }

    // Update is called once per frame
    void Update()
    {
        if (!birdState.isLaunched)
        {
            CheckIfToched();

            GetReady();

            Stretch();
        }
        else
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
                    Debug.Log("I'm Touched!");
                    birdState.isTouched = true;
                }
                else
                {
                    if (!LoadCheck.isLoaded)
                    {
                        birdState.isReady = true;
                        LoadCheck.isLoaded = true;
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
                LoadCheck.isLoaded = false;
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
        rb.AddForce(strangth * direction, ForceMode2D.Force);
    }

    public void Puf()
    {
        Instantiate(puffEf, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    foreach (ContactPoint2D contact in collision.contacts)
    //    {
    //        BrickBreak brick = collision.gameObject.GetComponent<BrickBreak>();
    //        if (brick != null)
    //        {
    //            float remainingDurability = brick.GetDurability();
    //            float impactForce = contact.normalImpulse * GlobalValues.BirdHitMultiplier;

    //            if (remainingDurability < 0)
    //            {
    //                rb.linearVelocity *= 1;
    //            }
    //        }
    //    }
    //}
}
