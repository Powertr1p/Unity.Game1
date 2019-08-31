using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLogic : MonoBehaviour
{
    private GameObject _enemyPrefab;
    private GameObject _coinPrefab;

    private Vector2 _currentSpawnerPos;

    private bool _isSpawnerBusy; 
    private int _coinsLength;

    private float _timeBetweenSpawnSaw;
    private Vector2 _lastSpawnedSawPos;
    private float _timeBetweenSpawnCoins;
    private Vector2 _lastSpawnedCoinPos;


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
        _currentSpawnerPos = transform.position;
        SpawnSaw();
        SpawnCoins();
    }

    private void SpawnSaw()
    {
        _timeBetweenSpawnSaw -= Time.deltaTime;

        if (_timeBetweenSpawnSaw <= 0 && !_isSpawnerBusy && Random.Range(0, 51) == 25)
        {
            Vector2 _distanceBetweenSpawns = new Vector2();
            _distanceBetweenSpawns = _currentSpawnerPos - _lastSpawnedSawPos;

            if (_distanceBetweenSpawns.x > 3)
            {
                _isSpawnerBusy = true;
                _currentSpawnerPos.y = Random.Range(1, 4);
                Instantiate(_enemyPrefab, _currentSpawnerPos, Quaternion.identity);
                _lastSpawnedSawPos = _currentSpawnerPos;
                _timeBetweenSpawnSaw = 1.0f;
                _isSpawnerBusy = false;
            }
        }
    }

    private void SpawnCoins()
    {
        _timeBetweenSpawnCoins -= Time.deltaTime;

        if (_timeBetweenSpawnSaw <= 0 && !_isSpawnerBusy && Random.Range(0, 101) == 50)
        {
            Vector2 _distanceBetweenSpawns = new Vector2();
            _distanceBetweenSpawns = _currentSpawnerPos - _lastSpawnedCoinPos;
            if (_distanceBetweenSpawns.x > 3)
            {
                _isSpawnerBusy = true;
                for (int i = 0; i < _coinsLength; i++)
                 {
                    _currentSpawnerPos.x += 1;
                    _currentSpawnerPos.y = 1;
                    Instantiate(_coinPrefab, _currentSpawnerPos, Quaternion.identity);
                    _lastSpawnedCoinPos = _currentSpawnerPos;
                 }
                 _isSpawnerBusy = false;
                 _timeBetweenSpawnCoins = 5.0f;
            }
        }
    }
}
