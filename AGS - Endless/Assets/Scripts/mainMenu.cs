using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class mainMenu : MonoBehaviour
{
    public List<GameObject> Menues;
    public EventSystem eventSystem;
    GameManager GM;
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    // Use this for initialization
    public void SoundChanged(float value)
    {
        GM.sounds = value;
    }
    public void MusicChanged(float value)
    {
        GM.music = value;
    }
    public void Career()
    {
        GM.career = true;
        GM.time = Time.time;
        SceneManager.LoadScene(1);
    }
    public void LoadMenu(int menu)
    {
        foreach (GameObject thisMenu in Menues)
        {
            thisMenu.SetActive(false);
        }
        Menues[menu].SetActive(true);
        eventSystem.SetSelectedGameObject(Menues[menu].GetComponentInChildren<Button>().gameObject);
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
