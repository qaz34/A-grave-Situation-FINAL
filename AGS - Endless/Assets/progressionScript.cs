using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public class progressionScript : MonoBehaviour {

    public bool isCareerMode = false;
    public int currentLevel;
    int score;
    public string name = "";

    bool progress = false;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    void progression(bool levelchange, GameObject other)
    { if (isCareerMode) { currentLevel++; } progress = true; }
	// Update is called once per frame
	void Update ()
    {
	
        if(progress && isCareerMode)
        {
            progress = false;
        }
	}
}
