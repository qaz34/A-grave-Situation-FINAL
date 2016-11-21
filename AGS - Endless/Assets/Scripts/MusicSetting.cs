using UnityEngine;
using System.Collections;

public class MusicSetting : MonoBehaviour
{
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("GameManager") != null)
            GetComponent<AudioSource>().volume *= GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().music;
    }
}
