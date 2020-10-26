using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverBehavour : MonoBehaviour
{
    public static int userScore = 0;
    public TextMeshProUGUI userScoreText;
    // Start is called before the first frame update
    void Start()
    {
        userScore = PlayerStats.userScore;
        userScoreText.text = "Final Score: " + userScore.ToString();
    }
}
