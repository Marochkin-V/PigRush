using Unity.VisualScripting;
using UnityEngine;

public abstract class BreakableObject : MonoBehaviour
{
    [Header("Durability")]
    [SerializeField] protected float durability;
    [SerializeField] protected float maxDurability;
    public float MaxDurability => maxDurability;
    public float Durability => durability;

    [Header("Sprites")]
    [SerializeField] protected ParticleSystem BreakEf;
    protected SpriteRenderer spriteRenderer;

    [Header("Audio")]
    [SerializeField] protected BrickSounds sfxBricks;

    protected virtual void Start()
    {
        durability = maxDurability;
        sfxBricks = GetComponent<BrickSounds>();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            float damage = contact.normalImpulse * (contact.collider.gameObject.layer == 7 ? GlobalValues.BirdHitMultiplier : GlobalValues.ObjectCollisionForceMultiplier);
            if (damage > durability * GlobalValues.MinDamageInPrecent)
            {
                Damage(damage * GlobalValues.BirdVSBlockMult(contact.collider.gameObject.tag, gameObject.tag));
            }
        }
    }

    public virtual void Damage(float damage)
    {
        if (damage > durability * GlobalValues.MinDamageInPrecent * 2)
            sfxBricks.audioSource.PlayOneShot(sfxBricks.crash[Random.Range(0, sfxBricks.crash.Length)]);
        durability -= damage;
        ScoreManager.AddScore(damage);

        if (durability <= 0f)
        {
            AudioSource.PlayClipAtPoint(sfxBricks.crash[Random.Range(0, sfxBricks.crash.Length)], transform.position);
            Break();
        }
    }

    protected virtual void Break()
    {
        if (BreakEf != null)
        {
            Instantiate(BreakEf, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}