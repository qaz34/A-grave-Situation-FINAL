using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButonInstansiation : MonoBehaviour
{
    public GameObject button;
    // Use this for initialization
    void Start()
    {
        int count = SceneManager.sceneCountInBuildSettings;
        for (int i = 2; i < count - 1; i++)
        {
            GameObject btn = Instantiate<GameObject>(button);
            btn.transform.SetParent(transform, false);
            Text txt = btn.GetComponentInChildren<Text>();
            txt.text = "Level " + i.ToString();
            Button _btn = btn.GetComponent<Button>();
            int n = i;
            _btn.onClick.AddListener(delegate { LoadScene(n); });
        }
    }
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
