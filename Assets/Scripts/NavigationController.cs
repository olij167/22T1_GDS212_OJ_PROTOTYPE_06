using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigationController : MonoBehaviour
{
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController player;

    public Button startButton, quitButton, restartButton;

    public GameObject gameTitle;

    private void Start()
    {
        player.enabled = false;

        //Time.timeScale = ;
    }
    public void StartGame()
    {
        player.enabled = true;
    }

    public void RestartGame()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
