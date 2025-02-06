using UnityEngine;

public class YellowAbility : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BirdStates birdState;

    [SerializeField] private float force;
    [SerializeField] private bool isAvailable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        birdState = GetComponent<BirdStates>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!birdState.isCrashed && !birdState.abilityUsed && Input.GetMouseButtonDown(0) && birdState.isLaunched) 
        {
            Activate();
            birdState.abilityUsed = true;
        }
    }

    private void Activate()
    {
        Debug.Log("Ability activated");
        Vector3 direction = rb.linearVelocity.normalized;
        rb.AddForce(direction * force);
    }
}
