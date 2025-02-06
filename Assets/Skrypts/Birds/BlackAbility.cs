using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Rendering.HableCurve;

public class BlackAbility : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BirdStates birdState;

    [SerializeField] private bool isAvailable;

    [Header("Exploison")]
    [SerializeField] private Mode mode;
    [SerializeField] private float radius;
    [SerializeField] private float power;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float damageInCenter;
    private enum Mode { simple, adaptive }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        birdState = GetComponent<BirdStates>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!birdState.abilityUsed && Input.GetMouseButtonDown(0) && birdState.isLaunched)
        {
            Activate();
            birdState.abilityUsed = true;
            gameObject.GetComponent<LaunchBird>()?.Puf();
        }
    }

    private void Activate()
    {
        Debug.Log("Ability activated");
        Explosion2D(transform.position);
    }

    // Exploison

    void Explosion2D(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius, layerMask);
        Debug.Log(colliders.Length);

        foreach (Collider2D hit in colliders)
        {
            if (hit.attachedRigidbody != null)
            {
                Vector3 direction = hit.transform.position - position;
                direction.z = 0;

                if (CanUse(position, hit.attachedRigidbody))
                {
                    hit.attachedRigidbody.AddForce(direction.normalized * power);
                }

                if (hit.gameObject.CompareTag("Brick"))
                {
                    hit.gameObject.GetComponent<BrickBreak>()?.Damage(Mathf.Lerp(damageInCenter, damageInCenter / 2, Vector2.Distance(transform.position, hit.transform.position)));
                }
            }
        }
    }

    bool CanUse(Vector3 position, Rigidbody2D body)
    {
        if (mode == Mode.simple) return true;

        RaycastHit2D hit = Physics2D.Linecast(position, body.position);

        if (hit.rigidbody != null && hit.rigidbody == body)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        float angleStep = 360f / 36;

        for (int i = 0; i < 36; i++)
        {
            float angle = i * angleStep;
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            Vector3 pointA = new Vector3(x, y, 0) + transform.position;
            angle = (i + 1) * angleStep;
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            Vector3 pointB = new Vector3(x, y, 0) + transform.position;

            Gizmos.DrawLine(pointA, pointB);
        }
    }
}
