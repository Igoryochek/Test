using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Vector2 _ySpawnRange;
    [SerializeField] private Vector2 _xSpawnRange;
    [SerializeField] private EnemyUnit _enemyPrefab;
    [SerializeField] private int _enemyCount;
    [SerializeField] private float _timeBetweenSpawning;

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private void Spawn()
    {
        float randomY = Random.Range(_ySpawnRange.x, _ySpawnRange.y);
        float randomX = Random.Range(_xSpawnRange.x, _xSpawnRange.y);
        Vector2 randomPosition = new Vector2(randomX, randomY);
        Instantiate(_enemyPrefab, randomPosition, Quaternion.identity);
    }

    private IEnumerator Spawning()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            yield return new WaitForSeconds(_timeBetweenSpawning);
            Spawn();
        }
    }
}
