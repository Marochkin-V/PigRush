using UnityEngine;

public class BlueAbility : BirdAbility
{
    [SerializeField] private float offset = 1f;
    [SerializeField] private bool isAvailable;
    [SerializeField] private float angle = 10f;

    // Update is called once per frame
    void Update()
    {
        if (birdState != null && !birdState.isCrashed && !birdState.abilityUsed && Input.GetMouseButtonDown(0) && birdState.isLaunched)
        {
            Activate();
            birdState.abilityUsed = true;
        }
    }

    protected override void Activate()
    {
        base.Activate();
        //Debug.Log("Ability activated");
        Vector2 offsetVector = Vector2.Perpendicular(rb.linearVelocity.normalized) * offset;

        GameObject b1 = Instantiate(gameObject, (Vector2)transform.position + offsetVector, Quaternion.identity);
        b1.GetComponent<Rigidbody2D>().linearVelocity = RotateVector(rb.linearVelocity, angle);

        GameObject b2 = Instantiate(gameObject, (Vector2)transform.position - offsetVector, Quaternion.identity);
        b2.GetComponent<Rigidbody2D>().linearVelocity = RotateVector(rb.linearVelocity, -angle);
    }

    private Vector2 RotateVector(Vector2 vector, float angle)
    {
        // Преобразуем угол из градусов в радианы
        float angleInRadians = angle * Mathf.Deg2Rad;

        // Вычисляем синус и косинус угла
        float sinAngle = Mathf.Sin(angleInRadians);
        float cosAngle = Mathf.Cos(angleInRadians);

        // Поворачиваем вектор
        float rotatedX = vector.x * cosAngle - vector.y * sinAngle;
        float rotatedY = vector.x * sinAngle + vector.y * cosAngle;

        // Создаем новый повернутый вектор
        return new Vector2(rotatedX, rotatedY);
    }
}
