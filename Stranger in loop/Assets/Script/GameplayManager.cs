using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button ExitButton;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Pause();
    }

    public void Pause()
    {
        if (isPaused == false)
        {
            isPaused = true;
            Time.timeScale = 0;
            PlayButton.gameObject.SetActive(true);
            ExitButton.gameObject.SetActive(true);
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
            PlayButton.gameObject.SetActive(false);
            ExitButton.gameObject.SetActive(false);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ToExit()
    {
        Application.Quit();
    }
}
