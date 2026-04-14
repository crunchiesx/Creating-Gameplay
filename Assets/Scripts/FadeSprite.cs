using UnityEditor.EditorTools;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FadeSprite : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 5f;

    [Tooltip("Automatically turn off the scripts if the sprite's transparency is zero.")]
    [SerializeField] private bool autoOff = true;

    private float target;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDisable()
    {
        SetTransparency(0);
    }

    private void Update()
    {
        float newValue = Mathf.MoveTowards(spriteRenderer.color.a, target, fadeSpeed * Time.deltaTime);
        SetTransparency(newValue);

        if (autoOff && spriteRenderer.color.a == 0f)
        {
            enabled = false;
        }
    }

    public void SetTransparencyValue(float value)
    {
        if (autoOff && !enabled)
        {
            enabled = true;
        }

        SetTransparency(value);
    }

    public void SetTransparencyTarget(float value)
    {
        if (autoOff && !enabled)
        {
            enabled = true;
        }

        target = value;
    }

    private void SetTransparency(float value)
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, value);
    }
}
