using UnityEngine;

public class PigLogic : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private float maxHp;

    [SerializeField] private ParticleSystem DieEf;
    [SerializeField] private Color StartColor;
    [SerializeField] private Color EndColor;

    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        hp = maxHp;
    }

    private void Update()
    {
        if (hp <= 0f)
        {
            Instantiate(DieEf, transform.position, Quaternion.identity);
            ScoreManager.AddScore(500);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            Debug.Log("Сила столкновения: " + contact.normalImpulse);
            // TODO: make birdMultiplier
            float damage = contact.normalImpulse * (contact.collider.gameObject.CompareTag("Bird") ? 5 : 1);
            hp -= damage;

            spriteRenderer.color = Color.Lerp(StartColor, EndColor, 1 - hp / maxHp);
        }
    }
}
