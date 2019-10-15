using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    private PlayerController _player;
    private Text _scoreText;
    private int _coinsCollected;
    
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _player.OnPlayerDeath += ShowMainMenu;
        _player.CoinCollected += OnCoinCollect;
        _scoreText = FindObjectOfType<Text>();
        _coinsCollected = 0;
    }

    private void Update()
    {
      ShowScore();
    }

    private void ShowMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void ShowScore()
    {
        _scoreText.text = "Score: " + _coinsCollected.ToString();
    }
    private void OnCoinCollect()
    {
        _coinsCollected++;
    }
}
