using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPref;
    public GameObject CoinPref;
    private Vector2 _currentPos;
    private float _timePassed;
    private bool _isSpawnerBusy; 
    private float _cooldown = 0;

    [SerializeField] private int _coinsLength;
    [SerializeField] private float _timeBetweenSpawn;

    private void Awake()
    {
        _isSpawnerBusy = false;
        _coinsLength = 4;
        _timeBetweenSpawn = 2;
    }

    private void Update()
    {
        _currentPos = transform.position;
        SpawnSaw();
        SpawnCoins();
    }

    private void SpawnSaw()
    {
        if (Random.Range(0, 200) == 100 && !_isSpawnerBusy)
        {
            _isSpawnerBusy = true;
            _currentPos.y = Random.Range(1, 3);
            Instantiate(EnemyPref, _currentPos, Quaternion.identity);
            do {
                _cooldown += Time.deltaTime;
            } while (_cooldown < 5f);

            _isSpawnerBusy = false;
            _cooldown = 0f;
        }
    }

    private void SpawnCoins()
    {
        if (_timePassed >= _timeBetweenSpawn && !_isSpawnerBusy)
        {
            _isSpawnerBusy = true;
            for (int i = 0; i < _coinsLength; i++)
            {
                _currentPos.x += 1;
                _currentPos.y = 1;
                Instantiate(CoinPref, _currentPos, Quaternion.identity);
            }

            do
            {
                _cooldown += Time.deltaTime;
            } while (_cooldown <= 3f);

            _isSpawnerBusy = false;
            _cooldown = 0f;
            _timePassed = 0;
        }
        else
            _timePassed += Time.deltaTime;
    }
}
