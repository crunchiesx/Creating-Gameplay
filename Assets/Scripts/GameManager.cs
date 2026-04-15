using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static Action<PlayerProfileSO> OnPlayerCreated;
    public static Action<PlayerProfileSO> OnPlayerWin;
    public static Action<PlayerProfileSO, int> OnPlayerKilled;
    public static Action<PlayerProfileSO, int> OnScoreChanged;


    [Header("Object Pools")]
    [SerializeField] private ObjectPool[] asteroidPools;

    [Header("Spawn Settings")]
    [SerializeField] private float reSpawnDuration = 2f;
    [SerializeField] private float positionOffset = 3f;

    [Header("Game Settings")]
    [SerializeField] private bool twoPlayerMode = true;

    [Header("Player Profiles")]
    [SerializeField] private PlayerProfileSO[] players;

    private int[] scores = new int[2];
    private bool gameOver = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private IEnumerator Start()
    {
        Player.totalPlayers = 0;
        int numPlayers = twoPlayerMode ? 2 : 1;

        for (int i = 0; i < numPlayers; i++)
        {
            GameObject player = Instantiate(players[i].playerObject);

            if (twoPlayerMode)
            {
                float xOffset = i == 0 ? -positionOffset : positionOffset;
                player.transform.position = Vector3.right * xOffset;
            }
            else
            {
                player.transform.position = Vector3.zero;
            }

            player.GetComponentInChildren<SpriteRenderer>().color = players[i].playerColor;
            OnPlayerCreated?.Invoke(players[i]);
        }

        while (!gameOver)
        {
            SpawnAsteroid();
            yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 5f));
        }

        if (twoPlayerMode)
        {
            int highestScore = 0;
            int winningPlayer = 0;

            for (int i = 0; i < numPlayers; i++)
            {
                if (scores[i] > highestScore)
                {
                    highestScore = scores[i];
                    winningPlayer = i;
                }
            }

            OnPlayerWin?.Invoke(players[winningPlayer]);
        }

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SpawnAsteroid()
    {
        int poolIndex = UnityEngine.Random.Range(0, asteroidPools.Length);
        GameObject asteroid = asteroidPools[poolIndex].GetObject();
        asteroid.SetActive(true);
    }

    public void ReportPlayerDeath(GameObject player, int playerNumber, int lives)
    {
        OnPlayerKilled?.Invoke(players[playerNumber], lives);

        if (lives > 0)
        {
            StartCoroutine(ReEnablePlayer(player));
            return;
        }

        if (lives <= 0)
        {
            Player.totalPlayers--;
            if (Player.totalPlayers <= 0)
            {
                gameOver = true;
                Debug.Log("Game Over!");
            }
        }
    }

    private IEnumerator ReEnablePlayer(GameObject player)
    {
        yield return new WaitForSeconds(reSpawnDuration);
        player.transform.position = Vector3.zero;
        player.transform.rotation = Quaternion.identity;
        player.SetActive(true);
    }

    public void UpdateScore(int pointsToAdd, int playerNumber)
    {
        scores[playerNumber] += pointsToAdd;
        OnScoreChanged?.Invoke(players[playerNumber], scores[playerNumber]);
    }
}
