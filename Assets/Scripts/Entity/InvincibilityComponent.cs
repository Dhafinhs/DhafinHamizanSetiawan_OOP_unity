using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer), typeof(HitboxComponent))]
public class InvincibilityComponent : MonoBehaviour
{
    [SerializeField] private int blinkingCount = 7;     // Number of times to blink
    [SerializeField] private float blinkInterval = 0.1f; // Interval between blinks
    [SerializeField] private Material blinkMaterial;     // Material used for blinking effect
    private SpriteRenderer spriteRenderer;               // Reference to the SpriteRenderer
    private Material originalMaterial;                   // Original material of the sprite
    public bool isInvincible = false;                    // Invincibility state

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    // Coroutine to start blinking effect
    public IEnumerator StartInvincibility()
    {
        isInvincible = true;
        for (int i = 0; i < blinkingCount; i++)
        {
            spriteRenderer.material = blinkMaterial;    // Set to blink material
            yield return new WaitForSeconds(blinkInterval);
            spriteRenderer.material = originalMaterial; // Revert to original material
            yield return new WaitForSeconds(blinkInterval);
        }
        isInvincible = false;
    }
}
