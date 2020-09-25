using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
}
