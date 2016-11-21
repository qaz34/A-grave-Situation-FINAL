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
    public void LeaderBoard()
    {
        if (SceneManager.GetActiveScene().name == "LeaderBoard")
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene("LeaderBoard");
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
    public void SetName(string _name)
    {
        if (_name != "")
        {
            GM.Name = _name;

            if (_name == "DRAKONSMIT")
            { SceneManager.LoadScene(9); }
            else
            {
                Career();
            }
        }
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
