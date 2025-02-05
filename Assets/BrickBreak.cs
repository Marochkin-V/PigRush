using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class BrickBreak : MonoBehaviour
{

    [SerializeField] private float durability;
    [SerializeField] private float maxDurability;

    [SerializeField] private ParticleSystem BreakEf;
    [SerializeField] private Color StartColor;
    [SerializeField] private Color EndColor;

    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        durability = maxDurability;
    }

    private void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            //Debug.Log("Сила столкновения: " + contact.normalImpulse);
            float damage = contact.normalImpulse * (contact.collider.gameObject.CompareTag("Bird") ? GlobalValues.BirdHitMultiplier : 1);
            if (damage > 5)
            {
                durability -= damage;
                ScoreManager.AddScore(damage);

                if (durability <= 0f)
                {
                    Instantiate(BreakEf, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    break;
                }
                spriteRenderer.color = Color.Lerp(StartColor, EndColor, 1 - durability / maxDurability);
            }

        }
    }

    public float GetDurability()
    {
        return durability;
    }
}
