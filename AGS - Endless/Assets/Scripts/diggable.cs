﻿using UnityEngine;
using System.Collections;

public class diggable : Seeable
{
    [Tooltip("The object for the top of the grave")]
    public Transform graveTop;
    [Tooltip("The object for the popup")]
    public Transform Popup;
    [Tooltip("how fast this grave will be lowered")]
    public float digSpeed;
    [Tooltip("How far the grave needs to be dropped")]
    public float dropDistance = 3;
    [Tooltip("How much money this grave is worth")]
    public int value;
    [Tooltip("The low value of the random")]
    public int Low = 1;
    [Tooltip("The high value of the random")]
    public int High = 10;
    private float completion;
    [Tooltip("the percentage complete")]
    public float percentComplete;
    private bool complete = false;
    [Tooltip("If the body has been collected")]
    public bool collected = false;
    //public GameObject part;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (value == 0)
            value = Random.Range(Low, High);

    }

    public void OnTriggerExit(Collider other)
    {
        Popup.gameObject.SetActive(false);
    }
    public void OnTriggerStay(Collider other)
    {
        if (collected)
            Popup.gameObject.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (!collected)
            Popup.gameObject.SetActive(true);
    }

    public IEnumerator dig()
    {
        while (true)
        {
            if (collected == false && complete == true)
            {
                collected = true;
                player.GetComponent<PlayerCont>().carry(value);
            }
            else if (completion >= dropDistance)
            {
                complete = true;
                Camera.main.GetComponent<CameraFollow>().reset();
                break;
            }
            else
            {
                Camera.main.GetComponent<CameraFollow>().zoom();
                completion += digSpeed;
                graveTop.position = new Vector3(graveTop.position.x, graveTop.position.y - digSpeed, graveTop.position.z);
                percentComplete = Mathf.Floor(completion / dropDistance * 100);
            }
            yield return new WaitForFixedUpdate();
        }
    }
    public override bool Seen(string tag)
    {
        if (percentComplete > 30 && !alreadySeen && tag == "diggable")
        {
            return true;
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
