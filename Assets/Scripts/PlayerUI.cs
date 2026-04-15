using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerProfileSO playerProfile;

    [Header("UI Elements")]
    [SerializeField] private Text livesDisplayText;
    [SerializeField] private Text scoreDisplayText;
    [SerializeField] private Image winScreenImage;

    private void OnEnable()
    {
        ActivateUI(false);

        GameManager.OnPlayerCreated += SetUpUI;
        GameManager.OnPlayerKilled += UpdateLives;
        GameManager.OnScoreChanged += UpdateScore;
        GameManager.OnPlayerWin += DisplayWinScreen;
    }

    private void OnDisable()
    {
        GameManager.OnPlayerCreated -= SetUpUI;
        GameManager.OnPlayerKilled -= UpdateLives;
        GameManager.OnScoreChanged -= UpdateScore;
        GameManager.OnPlayerWin -= DisplayWinScreen;
    }

    private void SetUpUI(PlayerProfileSO playerProfileSO)
    {
        if (playerProfile != playerProfileSO)
        {
            return;
        }

        SetPlayerColor(playerProfileSO.playerColor);
        ActivateUI(true);
    }

    private void ActivateUI(bool active)
    {
        livesDisplayText.gameObject.SetActive(active);
        scoreDisplayText.gameObject.SetActive(active);
    }

    public void SetPlayerColor(Color playerColor)
    {
        livesDisplayText.color = playerColor;
        scoreDisplayText.color = playerColor;
        winScreenImage.color = playerColor;
    }

    public void UpdateLives(PlayerProfileSO playerProfileSO, int lives)
    {
        if (playerProfile != playerProfileSO)
        {
            return;
        }

        livesDisplayText.text = lives switch
        {
            3 => "^ ^ ^",
            2 => "^ ^",
            1 => "^",
            _ => "",
        };
    }

    public void UpdateScore(PlayerProfileSO playerProfileSO, int score)
    {
        if (playerProfile != playerProfileSO)
        {
            return;
        }

        scoreDisplayText.text = string.Format("{0:000000}", score);
    }

    public void DisplayWinScreen(PlayerProfileSO playerProfileSO)
    {
        if (playerProfile != playerProfileSO)
        {
            return;
        }

        winScreenImage.gameObject.SetActive(true);
    }
}
