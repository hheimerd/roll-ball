using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
   private static GameOverUI _instance;
   [SerializeField] private TMP_Text score;

   public static GameOverUI Instance
   {
      get
      {
         if (!_instance)
         {
            _instance = Resources.FindObjectsOfTypeAll<GameOverUI>()?[0];
         }

         return _instance;
      }
      private set => _instance = value;
   }

   private void Awake()
   {
      _instance = this;
   }

   private void OnEnable()
   {
      score.text = $"{(int)PlayerController.Instance.scoreDistance}";
   }
}
