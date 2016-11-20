//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using System.Xml.Serialization;
//using System.IO;

//public class MainAndPause : MonoBehaviour {

//    public bool isMainMenu = false;
//    public List<GameObject> main = new List<GameObject>();
//    int[] mainActive = { 1, 3, 4, 5, 6, 7, 8 };
//    int[] pauseActive = { 0, 1, 2, 3, 5, 7 };


//    bool gamePause = true;
//    public Scene scenes;
//    int num_CurrentSlot = 0;
//    int levelCount = 0;
//    saves stats;
//    public int moneyCurrent = 2000;
//    public string myName = "Default";

//    public enum GameType // your custom enumeration
//    { SaveOrLoad_System, Career, Leaderboards };
//    public GameType dropDown = GameType.Career;

//    public List<GameObject> buttons_FirstSet = new List<GameObject>();
//    public List<GameObject> buttons_SecondSet = new List<GameObject>();
//    public InputField username;

//    public List<GameObject> careersModeSwitch = new List<GameObject>();

//    public List<string> firstSet = new List<string>();

//    int numeric = 0;
//    string commons = "";
//    public string command = "";
//    public bool comGo = false;
//    bool escapeOther = false;

//    bool enter = true;
//    bool exit = false;
//    void Start()
//    {
//        //children = buttons_SecondSet[0].GetComponentsInChildren<GameObject>(false);
//        stats = new saves();
//        //       stats.saveslots[0] = new playerStats("super jeffry");
//        stats.saveslots[num_CurrentSlot].money = moneyCurrent;
//        //quit();
//        firstSet.Add("resume"); //0
//        firstSet.Add("new"); //1
//        firstSet.Add("save"); //2
//        firstSet.Add("load"); //3
//        firstSet.Add("options"); //4
//        firstSet.Add("leaderboard"); //5
//        firstSet.Add("credits"); //6
//        firstSet.Add("main0");
//                                 //switch (GameType.SaveOrLoad_System)
//                                 //{  case }
//        foreach (GameObject buttons in buttons_FirstSet)
//        { if (buttons != null) { buttons.SetActive(false); } }
//        if (isMainMenu)
//        {
//            foreach (int i in mainActive)
//            { if (buttons_FirstSet[i] != null) { buttons_FirstSet[i].SetActive(true); } }
//        }
//        else
//        {
//            foreach (int i in pauseActive)
//            { buttons_FirstSet[i].SetActive(true); }
//        }

//        if (dropDown == GameType.Career)
//        {
//            //foreach(GameObject obj in children)
//            //{ obj.SetActive(false); }
//            foreach (GameObject obj in careersModeSwitch)
//            { obj.SetActive(false); Debug.Log("Test"); }
//        }
//    }

//    public void resume()
//    { SceneManager.LoadScene(levelCount); }

//    public void levelSelection()
//    {/*Level selection screen, advanced click?*/
//        Debug.Log("Testing");
//    }

//    public void slots(int slotSelect)
//    {
//        //Debug.Log("Slots active! ");
//        //int i = 0;
//        if (enter)
//        {
//            foreach (GameObject but in buttons_FirstSet)
//            { but.SetActive(false); }
//            buttons_SecondSet[0].SetActive(true);
//            enter = false;
//        }
//        //Debug.Log("number_CurrentSlot: " + num_CurrentSlot);
//        if (slotSelect != 0)
//        { num_CurrentSlot = slotSelect; }
//        if (num_CurrentSlot != 0)
//        {
//            if (command.Contains("new"))
//            {
//                if (!escapeOther)
//                {
//                    GameObject[] children = buttons_SecondSet[0].GetComponentsInChildren<GameObject>();
//                    // foreach(c)
//                    foreach (GameObject child in children)
//                    {
//                        Debug.Log(child.gameObject);
//                        if (child.gameObject != buttons_SecondSet[0])
//                            child.gameObject.SetActive(false);
//                    }

//                    //while (buttons_SecondSet[0].ch)
//                    escapeOther = true;
//                    username.gameObject.SetActive(true);
//                }

//                Debug.Log("Taste test username access: " + username.text);

//                if (username.text != "" && Input.GetKeyDown(KeyCode.Return)) //Cameron to upgrade for Control pad. Text field.
//                {
//                    Debug.Log("Test and Check username access after enter!");
//                    stats.saveslots[slotSelect] = new playerStats(username.text);
//                    levelCount = 1;
//                    SceneManager.LoadScene(levelCount);
//                }
//                else if (username.text == "" && Input.GetKeyDown(KeyCode.Return))
//                {
//                    Debug.Log("Test and Check username access after enter!");
//                    stats.saveslots[slotSelect] = new playerStats(myName);
//                    levelCount = 1;
//                    SceneManager.LoadScene(levelCount);
//                }
//                if (escapeOther && Input.GetKeyDown(KeyCode.Escape))
//                {


//                    num_CurrentSlot = 0;
//                    escapeOther = false;
//                    username.gameObject.SetActive(false);
//                }
//            }


//            if (command.Contains("save"))
//            {

//                System.Type type = typeof(saves);
//                XmlSerializer serilizer = new XmlSerializer(type);
//                StreamWriter writer = new StreamWriter("../ProfileInfomation");
//                Debug.Log("Writing Information");
//                serilizer.Serialize(writer, stats);
//                writer.Close();
//            }
//            if (command.Contains("load"))
//            {

