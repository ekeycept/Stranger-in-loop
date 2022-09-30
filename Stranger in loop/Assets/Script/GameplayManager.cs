using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button ExitButton;

    public void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ToExit()
    {
        Application.Quit();
    }
}
