using UnityEngine;

public class AnimatedSprites : MonoBehaviour
{
    public GameObject targetObject;
    public Sprite[] spritesToLoop;
    private SpriteRenderer[] spriteRenderers;
    private int currentSpriteIndex = 0;

    public float timeBetweenSprites = 2.0f;  // Time interval between sprite changes
    private float timer = 0.0f;  // Timer to keep track of elapsed time

    private void Start()
    {
        spriteRenderers = targetObject.GetComponentsInChildren<SpriteRenderer>();

        if (spritesToLoop.Length > 0)
        {
            foreach (var spriteRenderer in spriteRenderers)
            {
                spriteRenderer.sprite = spritesToLoop[currentSpriteIndex];
            }
        }
    }

    private void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if it's time to switch to the next sprite
        if (timer >= timeBetweenSprites)
        {
            ShowNextSprite();
            timer = 0.0f;  // Reset the timer
        }
    }

    private void ShowNextSprite()
    {
        currentSpriteIndex = (currentSpriteIndex + 1) % spritesToLoop.Length;

        foreach (var spriteRenderer in spriteRenderers)
        {
            spriteRenderer.sprite = spritesToLoop[currentSpriteIndex];
        }
    }
}