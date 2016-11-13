using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public GameObject firstMenu;
    // Use this for initialization
    void Start()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        if(firstMenu.GetComponent<MenuSystem>() != null && firstMenu.GetComponent<MenuSystem>().command != "")
        { }
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            firstMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            Time.timeScale = 1;
            firstMenu.SetActive(false);
        }
    }
}
