using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinEn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            GameObject.Find("Player").GetComponent<goal>().addCoin();
            Destroy(transform.gameObject);
        }
    }
}
