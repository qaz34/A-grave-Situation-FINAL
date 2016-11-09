using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        
    }
    public void StartBtn()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }
    public void LeaderBoard()
    {

    }
    public void Options()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
