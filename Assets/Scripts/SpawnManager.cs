using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemies;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _enemySpawnRate = 5f;
    [SerializeField] private Powerup _powerupPrefab;
    [SerializeField] private float _powerupSpawnRate = 7f;

    private bool _stopSpawning = false;

    void Start()
    {
        StartCoroutine("SpawnEnemy");
        StartCoroutine("SpawnPowerup");
    }

    IEnumerator SpawnEnemy()
    {
        while (!_stopSpawning)
        {
            var enemy = Instantiate(_enemyPrefab, new Vector3(Random.Range(-8f, 8f), 7f, 0), Quaternion.identity);
            enemy.transform.parent = _enemies.transform;
            yield return new WaitForSeconds(_enemySpawnRate);
        }
    }

    IEnumerator SpawnPowerup()
    {
        while (!_stopSpawning)
        {
            var enemy = Instantiate(_powerupPrefab, new Vector3(Random.Range(-8f, 8f), 7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(_powerupSpawnRate);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
