using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class CoinSounds : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip fling;
    public AudioClip land;
    bool hit = false;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = fling;
        audioSource.Play();
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (!hit)
        {
            audioSource.clip = land;
            audioSource.Play();
        }
        hit = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= .02)
        {

        }
    }
}
