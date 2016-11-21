using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour
{
    public AudioClip dig;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (GameObject.FindGameObjectWithTag("GameManager") != null)
            audioSource.volume = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().sounds;
    }
    // Use this for initialization
    public void PlayDig()
    {
        if (dig != null)
        {
            GetComponent<AudioSource>().clip = dig;
            GetComponent<AudioSource>().Play();
        }
    }
}
