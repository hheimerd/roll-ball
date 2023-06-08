using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTrigger : MonoBehaviour
{
    private GameOverUI _gameOverUI { get; set; }
    private void Start()
    {
        _gameOverUI = GameOverUI.Instance;
        if (!_gameOverUI)
            enabled = false;
        _gameOverUI.gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Time.timeScale = 0;
        
        if (_gameOverUI)
            _gameOverUI.gameObject.SetActive(true);
    }
}
