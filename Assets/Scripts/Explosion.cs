using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private AnimationCurve animationCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);

    [Space]

    [SerializeField] private float duration = 0.5f;

    private void OnEnable()
    {
        StartCoroutine(ShrinkScale());
    }

    private IEnumerator ShrinkScale()
    {
        float startScale = transform.localScale.x;
        float scale;
        float timer = 0f;

        while (timer < duration)
        {
            float t = timer / duration;
            scale = Mathf.Lerp(startScale, 0f, animationCurve.Evaluate(t));
            transform.localScale = Vector3.one * scale;
            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.zero;
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
