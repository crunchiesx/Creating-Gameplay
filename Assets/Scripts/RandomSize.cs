using UnityEngine;

public class RandomSize : MonoBehaviour
{
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 1.5f;

    private float defaultScale;

    private void Awake()
    {
        defaultScale = transform.localScale.x;
    }

    private void OnEnable()
    {
        transform.localScale *= Random.Range(minScale, maxScale);
    }

    private void OnDisable()
    {
        transform.localScale = Vector3.one * defaultScale;
    }
}
