using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private float _timeBetweenWaves = 0;
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveNumber;
    private float _timeAfterLastSpawn;

    private void Start()
    {
        SetWave(0);
    }

    private void Update()
    {
        SpawnWaves();
    }

    private void SetWave(int index)
    {
        if (index < _waves.Count)
        {
            _currentWave = _waves[index];
            _currentWaveNumber = index;
        }
        else return;
    }

    private void SpawnWaves()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _currentWave.Spawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_currentWave.Spawned >= _currentWave.Count)
        {
            _currentWave = null;

            if (_currentWaveNumber < _waves.Count-1)  
            SetWave(++_currentWaveNumber);

        }

    }

    private void InstantiateEnemy()
    {
        int SpawnPoint = Random.Range(0, _spawnPoints.Length);
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoints[SpawnPoint].position, Quaternion.identity).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.Dying += OnEnemyDie;
    }

    private void OnEnemyDie(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDie;
        _player.TryGetComponent(out Wallet wallet);
        wallet.AddMoney(enemy.Reward);
    }
}
