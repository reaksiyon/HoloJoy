using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public GameObject BlackPanel, YouWinText, YouLoseText;

    private GameObject Music;

    public TMPro.TextMeshProUGUI playerScore, enemyScore;

    public Image playerHealthFiller, enemyHealthFiller;

    private int pScore = 0, eScore = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerScore.text = "Score: " + pScore;

        enemyScore.text = "Score: " + eScore;

        Music = GameObject.Find("Music");
    }


    public void PlayerGetScore()
    {
        pScore++;

        playerScore.text = "Score: " + pScore;

        if (pScore >= 10)
        {
            PlayerWin();
        }
    }

    public void EnemyGetScore()
    {
        eScore++;

        enemyScore.text = "Score: " + eScore;

        if (eScore >= 10)
        {
            EnemyWin();
        }
    }

    public void PlayerSetHealth(float curHP, float maxHP)
    {
        playerHealthFiller.fillAmount = curHP / maxHP;
    }

    public void EnemySetHealth(float curHP, float maxHP)
    {
        enemyHealthFiller.fillAmount = curHP / maxHP;
    }

    public void PlayerWin()
    {
        Destroy(Music);

        BlackPanel.SetActive(true);

        YouWinText.SetActive(true);
    }

    public void EnemyWin()
    {
        Destroy(Music);

        BlackPanel.SetActive(true);

        YouLoseText.SetActive(true);
    }

    public static GUIManager Instance;
}
