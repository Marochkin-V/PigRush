using UnityEngine;

public class Explosion2D : MonoBehaviour
{
    [Header("Exploison")]
    [SerializeField] private Mode mode;
    private enum Mode { simple, adaptive }

    // Exploison
    public void Detonate(Vector3 position, float radius, float power, LayerMask layerMask, float damageInCenter)
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

                if (hit.gameObject.layer == 6)
                {
                    BreakableObject bb;
                    if (hit.gameObject.TryGetComponent<BreakableObject>(out bb))
                        bb.Damage(damageInCenter * (1 - Vector2.Distance(transform.position, hit.transform.position) / radius));
                }
            }
        }
    }

    private bool CanUse(Vector3 position, Rigidbody2D body)
    {
        if (mode == Mode.simple) return true;

        RaycastHit2D hit = Physics2D.Linecast(position, body.position);

        if (hit.rigidbody != null && hit.rigidbody == body)
        {
            return true;
        }
        return false;
    }
}
