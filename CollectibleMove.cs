using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed;
    public GameObject updater;
    void Start(){
        updater = GameObject.Find("CollectibleManager");
        rotateSpeed = 5;
    }
    // Update is called once per frame
    void Update()
    {
        float speed = rotateSpeed;
        transform.Rotate(0, 90 * rotateSpeed * Time.deltaTime, 0, Space.World);
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            updater.GetComponent<CollectibleManagerScript>().updateScore();
            Destroy(this.gameObject);
        }
    }
}
