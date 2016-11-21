using UnityEngine;
using System.Collections;

public class countScript : MonoBehaviour {

    public bool countMe = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(countMe)
        { Debug.Log("Count." + gameObject.name); countMe = false; }
	
	}
}
