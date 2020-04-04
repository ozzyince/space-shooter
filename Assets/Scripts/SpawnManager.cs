using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemies;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _enemySpawnRate = 5f;
    [SerializeField] private Powerup[] _powerupPrefabs;
    [SerializeField] private float _powerupSpawnRate = 7f;

    private bool _stopSpawning = false;

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(_enemySpawnRate / 2);
        while (!_stopSpawning)
        {
            var enemy = Instantiate(_enemyPrefab, new Vector3(Random.Range(-8f, 8f), 7f, 0), Quaternion.identity);
            enemy.transform.parent = _enemies.transform;
            yield return new WaitForSeconds(_enemySpawnRate);
        }
    }

    IEnumerator SpawnPowerup()
    {
        yield return new WaitForSeconds(_powerupSpawnRate / 2);
        while (!_stopSpawning)
        {
            Instantiate(_powerupPrefabs[Random.Range(0, _powerupPrefabs.Length)], new Vector3(Random.Range(-8f, 8f), 7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(_powerupSpawnRate);
        }
    }

    public void OnAsteroidDestroyed()
    {
        StartCoroutine("SpawnEnemy");
        StartCoroutine("SpawnPowerup");
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
