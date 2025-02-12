using UnityEngine;

public class TNT : BreakableObject
{

    [SerializeField] private Explosion2D exp;
    [SerializeField] private Mode mode;
    [SerializeField] private float radius;
    [SerializeField] private float power;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float damageInCenter;
    private enum Mode { simple, adaptive }

    private void Start()
    {
        base.Start();
        sfxBricks = GetComponent<BrickSounds>();
        sfxBricks.audioSource.volume = GlobalValues.sfxVolume * 1.5f;
    }

    public override void Damage(float damage)
    {
        durability -= damage;
        ScoreManager.AddScore(damage);

        if (durability <= 0f)
        {
            Break();
        }
    }

    protected override void Break()
    {
        AudioSource.PlayClipAtPoint(sfxBricks.crash[Random.Range(0, sfxBricks.crash.Length)], transform.position);
        exp.Detonate(transform.position, radius, power, layerMask, damageInCenter);
        base.Break();
    }
}
