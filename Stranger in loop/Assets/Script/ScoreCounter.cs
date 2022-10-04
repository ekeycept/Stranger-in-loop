using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using System;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Text ScoreText;
    [SerializeField] private GameObject Player;
    void Update()
    {
        if (Player != null)
        {
            int score = Convert.ToInt32(Player.transform.position.z / 4.6f);
            ScoreText.text = Convert.ToString(score);
        }
    }
}
