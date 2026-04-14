using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private int basePoints = 100;

    [HideInInspector] public int pointsValue;

    private void OnEnable()
    {
        pointsValue = Mathf.RoundToInt(basePoints * transform.localScale.x);
    }
}
