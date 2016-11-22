using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class PauseMenu : MonoBehaviour
{
    int state;
    public List<GameObject> menues;
    public EventSystem eventSystem;
    public void Quit()
    {
        Application.Quit();
    }
    public void loadScene(int scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        //ShowMenu(0);
        menues[0].SetActive(false);
    }
    public void Restart(bool resetFromCap)
    {
        if (resetFromCap && GameObject.FindGameObjectWithTag("GameManager") != null)
        {
            GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            gm.Money--;
        }
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ShowMenu(int _menu)
    {
        foreach (GameObject __menu in menues)
            __menu.SetActive(false);
        menues[_menu].SetActive(true);
        eventSystem.SetSelectedGameObject(menues[_menu].GetComponentInChildren<Button>().gameObject);
    }
    void Update()
    {
        if (Input.GetButtonDown("Pause") && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            ShowMenu(0);
        }
        else if (Input.GetButtonDown("Pause") && Time.timeScale == 0)
        {
            if (menues[2].activeSelf == false && menues[3].activeSelf == false)
            {
                ShowMenu(0);
                Resume();
            }
        }
    }
}

