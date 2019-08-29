using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject _enemyPrefab;
    private GameObject _coinPrefab;

    private Vector2 _currentPos;

    private float _timePassed;
    private bool _isSpawnerBusy; 
    private float _localCooldown;
    private int _coinsLength;
    private float _globalCooldown;

    private float _timeBetweenSpawnSaw;
    private float _timeBetweenSpawnCoins;

    private void Start()
    {
        _coinsLength = 4;
        _isSpawnerBusy = false;

        _timeBetweenSpawnSaw = 2.0f;
        _timeBetweenSpawnCoins = 3.0f;

        _enemyPrefab = Resources.Load("Prefabs/Enemy") as GameObject;
        _coinPrefab = Resources.Load("Prefabs/Coin") as GameObject;
    }

    private void Update()
    {
        _currentPos = transform.position;
        SpawnSaw();
        SpawnCoins();
    }

    private void SpawnSaw()
    {
        _timeBetweenSpawnSaw -= Time.deltaTime;

        if (_timeBetweenSpawnSaw <= 0 && !_isSpawnerBusy && Random.Range(0, 200) == 100)
        {
             _isSpawnerBusy = true;
             _currentPos.y = Random.Range(1, 3);
             Instantiate(_enemyPrefab, _currentPos, Quaternion.identity);
            _isSpawnerBusy = false;
            _timeBetweenSpawnSaw = 1.0f;
        }
    }

    private void SpawnCoins()
    {
        _timeBetweenSpawnCoins -= Time.deltaTime;

        if (_timeBetweenSpawnSaw <= 0 && !_isSpawnerBusy && Random.Range(0, 200) == 100)
        {
            _isSpawnerBusy = true;
            for (int i = 0; i < _coinsLength; i++)
            {
                _currentPos.x += 1;
                _currentPos.y = 1;
                Instantiate(_coinPrefab, _currentPos, Quaternion.identity);
            }
            _isSpawnerBusy = false;
            _timeBetweenSpawnCoins = 5.0f;
        }
       
    }
}
