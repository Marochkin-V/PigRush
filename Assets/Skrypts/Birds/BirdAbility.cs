using UnityEngine;

public abstract class BirdAbility : MonoBehaviour
{
    [Header("BaseSettings")]
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected BirdStates birdState;
    [SerializeField] protected GameObject cloud;

    protected virtual void Start()
    {
        birdState = GetComponent<BirdStates>();
    }

    protected virtual void Activate()
    {
        Instantiate(cloud, transform.position, transform.rotation);
    }
}
