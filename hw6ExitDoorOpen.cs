using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class hw6ExitDoorOpen : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent doorExitEvent;
    #region Attributes

    public Transform door;

    public Transform image;

    public Vector3 exitclosedPosition = new Vector3(-32.02f, 4.89f, 35.38f);
    public Vector3 exitopenedPosition = new Vector3(-32.02f, 10f, 35.38f);
    //Vector3(-32.0172997,4.89281273,35.3826752)
    public float openSpeed = 5;

    public bool open = false;

    #endregion

    #region Monobehaviour API

    // Start is called before the first frame update
    /*
    void Start()
    {
        
    }
    */

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            door.position = Vector3.Lerp(door.position, exitopenedPosition, Time.deltaTime * openSpeed);
        }
        else
        {
            door.position = Vector3.Lerp(door.position, exitclosedPosition, Time.deltaTime * openSpeed);
        }
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && (GameObject.Find("Player").GetComponent<goal>().finishGame == true))
        {
            OpenDoor();
            doorExitEvent.Invoke();
            (GameObject.Find("Canvas/Prompt/DoorLockedText").GetComponent<TextMeshProUGUI>)().text = "done";
        }
        else if(other.tag == "Player" && (GameObject.Find("Player").GetComponent<goal>().finishGame == false))
        {
            if ((GameObject.Find("Player").GetComponent<goal>().enemiesRemaining > 0) && (GameObject.Find("Player").GetComponent<goal>().coinsCollected < 6))
            {
                //GameObject.Find("Canvas/Prompt").SetActive(true);
                //GameObject prompt = GameObject.Find("Canvas/Prompt");
                //prompt.active = true;
                //GameObject.Find("Canvas").transform.FindChild("Prompt").SetActive(true);
                Image image = GameObject.Find("Canvas/Prompt").GetComponent<Image>();
                image.enabled = true;
                (GameObject.Find("Canvas/Prompt/DoorLockedText").GetComponent<TextMeshProUGUI>)().enabled = true;
                //Debug.Log("TESTSTSTSTS");
                (GameObject.Find("Canvas/Prompt/DoorLockedText").GetComponent<TextMeshProUGUI>)().text = "coins still remaining: " + (6 - (GameObject.Find("Player").GetComponent<goal>().coinsCollected) + "\nenemies still remaining: " + (GameObject.Find("Player").GetComponent<goal>().enemiesRemaining));


            }
            else
            {
                Debug.Log("enemies" + GameObject.Find("Player").GetComponent<goal>().enemiesRemaining);
                Debug.Log("coins" + GameObject.Find("Player").GetComponent<goal>().coinsCollected);
                if (GameObject.Find("Player").GetComponent<goal>().coinsCollected < 6)
                {
                    Image image = GameObject.Find("Canvas/Prompt").GetComponent<Image>();
                    (GameObject.Find("Canvas/Prompt/DoorLockedText").GetComponent<TextMeshProUGUI>)().enabled = true;
                    image.enabled = true;
                    (GameObject.Find("Canvas/Prompt/DoorLockedText").GetComponent<TextMeshProUGUI>)().text = "coins still remaining: " + (6 - (GameObject.Find("Player").GetComponent<goal>().coinsCollected));
                }
                else if (GameObject.Find("Player").GetComponent<goal>().enemiesRemaining > 0)
                {
                    Image image = GameObject.Find("Canvas/Prompt").GetComponent<Image>();
                    (GameObject.Find("Canvas/Prompt/DoorLockedText").GetComponent<TextMeshProUGUI>)().enabled = true;
                    image.enabled = true;
                    (GameObject.Find("Canvas/Prompt/DoorLockedText").GetComponent<TextMeshProUGUI>)().text = ("enemies still remaining: " + (GameObject.Find("Player").GetComponent<goal>().enemiesRemaining));
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Image image = GameObject.Find("Canvas/Prompt").GetComponent<Image>();
            (GameObject.Find("Canvas/Prompt/DoorLockedText").GetComponent<TextMeshProUGUI>)().text = "";
            image.enabled = false;
            CloseDoor();
            Debug.Log("Player has gone through door");
        }
    }

    public void CloseDoor()
    {
        open = false;
    }

    public void OpenDoor()
    {
        open = true;
    }

}
