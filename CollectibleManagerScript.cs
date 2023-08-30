using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectibleManagerScript : MonoBehaviour
{
    int score = 0;
    int enemies = 3;
    public GameObject UIScoreCount;
    public GameObject UIEnemyCount;
    public GameObject gameOverText;
    public GameObject player;
    // Start is called before the first frame update

    void Update(){
        if(isGameOver()){
            player.GetComponent<PlayerScript>().enabled = false;
            gameOverText.SetActive(true);
        }
    }
    public void updateScore(){
        score++;
        UIScoreCount.GetComponent<TextMeshProUGUI>().text = score.ToString() + "/5";
    }
    public void updateEnemy(){
        enemies--;
        UIEnemyCount.GetComponent<TextMeshProUGUI>().text = "Enemies: " + enemies.ToString() + "/3";
    }

    bool isGameOver(){
        return score == 5 && enemies == 0;
    }
    
}
