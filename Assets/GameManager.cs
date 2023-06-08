using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerController _playerController;
    
    [SerializeField] private TMP_Text scoreValue;
    [SerializeField] private GameObject joystick;
   
    void Start()
    {
        Time.timeScale = 0;
        
    #if UNITY_ANDROID
        joystick.SetActive(true);
    #else
        joystick.SetActive(false);
    #endif
        
        InvokeRepeating(nameof(UpdateScore), 0, 0.3f);
        _playerController = FindObjectOfType<PlayerController>();
    }


    private void UpdateScore()
    {
        scoreValue.SetText($"{(int)_playerController.scoreDistance}");   
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Ramp.Clear();
        GameOverUI.Instance.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SetTimeScale(float val) => Time.timeScale = val;
}
