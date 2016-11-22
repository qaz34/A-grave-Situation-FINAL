using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public string Name;
    public int Money;
    public float time;
    public float music;
    public float sounds;
    public bool career = false;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    public void NextLvl(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }    
    public void SetName(string name)
    {
        Name = name;
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "menu")
        {
            Money = 3;
        }
    }

}
