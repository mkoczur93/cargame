namespace MainProject.UI
{
    using RacingMap;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class LapTimeResult : MonoBehaviour
    {
        //private static LapTimeResult instance = null;
        //public static LapTimeResult Instance { get => instance; set => instance = value; }

        private void Start()
        {
            this.GetComponent<TMPro.TextMeshProUGUI>().text = LapTimeSystem.Instance.LastLapTime();
        }
       // public void Init(string text)
       // {
       //     this.GetComponent<TMPro.TextMeshProUGUI>().text = text;

      //  }
       // private void Awake()
        //{
       //     instance = this;
        //}
        // Update is called once per frame

    }
}