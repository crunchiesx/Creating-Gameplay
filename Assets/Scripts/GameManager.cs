using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public ObjectPool explosionPool;
    public ObjectPool[] asteroidPools;

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
}
