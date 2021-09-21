using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private float _timeBetweenWaves = 0;
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] private Player _player;

    private float _currentTime;
    private Wave _currentWave;
    private int _currentWaveNumber;
    private float _timeAfterLastSpawn;

    public UnityAction<float, float> EnemyCountChanged;
    public UnityAction<int> WaveCountChanged;

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
            WaveCountChanged?.Invoke(_currentWaveNumber);
        }
        else return;
    }

    private void SpawnWaves()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay && _currentWave.Spawned < _currentWave.Count)
        {
            InstantiateEnemy();
            _currentWave.Spawned++;
            EnemyCountChanged?.Invoke(_currentWave.Count, _currentWave.Spawned);
            _timeAfterLastSpawn = 0;
        }

        if (_currentWave.Spawned >= _currentWave.Count)
        {
            _currentTime += Time.deltaTime;

            if (_currentWaveNumber < _waves.Count - 1 && _currentTime >= _timeBetweenWaves)
            {
                SetWave(++_currentWaveNumber);
                _currentTime = 0;
            }
        }
    }

    private void InstantiateEnemy()
    {
        int SpawnPoint = Random.Range(0, _spawnPoints.Length);
        int SpawnEnemy = Random.Range(0, _currentWave.Templates.Count);
        Enemy enemy = Instantiate(_currentWave.Templates[SpawnEnemy], _spawnPoints[SpawnPoint].position, Quaternion.identity, _spawnPoints[SpawnPoint]).GetComponent<Enemy>();
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
