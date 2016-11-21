using UnityEngine;
using System.Collections;

public class MakeBodySound : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }

    public void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play();
    }

    public void OnTriggerEnter(Collider other)
    {
      
    }

    public void OnColliderEnter(Collider other)
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
