using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour
{
    public GameObject popup;
    // Use this for initialization
    void Start()
    {
        popup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //popup.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            popup.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
            popup.SetActive(true);
        }
    }
}