//                levelCount = stats.saveslots[num_CurrentSlot - 1].lvl;
//                moneyCurrent = stats.saveslots[num_CurrentSlot - 1].money;
//                myName = stats.saveslots[num_CurrentSlot - 1].name;
//                SceneManager.LoadScene(levelCount);
//            }
//        }



//    }

//    void careersMode()
//    {

//        if (enter)
//        {
//            buttons_SecondSet[0].SetActive(true);
//            foreach (GameObject but in buttons_FirstSet)
//            { but.SetActive(false); }

//            username.gameObject.SetActive(true);
//            enter = false;
//        }

//        if (username.text != "" && Input.GetKeyDown(KeyCode.Return)) //Cameron to upgrade for Control pad. Text field.
//        {

//            levelCount = 1;
//            SceneManager.LoadScene(levelCount);
//        }

//        if (escapeOther && Input.GetKeyDown(KeyCode.Escape))
//        {

//            escapeOther = false;
//            username.gameObject.SetActive(false);
//        }

//    }

//    public void leaderboards()
//    {
//        Debug.Log("Leaderboards called.");
//        if (enter)
//        {
//            foreach (GameObject but in buttons_FirstSet)
//            { but.SetActive(false); }
//            buttons_SecondSet[1].gameObject.SetActive(true);
//            buttons_SecondSet[1].SetActive(true);
//            enter = false;
//        }
//    }

//    public void options()
//    {
//        if (enter)
//        {
//            foreach (GameObject but in buttons_FirstSet)
//            { but.SetActive(false); }
//            buttons_SecondSet[2].gameObject.SetActive(true);
//            buttons_SecondSet[2].SetActive(true);
//            enter = false;
//        }
//    }

//    public void credits()
//    {
//        if (enter)
//        {
//            foreach (GameObject but in buttons_FirstSet)
//            { but.SetActive(false); }
//            buttons_SecondSet[3].gameObject.SetActive(true);
//            buttons_SecondSet[3].SetActive(true);
//            enter = false;
//        } //DEFAULT Load new buttons and unload old from first and second.
//    }

//    public void quit()
//    {

//        if (command.Contains(firstSet[6]))
//        { SceneManager.LoadScene(0); }
//        else
//        {
//            Debug.Log("Quit");
//            Application.Quit();
//        }
//    }
//    public void ButtonActive(string name)
//    {

//        if (name != "")
//        {
//            //int i = 0;
//            foreach (string function in firstSet)
//            {
//                if (name == function)
//                { command = function; }

//                // i++;
//            }
//            comGo = false;
//        }
//    }


//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Escape) && !escapeOther)
//        {
//            if (enter == false)
//            { exit = true; command = ""; }
//            ///Make's no sense for the player to press escape and go stright into the game. More likely to quit are you sure?
//            else if (gamePause)
//            {
//                Time.timeScale = 1;
//                gamePause = false;
//            }
//        }

//        if (command != "" && comGo != true)
//        {
//            Debug.Log("Check comGo!");
//            int i = 0;
//            foreach (string com in firstSet)
//            {
//                if (command == com)//Slots screen via (new/load/save)
//                { Debug.Log("Check return; " + i); break; }
//                i++;
//            }
//            Debug.Log("Do i get here? " + i);
//            if (firstSet[i] == firstSet[1] || firstSet[i] == firstSet[2] || firstSet[i] == firstSet[3])
//            { // (new/load/save)
//                //if(firstSet is == firstSet[1])
//                if (firstSet[i] == firstSet[1])
//                { command = "slots/new"; }//"slots/new"
//                if (firstSet[i] == firstSet[2])
//                { command = "slots/save"; } //"slots/save"
//                if (firstSet[i] == firstSet[3])
//                { command = "slots/load"; } //"slots/load
//            }
//            if (command.Contains(firstSet[5]))
//            { leaderboards(); }
//            if (command.Contains(firstSet[4]))
//            { options(); }
//            if (command.Contains(firstSet[6]))
//            { credits(); }

//            if (command.Contains("slots/"))
//            {

//                if (dropDown == GameType.SaveOrLoad_System)
//                {
//                    foreach (GameObject obj in careersModeSwitch)
//                    { obj.SetActive(true); }
//                    slots(0);
//                }
//                if (dropDown == GameType.Career)
//                {
//                    careersMode();
//                }

//            }
//            if (command.Contains("levelselect")) { levelSelection(); }
//            comGo = true;
//        }
//        else if (/*buttons_FirstSet[4].activeInHierarchy != true && */command == "")
//        {

//            if (isMainMenu)
//            {
//                foreach (int i in mainActive)
//                { if (buttons_FirstSet[i] != null) { buttons_FirstSet[i].SetActive(true); } }
//            }
//            else
//            {
//                foreach (int i in pauseActive)
//                { if (buttons_FirstSet[i] != null) { buttons_FirstSet[i].SetActive(true); } }
//            }

//            foreach (GameObject but in buttons_SecondSet)
//            { if (but != null){ but.SetActive(false); } }

//            buttons_SecondSet[0].SetActive(false);
//            username.gameObject.SetActive(false);

//            enter = true;
//            if (dropDown == GameType.Career)
//            {

//                foreach (GameObject obj in careersModeSwitch)
//                { obj.SetActive(false); }
//                if (!isMainMenu)
//                {
//                    foreach (GameObject o in main)
//                    { o.SetActive(false); }
//                }
//            }
//        }

//    }

//}
