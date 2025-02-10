using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpriteByDurabilityChange : MonoBehaviour
{

    [SerializeField] private BreakableObject bb;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private List<Sprite> sprites;

    private float step;

    private void Start()
    {
        spriteRenderer.sprite = sprites[0];

        step = bb.MaxDurability / sprites.Count;
    }
    void Update()
    {
        if (sprites.Count > 0)
        {
            float durability = bb.Durability;
            int currentSpriteIndex = (int)Mathf.Floor(Mathf.Clamp(bb.MaxDurability - durability, 0.0f, bb.MaxDurability) / step);
            spriteRenderer.sprite = sprites[currentSpriteIndex];
        }
    }
}
