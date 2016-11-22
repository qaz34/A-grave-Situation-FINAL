using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour
{
    public GameObject popup;
    void Start()
    {
        popup.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (tag == "DropOff")
            {
                if (other.GetComponent<PlayerCont>().carryMoneh > 0)
                {
                    popup.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
                    popup.SetActive(true);
                }
                else
                {
                    popup.SetActive(false);
                }
            }
            else
            {
                popup.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
                popup.SetActive(true);
            }
        }

    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (tag == "DropOff")
            {
                if (other.GetComponent<PlayerCont>().carryMoneh > 0 || GameObject.FindGameObjectWithTag("Objective").GetComponent<objective>().ObjectiveNum <= GameObject.FindGameObjectWithTag("Objective").GetComponent<objective>().Complete)
                {
                    popup.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
                    popup.SetActive(true);
                }
                else
                {
                    popup.SetActive(false);
                }
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        popup.SetActive(false);
    }
}
