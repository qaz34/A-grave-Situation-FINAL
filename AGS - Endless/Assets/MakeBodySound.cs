using UnityEngine;
using System.Collections;

public class MakeBodySound : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }
}
