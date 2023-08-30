using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class goal : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent killed;
    public int coinsCollected = 0;
    public int enemiesKilled = 0;
    public int enemiesRemaining = 3;
    public int score = 0;
    public bool dead = false;
    public bool finishGame = false;
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
            //(GameObject.Find("Canvas/HealthBarPanel").GetComponent<TextMeshProUGUI>)().text = "Score = " + score + "\nEnemies Killed = " +
            //EnemyNumberText + "\nCoins Collected = " + CoinNumberText; //+
            //"\nEnemies Remaining = " + enemiesRemaining;
            if (score == 9)
            {
                //(GameObject.Find("Canvas/score").GetComponent<TextMeshProUGUI>)().text = "You Won! Now Go to the exit!";
                finishGame = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "weapon")
        {
            killed.Invoke();
            Debug.Log("killed");
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
