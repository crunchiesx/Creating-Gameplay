using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Text livesDisplay;
    [SerializeField] private Text scoreDisplay;

    public void SetPlayerColor(Color playerColor)
    {
        livesDisplay.color = playerColor;
        scoreDisplay.color = playerColor;
    }

    public void UpdateLives(int lives)
    {
        switch (lives)
        {
            case 3:
                livesDisplay.text = "^ ^ ^";
                break;
            case 2:
                livesDisplay.text = "^ ^";
                break;
            case 1:
                livesDisplay.text = "^";
                break;
            default:
                livesDisplay.text = "";
                break;
        }
    }

    public void UpdateScore(int score)
    {
        scoreDisplay.text = string.Format("{0:000000}", score);
    }
}
