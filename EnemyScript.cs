using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;
    public Animator anim;
    bool chasing = true;
    public TextMeshPro damageText;
    public GameObject healthBar;
    public GameObject healthText;
    public GameObject explostion;
    private float maxHealth = 100f;
    private float currentHealth = 100f;
    

    // Update is called once per frame
    void Start(){
        agent.speed = 8;
        agent.SetDestination(player.transform.position);       
    }
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            anim.SetBool("isAttacking", true);
            chasing = false;
            //other.gameObject.GetComponent<Animator>().SetBool("isAttacked", true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            anim.SetBool("isAttacking", false);
            chasing = true;
            //other.gameObject.GetComponent<Animator>().SetBool("isAttacked", false);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("COLLIDE!");
        if (col.gameObject.tag == "Bullet")
        {
            Debug.Log("COLLIDE!");
            takeDamage(50);
        }
    }

    public void takeDamage(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            //GameObject.Find("CollectibleManager").GetComponent<CollectibleManagerScript>().updateEnemy();
            GameObject.Find("Player").GetComponent<goal>().addKill();
            player.gameObject.GetComponent<Animator>().SetBool("isAttacked", false);
            Instantiate(explostion, transform.position, transform.rotation);
            Destroy(this.gameObject);

        }
        healthText.GetComponent<Text>().text = ((int)currentHealth).ToString();
        healthBar.GetComponent<Image>().fillAmount = currentHealth / maxHealth;
        TextMeshPro dmgText = Instantiate(damageText);
        dmgText.transform.SetParent(this.transform, false);
        dmgText.text = "-" + damage.ToString();
        Destroy(dmgText.gameObject, .5f);
    }
}
