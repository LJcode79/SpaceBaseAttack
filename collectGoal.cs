using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collectGoal : MonoBehaviour
{
    public int coinsCollected = 0;
    public int enemiesKilled = 0;
    public int enemiesRemaining = 3;
    public int score = 0;
    public bool dead = false;
    public bool coinFinish = false;
    //public TextMeshProGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        coinsCollected = 0;
        enemiesKilled = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score = coinsCollected + enemiesKilled;
        if (dead == false)
        {
            (GameObject.Find("Canvas/HealthBarPanel/ScoreNumberText").GetComponent<TextMeshProUGUI>)().text = score.ToString();
            (GameObject.Find("Canvas/HealthBarPanel/EnemyNumberText").GetComponent<TextMeshProUGUI>)().text = enemiesRemaining.ToString();
            (GameObject.Find("Canvas/HealthBarPanel/CoinNumberText").GetComponent<TextMeshProUGUI>)().text = coinsCollected.ToString();
            /**
            (GameObject.Find("Canvas/score").GetComponent<TextMeshProUGUI>)().text = "Score = " + score + "\nEnemies Killed = " + 
                enemiesKilled + "\nCoins Collected = " + coinsCollected +
                "\nEnemies Remaining = " + enemiesRemaining;
            **/
            if (score == 6)
            {
                //(GameObject.Find("Canvas/score").GetComponent<TextMeshProUGUI>)().text = "You Won! Now Go to the exit!";
                coinFinish = true;
            }
        }
    }
    public void addCoin()
    {
        coinsCollected++;
    }
    public void addKill()
    {
        enemiesKilled++;
        enemiesRemaining--;
    }
}
