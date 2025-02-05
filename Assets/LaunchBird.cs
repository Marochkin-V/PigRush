using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaunchBird : MonoBehaviour
{

    [SerializeField] private GameObject joint;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float maxDistance;
    [SerializeField] private float maxForce;
    [SerializeField] private float mass;

    [SerializeField] private bool isTouched;
    [SerializeField] private bool isLaunched;
    [SerializeField] private bool isReady;
    [SerializeField] private bool inLauncher;

    private Vector2 mousePosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GameObject.Find("Joint");
        
        isLaunched = false;
        isTouched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLaunched)
        {
            CheckIfToched();

            GetReady();

            Stretch();
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
                if (inLauncher)
                {
                    Debug.Log("I'm Touched!");
                    isTouched = true;
                }
                else
                {
                    if (!LoadCheck.isLoaded)
                    {
                        isReady = true;
                        LoadCheck.isLoaded = true;
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isTouched)
            {
                Fire();
                isLaunched = true;
                isTouched = false;
                LoadCheck.isLoaded = false;
            }
        }
    }

    private void GetReady()
    {
        if (isReady)
        {
            transform.position = joint.transform.position;
            isReady = false;
            inLauncher = true;
        }
    }

    private void Stretch()
    {
        if (isTouched && inLauncher)
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
