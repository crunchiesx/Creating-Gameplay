using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private int basePoints = 100;

    [SerializeField] private bool scalePointsBySize = true;

    public void ScorePoints(int playerNumber)
    {
        int pointsValue = basePoints;
        if (scalePointsBySize)
        {
            pointsValue = Mathf.RoundToInt(basePoints * transform.localScale.x);
        }

        GameManager.Instance.UpdateScore(pointsValue, playerNumber);
    }
}
