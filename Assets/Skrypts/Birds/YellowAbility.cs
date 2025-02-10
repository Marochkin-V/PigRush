using UnityEngine;

public class YellowAbility : BirdAbility
{

    [SerializeField] private float force;
    [SerializeField] private bool isAvailable;

    // Update is called once per frame
    void Update()
    {
        if (!birdState.isCrashed && !birdState.abilityUsed && Input.GetMouseButtonDown(0) && birdState.isLaunched) 
        {
            Activate();
            birdState.abilityUsed = true;
        }
    }

    protected override void Activate()
    {
        base.Activate();
        //Debug.Log("Ability activated");
        Vector3 direction = rb.linearVelocity.normalized;
        rb.AddForce(direction * force);
    }
}
