using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject optionsMenu;

    public void PlayGame()
    {
        
        SceneManager.LoadScene(1);
        Resume();
    }

    public void ContinueGame()
    {
        optionsMenu.gameObject.SetActive(false);
        Resume();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    void Resume()
    {
        Time.timeScale = 1;
        player.GameIsPaused = false;
    }
}
