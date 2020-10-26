using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static int userMoney=0;
    public int startingMoney = 200;
    public static int userHealth=0;
    public int startingHealth = 100;
    public static int userScore = 0;

    public TextMeshProUGUI userMoneyText;
    public TextMeshProUGUI userHealthText;
    public TextMeshProUGUI userScoreText;
    //Setting the user money to starting money because 2nd play through user will be left off with whatever they had last playthrough
    private void Start()
    {
        userMoney = startingMoney;
        userHealth = startingHealth;
        userScore = 0;
    }
    //Constantly updating UI (Probably a better way to do this)
    public void Update()
    {
        userMoneyText.text = userMoney.ToString();
        userHealthText.text = userHealth.ToString();
        userScoreText.text ="Score: "+userScore.ToString();
    }
}
