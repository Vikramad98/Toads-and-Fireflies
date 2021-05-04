using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public int[] playerScores;
    [SerializeField]
    private float gameTime;
    public TextMeshProUGUI[] playerScoreTexts;
    [SerializeField]
    private TextMeshProUGUI TimerText;

    public TextMeshProUGUI winText;

    public GameObject GameOverPAnel;
    // Start is called before the first frame update
    void Start()
    {
        playerScores = new int[2];
        GameOverPAnel.SetActive(false);
    }

    public void addPoints(int player,int amount)
    {
        playerScores[player] += amount;
        //update UI

    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;
        TimerText.text = gameTime.ToString("00.0");
        if (gameTime <= 0)
        {
            
            GameOverPAnel.SetActive(true);
            Time.timeScale = 0;
            int winner = playerScores[0] > playerScores[1] ? 1 : 2;
            winText.text ="Player " +winner.ToString()+ " Won!";
        }

        updateUI();
    }

    private void updateUI()
    {
        playerScoreTexts[0].text =playerScores[0].ToString();
        playerScoreTexts[1].text =playerScores[1].ToString();
    }

    public void Restart()
    {
        if (Input.anyKey)
        {
            return;
        }
        playerScores[0] = 0;
        playerScores[1] = 0;
        gameTime = 30;
        Time.timeScale = 1;
        GameOverPAnel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
