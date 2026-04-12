using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("References")]
    [SerializeField] private PlayerUI[] playerUI;

    [Header("Object Pools")]
    public ObjectPool explosionPool;
    public ObjectPool[] asteroidPools;
    public ObjectPool[] projectilePools;

    [Header("Settings")]
    [SerializeField] private float reSpawnDuration = 2f;

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
        while (!gameOver)
        {
            SpawnAsteroid();
            yield return new WaitForSeconds(Random.Range(1f, 5f));
        }
    }

    private void SpawnAsteroid()
    {
        int poolIndex = Random.Range(0, asteroidPools.Length);
        GameObject asteroid = asteroidPools[poolIndex].GetObject();
        asteroid.SetActive(true);
    }

    public void ReportPlayerDeath(GameObject player, int playerNumber, int lives)
    {
        playerUI[playerNumber].UpdateLives(lives);

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
}
