using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public void OnPlayButtonPressed()
    {
        Debug.Log("Play Button Pressed");
        SceneManager.LoadScene("GameScene");
    }

    public void OnMainMenuButtonPressed()
    {
        Debug.Log("Main Menu Button Pressed");
        SceneManager.LoadScene("MainMenuScene");
    }

    public void OnGameOverButtonPressed()
    {
        Debug.Log("Game Over Button Pressed");
        SceneManager.LoadScene("GameOverScene");
    }

    public void OnRestartButtonPressed()
    {
        Debug.Log("Restart Button Pressed");
        SceneManager.LoadScene("GameScene");
    }

    public void OnHowToPlayButtonPressed()
    {
        Debug.Log("How to play Button Pressed");
        SceneManager.LoadScene("HowToPlayScene");
    }

    public void OnExitButtonPressed()
    {
        Debug.Log("Exit Button Pressed");
        Application.Quit();
    }
}
