using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UImanager : MonoBehaviour
{
   public GameObject PauseMenu;
   public GameObject GameOverMenu;
    public Player p;
   public void pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void home()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void Update()
    {
        if(p.IsGameOver==true)
        {
            GameOverMenu.SetActive(true);
        }
    }
}
