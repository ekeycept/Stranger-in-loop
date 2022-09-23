using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highscore;

    private void Awake()
    {
        LoadScore();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            SaveScore();
    }

    public void SaveScore()
    {
        if (Convert.ToInt32(highscore.text) < Convert.ToInt32(scoreText.text))
        {
            SaveData savedata = new();
            BinaryFormatter bf = new();
            FileStream file = File.Create(Application.persistentDataPath + "/MyScoreData.dat");
            savedata.highscore = Convert.ToInt32(scoreText.text);
            bf.Serialize(file, savedata);
            file.Close();
            Debug.Log("Game data saved!");
        }
        else
            Debug.Log("You have a better highscore!");
    }

    private void LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + "/MyScoreData.dat"))
        {
            BinaryFormatter bf = new();
            FileStream file = File.Open(Application.persistentDataPath + "/MyScoreData.dat", FileMode.Open);
            SaveData savedata = (SaveData)bf.Deserialize(file);
            file.Close();
            highscore.text = Convert.ToString(savedata.highscore);
            Debug.Log("Game data loaded!");
        }
        else
            Debug.Log("There is no saved data!");
    }
}