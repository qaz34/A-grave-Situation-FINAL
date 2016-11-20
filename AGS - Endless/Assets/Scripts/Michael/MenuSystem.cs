//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using System.Xml.Serialization;
//using System.IO;



////[SerializeField]
//[System.Serializable()]
//public class saves //Save files and games data.
//{
//    private int m_saveSlots = 3;
//    public List<playerStats> saveslots;
//    public saves()
//    {
//        saveslots = new List<playerStats>(m_saveSlots);
//        saveslots.Add(new playerStats("Player1", 5, 2));
//        saveslots.Add(new playerStats("Player2", 5, 2));
//        saveslots.Add(new playerStats("Player3", 5, 2));
//    }
//}
//public class playerStats
//{
//    public string name;
//    public int money;
//    public int lvl;

//    public playerStats()
//    {

//    }
//    public playerStats(int moneyCurrent, int level)
//    {
//        money = moneyCurrent;
//        lvl = level;
//    }
//    public playerStats(string _name)
//    {
//        name = _name;
//    }
//    public playerStats(string _name, int moneyCurrent, int level)
//    {
//        name = _name;
//        money = moneyCurrent;
//        lvl = level;
//    }



//}

//public class MenuSystem : MonoBehaviour
//{

//   // [SerializeField]
//    //public bool testExperiment = false; //Will it save infomation during runtime?
//    public bool isMainMenu = false;
//    public List<GameObject> main = new List<GameObject>();
//    int[] mainActive = {1,3,4,5,6,7,8,9};
//    int[] pauseActive = {0,1,2,3,5,7,11};

//    public GameObject scoreCarrierCarrers;

//    bool gamePause = true;
//    public Scene scenes;
//    //public int Checktest = 3;
//    int num_CurrentSlot = 0;
//    int levelCount = 0;
//    saves stats;
//    public int moneyCurrent = 2000;
//    public string myName = "Default";


//    //private string[] gameType = {"Save/Load system", "Career", "Leaderboards" };
    
<<<<<<< HEAD
    public enum GameType // your custom enumeration
    {  SaveOrLoad_System, Career, Leaderboards   };
    public GameType dropDown = GameType.Career;



    //public GameObject[] children/* = buttons_SecondSet[0].GetComponentsInChildren<Transform>()*/;

    public List<GameObject> buttons_FirstSet = new List<GameObject>();
    public List<GameObject> buttons_SecondSet = new List<GameObject>();
    public InputField username;

    public List<GameObject> careersModeSwitch = new List<GameObject>();

    public List<string> firstSet = new List<string>();

    //static void dropDownModes()
    //{
    //int selection = 0;
    //public string[] gameType = new string[] {"Save based gameplay", "Without Saves", "Leaderboards ONLY!"};
    //selection = EditorGUILayout.Popup("Game Type: ", selection, gameType);
    //    }
    //public string[] gameType = new string[3] { "Save based gameplay", "Without Saves", "Leaderboards ONLY!" };

    int numeric = 0;
    string commons = "";
    public string command = "";
    public bool comGo = false;
    bool escapeOther = false;

    bool enter = true;
    bool exit = false;
    //public List<Button> new_Off = new List<Button>();
    //public List<Button> save_Off = new List<Button>();
    //public List<Button> load_Off = new List<Button>();
    //public List<Button> options_Off = new List<Button>();
    //public List<Button> credits_Off = new List<Button>();



    void Start()
    {
        //children = buttons_SecondSet[0].GetComponentsInChildren<GameObject>(false);
        stats = new saves();
        //       stats.saveslots[0] = new playerStats("super jeffry");
        stats.saveslots[num_CurrentSlot].money = moneyCurrent;
        //quit();
        firstSet.Add("resume"); //0
        firstSet.Add("new"); //1
        firstSet.Add("save"); //2
        firstSet.Add("load"); //3
        firstSet.Add("options"); //4
        firstSet.Add("leaderboard"); //5
        firstSet.Add("credits"); //6
        firstSet.Add("main0");
        firstSet.Add("levelselect");
        firstSet.Add("lodlevel");
        firstSet.Add("return");
        firstSet.Add("career");
        //switch (GameType.SaveOrLoad_System)
        //{  case }
        foreach (GameObject buttons in buttons_FirstSet)
        { if (buttons != null) { buttons.SetActive(false); } }
        if (isMainMenu)
        {
            foreach (int i in mainActive)
            { if(buttons_FirstSet[i] != null) { buttons_FirstSet[i].SetActive(true); } }
        }
        else
        {
            foreach (int i in pauseActive)
            { if (buttons_FirstSet[i] != null) buttons_FirstSet[i].SetActive(true); }
        }

        if (dropDown == GameType.Career)
        {
            //foreach(GameObject obj in children)
            //{ obj.SetActive(false); }
            foreach (GameObject obj in careersModeSwitch)
            { obj.SetActive(false);  }
        }

        if(scoreCarrierCarrers == null) { scoreCarrierCarrers = GameObject.Find("PROGRESS BROTHER"); }
    }



    public void resume()
    {
        {
            Debug.Log("Resuming!");

            Time.timeScale = 1;
            gamePause = false;
            

        }
    }
    public void slots(int slotSelect)
    {
        //Debug.Log("Slots active! ");
        //int i = 0;
        if (enter)
        {
            foreach (GameObject but in buttons_FirstSet)
            { but.SetActive(false); }
            buttons_SecondSet[0].SetActive(true);
            enter = false;
        }
        //Debug.Log("number_CurrentSlot: " + num_CurrentSlot);
        if (slotSelect != 0)
        { num_CurrentSlot = slotSelect; }
        if (num_CurrentSlot != 0)
        {            
            if (command.Contains("new"))
            {
                if (!escapeOther)
                {
                    GameObject[] children = buttons_SecondSet[0].GetComponentsInChildren<GameObject>();
                    // foreach(c)
                    foreach (GameObject child in children)
                    {
                        Debug.Log(child.gameObject);
                        if (child.gameObject != buttons_SecondSet[0])
                            child.gameObject.SetActive(false);
                    }

                    //while (buttons_SecondSet[0].ch)
                    escapeOther = true;
                    username.gameObject.SetActive(true);
                }

                Debug.Log("Taste test username access: " + username.text);

                if (username.text != "" && Input.GetKeyDown(KeyCode.Return)) //Cameron to upgrade for Control pad. Text field.
                {
                    Debug.Log("Test and Check username access after enter!");
                    stats.saveslots[slotSelect] = new playerStats(username.text);
                    levelCount = 1;
                    SceneManager.LoadScene(levelCount);
                }
                else if (username.text == "" && Input.GetKeyDown(KeyCode.Return))
                {
                    Debug.Log("Test and Check username access after enter!");
                    stats.saveslots[slotSelect] = new playerStats(myName);
                    levelCount = 1;
                    SceneManager.LoadScene(levelCount);
                }
                if (escapeOther && Input.GetKeyDown(KeyCode.Escape))
                {

                    // foreach(c)
                    //foreach (GameObject child in children)
                    //{
                    //    Debug.Log(child);
                    //    if (child != buttons_SecondSet[0])
                    //    {
                    //        child.SetActive(true);
                    //    }
                    //}
                    num_CurrentSlot = 0;
                    escapeOther = false;
                    username.gameObject.SetActive(false);
                }
            }
            //if (command.Contains("new/1"))
            //{

            //}

            if (command.Contains("save"))
            {
                //                //stats.saveslots[num_CurrentSlot](myName, moneyCurrent, levelCount);

                System.Type type = typeof(saves);
                XmlSerializer serilizer = new XmlSerializer(type);
                StreamWriter writer = new StreamWriter("../ProfileInfomation");
                Debug.Log("Writing Information");
                serilizer.Serialize(writer, stats);
                writer.Close();
            }
            if (command.Contains("load"))
            {

                levelCount = stats.saveslots[num_CurrentSlot - 1].lvl;
                moneyCurrent = stats.saveslots[num_CurrentSlot - 1].money;
                myName = stats.saveslots[num_CurrentSlot - 1].name;
                SceneManager.LoadScene(levelCount);
            }
        }



    }

    void careersMode()
    {

        if (enter)
        {
            buttons_SecondSet[0].SetActive(true);
            foreach (GameObject but in buttons_FirstSet)
            { if (but != null) { but.SetActive(false); } }

            username.gameObject.SetActive(true);
            enter = false;
        }

        if (username.text != "" && Input.GetKeyDown(KeyCode.Return)) //Cameron to upgrade for Control pad. Text field.
        {
            scoreCarrierCarrers.SetActive(true);
            scoreCarrierCarrers.GetComponent<progressionScript>().name = username.text;
            scoreCarrierCarrers.GetComponent<progressionScript>().currentLevel = 1;
            levelCount = 1;
            SceneManager.LoadScene(levelCount);
        }

        if (escapeOther && Input.GetKeyDown(KeyCode.Escape))
        {

            escapeOther = false;
            username.gameObject.SetActive(false);
        }

    }

    public void levelSelection()
    {/*Level selection screen, advanced click?*/
        if (enter)
        {
            foreach (GameObject but in buttons_FirstSet)
            { if (but != null) { but.SetActive(false); Debug.Log("Set button to false: " + but.name ); } }
            buttons_SecondSet[4].gameObject.SetActive(true);
            buttons_SecondSet[4].SetActive(true);
            enter = false;
        } //DEFAULT Load new buttons and unload old from first and second.

        Debug.Log("Testing");
    }

    public void sceneLoader(int LevelToLoad)
    {
        Debug.LogError("Scene loading... Standby!");

        if (LevelToLoad >= 0)
        {
            SceneManager.LoadScene(LevelToLoad);
        }

    }

    public void restart()
    {
        command = "";
        SceneManager.LoadScene(levelCount);

    }

    //////public void newGame() //load up the first level for training
    //////   {
    //////       stats.saveslots[num_CurrentSlot] = new playerStats(myName);
    //////       levelCount = 5;
    //////       SceneManager.LoadScene(levelCount);
    //////   }
    //////   public void saveGame()
    //////   {
    //////       // stats.saveslots[num_CurrentSlot] = new playerStats(lvl)
    //////       stats.saveslots[num_CurrentSlot] = new playerStats(myName, moneyCurrent, levelCount);
    //////       {//SAVE GAME
    //////           System.Type type = typeof(saves);
    //////           XmlSerializer serilizer = new XmlSerializer(type);
    //////           StreamWriter writer = new StreamWriter("../ProfileInfomation");
    //////           Debug.Log("Writing Information");
    //////           serilizer.Serialize(writer, stats);
    //////           writer.Close();
    //////       }//SAVE GAME
    //////   }

    //////   public void loadGame()
    //////   {
    //////       //stats.saveslots[num_CurrentSlot](myName, moneyCurrent, levelCount);
    //////       levelCount = stats.saveslots[num_CurrentSlot].lvl;
    //////       moneyCurrent = stats.saveslots[num_CurrentSlot].money;
    //////       myName = stats.saveslots[num_CurrentSlot].name;
    //////       SceneManager.LoadScene(levelCount);

    //////       //info.AddValue("GameSlot: ", (num_loadGame));
    //////       //info.AddValue("foundGem1", (foundGem1));
    //////       //info.AddValue("SaveMoney: ", moneyCurrent);
    //////       //info.AddValue("CurrentLevel: ", levelCount);
    //////   }

    //public void nextLevel(SerializationInfo info, StreamingContext ctxt)
    //{
    //    info.AddValue("GameSlot: ", (num_loadGame));
    //    info.AddValue("foundGem1", (foundGem1));
    //    info.AddValue("SaveMoney: ", moneyCurrent);
    //    info.AddValue("CurrentLevel: ", levelCount);
    //}

    public void leaderboards()
    {
        Debug.Log("Leaderboards called.");
        if (enter)
        {
            foreach (GameObject but in buttons_FirstSet)
            { if (but != null) { but.SetActive(false); } }
            buttons_SecondSet[1].gameObject.SetActive(true);
            buttons_SecondSet[1].SetActive(true);
            enter = false;
        }
    }

    public void options()
    {
        Debug.Log("Options!");
        if (enter)
        {
            foreach (GameObject but in buttons_FirstSet)
            { if (but != null) { but.SetActive(false); } }
            buttons_SecondSet[2].gameObject.SetActive(true);
            buttons_SecondSet[2].SetActive(true);
            enter = false;
        }
    }

    public void credits()
    {
        if (enter)
        {
            foreach (GameObject but in buttons_FirstSet)
            { if (but != null) { but.SetActive(false); } }
            buttons_SecondSet[3].gameObject.SetActive(true);
            buttons_SecondSet[3].SetActive(true);
            enter = false;
        } //DEFAULT Load new buttons and unload old from first and second.
    }

    public void mainzero()
    { SceneManager.LoadScene(0); command = ""; }

    public void quit()
    {
        {//SAVE GAME
            System.Type type = typeof(saves);
            XmlSerializer serilizer = new XmlSerializer(type);
            StreamWriter writer = new StreamWriter("../ProfileInfomation");
            Debug.Log("Writing Information");
            serilizer.Serialize(writer, stats);
            writer.Close();
        }//SAVE GAME
         //SceneManager.UnloadScene(0);
        Debug.Log("Quit");
        //Application.Quit();
        //SceneManager.UnloadScene(levelCount+1);
        //Application.EditorApplication.isPlaying = false;
        Application.Quit();


    }
    public void ButtonActive(string name)
    {

        if (name != "")
        {
            //int i = 0;
            foreach (string function in firstSet)
            {
                if (name == function)
                { command = function; }
                else if (name.Contains("lodlevel"))
                { command = name; }

               // i++;
            }
            comGo = false;
        }
        if (command == "return")
        {
            if (enter == false)
            { exit = true; command = ""; }
            //else if (isMainMenu)
            //{
            //    SceneManager.LoadScene(levelCount);
            //    Time.timeScale = 1;
            //}
            ///Make's no sense for the player to press escape and go stright into the game. More likely to quit are you sure?
        }
        //buttons_FirstSet
        //buttons_SecondSet



    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !escapeOther)
        {
            if (enter == false)
            { exit = true; command = ""; }
            //else if (isMainMenu)
            //{
            //    SceneManager.LoadScene(levelCount);
            //    Time.timeScale = 1;
            //}
            ///Make's no sense for the player to press escape and go stright into the game. More likely to quit are you sure?
            else if (gamePause)
            {
                Time.timeScale = 1;
                gamePause = false;
            }
        }
        if(gamePause)
        { 
            if (command != "" && comGo != true)
            {
                Debug.Log("Check comGo!");
                int i = 0;
                foreach (string com in firstSet)
                {
                    if (command == com)//Slots screen via (new/load/save)
                    { Debug.Log("Check return; " + i); break; }
                    i++;
                }
                Debug.Log("Do i get here? " + i);
                if (firstSet[i] == firstSet[1] || firstSet[i] == firstSet[2] || firstSet[i] == firstSet[3])
                { // (new/load/save)
                  //if(firstSet is == firstSet[1])
                    if (firstSet[i] == firstSet[1])
                    { command = "slots/new"; }//"slots/new"
                    if (firstSet[i] == firstSet[2])
                    { command = "slots/save"; } //"slots/save"
                    if (firstSet[i] == firstSet[3])
                    { command = "slots/load"; } //"slots/load
                }
                if (command.Contains(firstSet[5]))
                { Debug.Log("Led board."); leaderboards(); }
                if (command.Contains(firstSet[4]))
                { options(); }
                if (command.Contains(firstSet[6]))
                { credits(); }
                if (command.Contains("levelselect")) { levelSelection(); }
                if (command.Contains("resume")) { resume(); }

                if (command.Contains("main0")) { mainzero(); }
                if (isMainMenu == false && command.Contains("new")) { if (scoreCarrierCarrers != null) { levelCount = scoreCarrierCarrers.GetComponent<progressionScript>().currentLevel; } restart(); }

                comGo = true;
            }
            else if (/*buttons_FirstSet[4].activeInHierarchy != true && */command == "")
            {

                if (isMainMenu)
                {
                    foreach (int i in mainActive)
                    { if (buttons_FirstSet[i] != null) { buttons_FirstSet[i].SetActive(true); } }
                }
                else
                {
                    foreach (int i in pauseActive)
                    { if (buttons_FirstSet[i] != null) { buttons_FirstSet[i].SetActive(true); } }
                }



                //foreach (GameObject but in buttons_FirstSet)
                //{
                //    but.SetActive(true);
                //}
                foreach (GameObject but in buttons_SecondSet)
                { but.SetActive(false); }

                buttons_SecondSet[0].SetActive(false);
                username.gameObject.SetActive(false);

                enter = true;
                if (dropDown == GameType.Career)
                {

                    foreach (GameObject obj in careersModeSwitch)
                    { obj.SetActive(false); }
                    if (!isMainMenu)
                    {
                        foreach (GameObject o in main)
                        { if (o != null) { o.SetActive(false); } }
                    }
                }
            }

            //int i = 0;
            //foreach (GameObject check in buttons_FirstSet)
            //{
            //    if (check.GetComponent<Button>.)
            //        i++;
            //}        

            if (command == firstSet[11])
            { careersMode(); }
            if (command.Contains("slots/"))
            {
                if (dropDown == GameType.SaveOrLoad_System)
                {
                    foreach (GameObject obj in careersModeSwitch)
                    { obj.SetActive(true); }
                    slots(0);
                }

            }


        }

    }

}


//////using UnityEngine;
//////using System.Collections;
//////using System.Collections.Generic;
//////using UnityEngine.SceneManagement;
//////using UnityEngine.UI;
//////using System.Xml.Serialization;
//////using System.IO;



////////[SerializeField]
//////[System.Serializable()]
//////public class saves //Save files and games data.
//////{
//////    private int m_saveSlots = 3;
//////    public List<playerStats> saveslots;
//////    public saves()
//////    {
//////        saveslots = new List<playerStats>(m_saveSlots);
//////        saveslots.Add(new playerStats("Player1", 5, 2));
//////        saveslots.Add(new playerStats("Player2", 5, 2));
//////        saveslots.Add(new playerStats("Player3", 5, 2));
//////    }
//////}
//////public class playerStats
//////{
//////    public string name;
//////    public int money;
//////    public int lvl;

//////    public playerStats()
//////    {

//////    }
//////    public playerStats(int moneyCurrent, int level)
//////    {
//////        money = moneyCurrent;
//////        lvl = level;
//////    }
//////    public playerStats(string _name)
//////    {
//////        name = _name;
//////    }
//////    public playerStats(string _name, int moneyCurrent, int level)
//////    {
//////        name = _name;
//////        money = moneyCurrent;
//////        lvl = level;
//////    }



//////}

//////public class MenuSystem : MonoBehaviour
//////{

//////    [SerializeField]
//////    public bool testExperiment = false; //Will it save infomation during runtime?
//////    public Scene scenes;
//////    public int Checktest = 3;
//////    int num_CurrentSlot = 0;
//////    public int levelCount = 0;
//////    saves stats;
//////    public int moneyCurrent = 2000;
//////    public string myName = "Default";
//////    public bool isMainMenu = false;


//////    public List<GameObject> buttons_FirstSet = new List<GameObject>();
//////    public List<GameObject> buttons_SecondSet = new List<GameObject>();

//////    public List<string> firstSet = new List<string>();
//////    public string command = "";
//////    public bool comGo = false;

//////    bool enter = true;
//////    bool exit = false;
//////    //public List<Button> new_Off = new List<Button>();
//////    //public List<Button> save_Off = new List<Button>();
//////    //public List<Button> load_Off = new List<Button>();
//////    //public List<Button> options_Off = new List<Button>();
//////    //public List<Button> credits_Off = new List<Button>();



//////    void Start()
//////    {
//////        stats = new saves();
//////        //       stats.saveslots[0] = new playerStats("super jeffry");
//////        stats.saveslots[num_CurrentSlot].money = moneyCurrent;
//////        //quit();
//////        firstSet.Add("resume"); //0
//////        firstSet.Add("new"); //1
//////        firstSet.Add("save"); //2
//////        firstSet.Add("load"); //3
//////        firstSet.Add("options"); //4
//////        firstSet.Add("leaderboard"); //5
//////        firstSet.Add("credits"); //6

//////    }



//////    public void resume()
//////    { SceneManager.LoadScene(levelCount); }

//////    public void slots(int slotSelect)
//////    {
//////        Debug.Log("Slots active! ");
//////        //int i = 0;
//////        if (enter)
//////        {
//////            foreach (GameObject but in buttons_FirstSet)
//////            { but.SetActive(false); }

//////            buttons_SecondSet[0].gameObject.SetActive(true);
//////            buttons_SecondSet[0].SetActive(true);

//////            buttons_SecondSet[0].gameObject.SetActive(true);

//////            buttons_SecondSet[0].SetActive(true);

//////            enter = false;
//////        }

//////        if (slotSelect != 0)
//////        {
//////            num_CurrentSlot = slotSelect - 1;
//////            if (command.Contains("new"))
//////            {

//////                stats.saveslots[slotSelect] = new playerStats(myName);
//////                levelCount = 5;
//////                SceneManager.LoadScene(levelCount);
//////            }
//////            if (command.Contains("save"))
//////            {
//////                //                //stats.saveslots[num_CurrentSlot](myName, moneyCurrent, levelCount);

//////                System.Type type = typeof(saves);
//////                XmlSerializer serilizer = new XmlSerializer(type);
//////                StreamWriter writer = new StreamWriter("../ProfileInfomation");
//////                Debug.Log("Writing Information");
//////                serilizer.Serialize(writer, stats);
//////                writer.Close();
//////            }
//////            if (command.Contains("load"))
//////            {

//////                levelCount = stats.saveslots[num_CurrentSlot].lvl;
//////                moneyCurrent = stats.saveslots[num_CurrentSlot].money;
//////                myName = stats.saveslots[num_CurrentSlot].name;
//////                SceneManager.LoadScene(levelCount);
//////            }
//////        }



//////    }

//////    public void leaderboards()
//////    { }

//////    public void options()
//////    { }

//////    public void credits()
//////    { }

//////    public void quit()
//////    {
//////        {//SAVE GAME
//////            System.Type type = typeof(saves);
//////            XmlSerializer serilizer = new XmlSerializer(type);
//////            StreamWriter writer = new StreamWriter("../ProfileInfomation");
//////            Debug.Log("Writing Information");
//////            serilizer.Serialize(writer, stats);
//////            writer.Close();
//////        }//SAVE GAME
//////         //SceneManager.UnloadScene(0);
//////        Debug.Log("Quit");
//////        //Application.Quit();
//////        //SceneManager.UnloadScene(levelCount+1);
//////        //Application.EditorApplication.isPlaying = false;
//////        Application.Quit();


//////    }
//////    public void ButtonActive(string name)
//////    {

//////        if (name != "")
//////        {
//////            int i = 0;
//////            foreach (string function in firstSet)
//////            {
//////                if (name == function)
//////                { command = function; }

//////                i++;
//////            }
//////            comGo = false;
//////        }
//////        //buttons_FirstSet
//////        //buttons_SecondSet



//////    }
//////    void Update()
//////    {
//////        if (Input.GetKeyDown(KeyCode.Escape))
//////        {
//////            if (enter == false)
//////            { exit = true; command = ""; }

//////            else if (levelCount != 0)
//////            {
//////                SceneManager.LoadScene(levelCount);
//////                Time.timeScale = 1;
//////            }
//////        }

//////        if (command != "" && comGo != true)
//////        {
//////            Debug.Log("Check comGo!");
//////            int i = 0;
//////            foreach (string com in firstSet)
//////            {
//////                if (command == com)//Slots screen via (new/load/save)
//////                { Debug.Log("Check return; " + i); break; }
//////                i++;
//////            }
//////            Debug.Log("Do i get here? " + i);
//////            if (firstSet[i] == firstSet[1] || firstSet[i] == firstSet[2] || firstSet[i] == firstSet[3])
//////            { // (new/load/save)
//////                //if(firstSet is == firstSet[1])
//////                if (firstSet[i] == firstSet[1])
//////                { command = "slots/new"; }//"slots/new"
//////                if (firstSet[i] == firstSet[2])
//////                { command = "slots/save"; } //"slots/save"
//////                if (firstSet[i] == firstSet[3])
//////                { command = "slots/load"; } //"slots/load
//////            }
//////            comGo = true;
//////        }
//////        else if (buttons_FirstSet[3].activeInHierarchy != true && command == "")
//////        {

//////            foreach (GameObject but in buttons_FirstSet)
//////            { but.SetActive(true); }

//////            ////buttons_SecondSet[0].gameObject.SetActive(false);
//////            ////buttons_SecondSet[0].SetActive(false);

//////            buttons_SecondSet[0].gameObject.SetActive(false);
//////            buttons_SecondSet[0].SetActive(false);

//////            enter = true;
//////        }

//////        //int i = 0;
//////        //foreach (GameObject check in buttons_FirstSet)
//////        //{
//////        //    if (check.GetComponent<Button>.)
//////        //        i++;
//////        //}

//////        if (command.Contains("slots/"))
//////        {
//////            slots(0);
//////        }


//////    }
//////}
=======
//    public enum GameType // your custom enumeration
//    {  SaveOrLoad_System, Career, Leaderboards   };
//    public GameType dropDown = GameType.Career;



//    //public GameObject[] children/* = buttons_SecondSet[0].GetComponentsInChildren<Transform>()*/;

//    public List<GameObject> buttons_FirstSet = new List<GameObject>();
//    public List<GameObject> buttons_SecondSet = new List<GameObject>();
//    public InputField username;

//    public List<GameObject> careersModeSwitch = new List<GameObject>();

//    public List<string> firstSet = new List<string>();

//    //static void dropDownModes()
//    //{
//    //int selection = 0;
//    //public string[] gameType = new string[] {"Save based gameplay", "Without Saves", "Leaderboards ONLY!"};
//    //selection = EditorGUILayout.Popup("Game Type: ", selection, gameType);
//    //    }
//    //public string[] gameType = new string[3] { "Save based gameplay", "Without Saves", "Leaderboards ONLY!" };

//    int numeric = 0;
//    string commons = "";
//    public string command = "";
//    public bool comGo = false;
//    bool escapeOther = false;

//    bool enter = true;
//    bool exit = false;
//    //public List<Button> new_Off = new List<Button>();
//    //public List<Button> save_Off = new List<Button>();
//    //public List<Button> load_Off = new List<Button>();
//    //public List<Button> options_Off = new List<Button>();
//    //public List<Button> credits_Off = new List<Button>();



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
//        firstSet.Add("levelselect");
//        firstSet.Add("lodlevel");
//        firstSet.Add("return");
//        firstSet.Add("career");
//        //switch (GameType.SaveOrLoad_System)
//        //{  case }
//        foreach (GameObject buttons in buttons_FirstSet)
//        { if (buttons != null) { buttons.SetActive(false); } }
//        if (isMainMenu)
//        {
//            foreach (int i in mainActive)
//            { if(buttons_FirstSet[i] != null) { buttons_FirstSet[i].SetActive(true); } }
//        }
//        else
//        {
//            foreach (int i in pauseActive)
//            { if (buttons_FirstSet[i] != null) buttons_FirstSet[i].SetActive(true); }
//        }

//        if (dropDown == GameType.Career)
//        {
//            //foreach(GameObject obj in children)
//            //{ obj.SetActive(false); }
//            foreach (GameObject obj in careersModeSwitch)
//            { obj.SetActive(false);  }
//        }

//        if(scoreCarrierCarrers == null) { scoreCarrierCarrers = GameObject.Find("PROGRESS BROTHER"); }
//    }



//    public void resume()
//    {
//        {


//            Time.timeScale = 1;
//            gamePause = false;

//        }
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

//                    // foreach(c)
//                    //foreach (GameObject child in children)
//                    //{
//                    //    Debug.Log(child);
//                    //    if (child != buttons_SecondSet[0])
//                    //    {
//                    //        child.SetActive(true);
//                    //    }
//                    //}
//                    num_CurrentSlot = 0;
//                    escapeOther = false;
//                    username.gameObject.SetActive(false);
//                }
//            }
//            //if (command.Contains("new/1"))
//            //{

//            //}

//            if (command.Contains("save"))
//            {
//                //                //stats.saveslots[num_CurrentSlot](myName, moneyCurrent, levelCount);

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
//            { if (but != null) { but.SetActive(false); } }

//            username.gameObject.SetActive(true);
//            enter = false;
//        }

//        if (username.text != "" && Input.GetKeyDown(KeyCode.Return)) //Cameron to upgrade for Control pad. Text field.
//        {
//            scoreCarrierCarrers.SetActive(true);
//            scoreCarrierCarrers.GetComponent<progressionScript>().name = username.text;
//            scoreCarrierCarrers.GetComponent<progressionScript>().currentLevel = 1;
//            levelCount = 1;
//            SceneManager.LoadScene(levelCount);
//        }

//        if (escapeOther && Input.GetKeyDown(KeyCode.Escape))
//        {

//            escapeOther = false;
//            username.gameObject.SetActive(false);
//        }

//    }

//    public void levelSelection()
//    {/*Level selection screen, advanced click?*/
//        if (enter)
//        {
//            foreach (GameObject but in buttons_FirstSet)
//            { if (but != null) { but.SetActive(false); Debug.Log("Set button to false: " + but.name ); } }
//            buttons_SecondSet[4].gameObject.SetActive(true);
//            buttons_SecondSet[4].SetActive(true);
//            enter = false;
//        } //DEFAULT Load new buttons and unload old from first and second.

//        Debug.Log("Testing");
//    }

//    public void sceneLoader(int LevelToLoad)
//    {
//        Debug.LogError("Scene loading... Standby!");

//        if (LevelToLoad >= 0)
//        {
//            SceneManager.LoadScene(LevelToLoad);
//        }

//    }

//    public void restart()
//    {
//        command = "";
//        SceneManager.LoadScene(levelCount);

//    }

//    //////public void newGame() //load up the first level for training
//    //////   {
//    //////       stats.saveslots[num_CurrentSlot] = new playerStats(myName);
//    //////       levelCount = 5;
//    //////       SceneManager.LoadScene(levelCount);
//    //////   }
//    //////   public void saveGame()
//    //////   {
//    //////       // stats.saveslots[num_CurrentSlot] = new playerStats(lvl)
//    //////       stats.saveslots[num_CurrentSlot] = new playerStats(myName, moneyCurrent, levelCount);
//    //////       {//SAVE GAME
//    //////           System.Type type = typeof(saves);
//    //////           XmlSerializer serilizer = new XmlSerializer(type);
//    //////           StreamWriter writer = new StreamWriter("../ProfileInfomation");
//    //////           Debug.Log("Writing Information");
//    //////           serilizer.Serialize(writer, stats);
//    //////           writer.Close();
//    //////       }//SAVE GAME
//    //////   }

//    //////   public void loadGame()
//    //////   {
//    //////       //stats.saveslots[num_CurrentSlot](myName, moneyCurrent, levelCount);
//    //////       levelCount = stats.saveslots[num_CurrentSlot].lvl;
//    //////       moneyCurrent = stats.saveslots[num_CurrentSlot].money;
//    //////       myName = stats.saveslots[num_CurrentSlot].name;
//    //////       SceneManager.LoadScene(levelCount);

//    //////       //info.AddValue("GameSlot: ", (num_loadGame));
//    //////       //info.AddValue("foundGem1", (foundGem1));
//    //////       //info.AddValue("SaveMoney: ", moneyCurrent);
//    //////       //info.AddValue("CurrentLevel: ", levelCount);
//    //////   }

//    //public void nextLevel(SerializationInfo info, StreamingContext ctxt)
//    //{
//    //    info.AddValue("GameSlot: ", (num_loadGame));
//    //    info.AddValue("foundGem1", (foundGem1));
//    //    info.AddValue("SaveMoney: ", moneyCurrent);
//    //    info.AddValue("CurrentLevel: ", levelCount);
//    //}

//    public void leaderboards()
//    {
//        Debug.Log("Leaderboards called.");
//        if (enter)
//        {
//            foreach (GameObject but in buttons_FirstSet)
//            { if (but != null) { but.SetActive(false); } }
//            buttons_SecondSet[1].gameObject.SetActive(true);
//            buttons_SecondSet[1].SetActive(true);
//            enter = false;
//        }
//    }

//    public void options()
//    {
//        Debug.Log("Options!");
//        if (enter)
//        {
//            foreach (GameObject but in buttons_FirstSet)
//            { if (but != null) { but.SetActive(false); } }
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
//            { if (but != null) { but.SetActive(false); } }
//            buttons_SecondSet[3].gameObject.SetActive(true);
//            buttons_SecondSet[3].SetActive(true);
//            enter = false;
//        } //DEFAULT Load new buttons and unload old from first and second.
//    }

//    public void mainzero()
//    { SceneManager.LoadScene(0); command = ""; }

//    public void quit()
//    {
//        {//SAVE GAME
//            System.Type type = typeof(saves);
//            XmlSerializer serilizer = new XmlSerializer(type);
//            StreamWriter writer = new StreamWriter("../ProfileInfomation");
//            Debug.Log("Writing Information");
//            serilizer.Serialize(writer, stats);
//            writer.Close();
//        }//SAVE GAME
//         //SceneManager.UnloadScene(0);
//        Debug.Log("Quit");
//        //Application.Quit();
//        //SceneManager.UnloadScene(levelCount+1);
//        //Application.EditorApplication.isPlaying = false;
//        Application.Quit();


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
//                else if (name.Contains("lodlevel"))
//                { command = name; }

//               // i++;
//            }
//            comGo = false;
//        }
//        if (command == "return")
//        {
//            if (enter == false)
//            { exit = true; command = ""; }
//            //else if (isMainMenu)
//            //{
//            //    SceneManager.LoadScene(levelCount);
//            //    Time.timeScale = 1;
//            //}
//            ///Make's no sense for the player to press escape and go stright into the game. More likely to quit are you sure?
//        }
//        //buttons_FirstSet
//        //buttons_SecondSet



//    }
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Escape) && !escapeOther)
//        {
//            if (enter == false)
//            { exit = true; command = ""; }
//            //else if (isMainMenu)
//            //{
//            //    SceneManager.LoadScene(levelCount);
//            //    Time.timeScale = 1;
//            //}
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
//            { Debug.Log("Led board."); leaderboards(); }
//            if (command.Contains(firstSet[4]))
//            { options(); }
//            if (command.Contains(firstSet[6]))
//            { credits(); }
//            if (command.Contains("levelselect")) { levelSelection(); }

//            if(command.Contains("main0")) { mainzero(); }
//            if(isMainMenu == false && command.Contains("new")) { if(scoreCarrierCarrers != null) { levelCount = scoreCarrierCarrers.GetComponent<progressionScript>().currentLevel; } restart(); }

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
//                foreach(int i in pauseActive)
//                { buttons_FirstSet[i].SetActive(true); }
//            }



//            //foreach (GameObject but in buttons_FirstSet)
//            //{
//            //    but.SetActive(true);
//            //}
//            foreach (GameObject but in buttons_SecondSet)
//            { but.SetActive(false); }

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

//        //int i = 0;
//        //foreach (GameObject check in buttons_FirstSet)
//        //{
//        //    if (check.GetComponent<Button>.)
//        //        i++;
//        //}        

//            if (command == firstSet[11])
//            { careersMode(); }
//        if (command.Contains("slots/"))
//        {
//            if (dropDown == GameType.SaveOrLoad_System)
//            {
//                foreach (GameObject obj in careersModeSwitch)
//                { obj.SetActive(true); }
//                slots(0);
//            }

//        }





//    }
//}


////////using UnityEngine;
////////using System.Collections;
////////using System.Collections.Generic;
////////using UnityEngine.SceneManagement;
////////using UnityEngine.UI;
////////using System.Xml.Serialization;
////////using System.IO;



//////////[SerializeField]
////////[System.Serializable()]
////////public class saves //Save files and games data.
////////{
////////    private int m_saveSlots = 3;
////////    public List<playerStats> saveslots;
////////    public saves()
////////    {
////////        saveslots = new List<playerStats>(m_saveSlots);
////////        saveslots.Add(new playerStats("Player1", 5, 2));
////////        saveslots.Add(new playerStats("Player2", 5, 2));
////////        saveslots.Add(new playerStats("Player3", 5, 2));
////////    }
////////}
////////public class playerStats
////////{
////////    public string name;
////////    public int money;
////////    public int lvl;

////////    public playerStats()
////////    {

////////    }
////////    public playerStats(int moneyCurrent, int level)
////////    {
////////        money = moneyCurrent;
////////        lvl = level;
////////    }
////////    public playerStats(string _name)
////////    {
////////        name = _name;
////////    }
////////    public playerStats(string _name, int moneyCurrent, int level)
////////    {
////////        name = _name;
////////        money = moneyCurrent;
////////        lvl = level;
////////    }



////////}

////////public class MenuSystem : MonoBehaviour
////////{

////////    [SerializeField]
////////    public bool testExperiment = false; //Will it save infomation during runtime?
////////    public Scene scenes;
////////    public int Checktest = 3;
////////    int num_CurrentSlot = 0;
////////    public int levelCount = 0;
////////    saves stats;
////////    public int moneyCurrent = 2000;
////////    public string myName = "Default";
////////    public bool isMainMenu = false;


////////    public List<GameObject> buttons_FirstSet = new List<GameObject>();
////////    public List<GameObject> buttons_SecondSet = new List<GameObject>();

////////    public List<string> firstSet = new List<string>();
////////    public string command = "";
////////    public bool comGo = false;

////////    bool enter = true;
////////    bool exit = false;
////////    //public List<Button> new_Off = new List<Button>();
////////    //public List<Button> save_Off = new List<Button>();
////////    //public List<Button> load_Off = new List<Button>();
////////    //public List<Button> options_Off = new List<Button>();
////////    //public List<Button> credits_Off = new List<Button>();



////////    void Start()
////////    {
////////        stats = new saves();
////////        //       stats.saveslots[0] = new playerStats("super jeffry");
////////        stats.saveslots[num_CurrentSlot].money = moneyCurrent;
////////        //quit();
////////        firstSet.Add("resume"); //0
////////        firstSet.Add("new"); //1
////////        firstSet.Add("save"); //2
////////        firstSet.Add("load"); //3
////////        firstSet.Add("options"); //4
////////        firstSet.Add("leaderboard"); //5
////////        firstSet.Add("credits"); //6

////////    }



////////    public void resume()
////////    { SceneManager.LoadScene(levelCount); }

////////    public void slots(int slotSelect)
////////    {
////////        Debug.Log("Slots active! ");
////////        //int i = 0;
////////        if (enter)
////////        {
////////            foreach (GameObject but in buttons_FirstSet)
////////            { but.SetActive(false); }

////////            buttons_SecondSet[0].gameObject.SetActive(true);
////////            buttons_SecondSet[0].SetActive(true);

////////            buttons_SecondSet[0].gameObject.SetActive(true);

////////            buttons_SecondSet[0].SetActive(true);

////////            enter = false;
////////        }

////////        if (slotSelect != 0)
////////        {
////////            num_CurrentSlot = slotSelect - 1;
////////            if (command.Contains("new"))
////////            {

////////                stats.saveslots[slotSelect] = new playerStats(myName);
////////                levelCount = 5;
////////                SceneManager.LoadScene(levelCount);
////////            }
////////            if (command.Contains("save"))
////////            {
////////                //                //stats.saveslots[num_CurrentSlot](myName, moneyCurrent, levelCount);

////////                System.Type type = typeof(saves);
////////                XmlSerializer serilizer = new XmlSerializer(type);
////////                StreamWriter writer = new StreamWriter("../ProfileInfomation");
////////                Debug.Log("Writing Information");
////////                serilizer.Serialize(writer, stats);
////////                writer.Close();
////////            }
////////            if (command.Contains("load"))
////////            {

////////                levelCount = stats.saveslots[num_CurrentSlot].lvl;
////////                moneyCurrent = stats.saveslots[num_CurrentSlot].money;
////////                myName = stats.saveslots[num_CurrentSlot].name;
////////                SceneManager.LoadScene(levelCount);
////////            }
////////        }



////////    }

////////    public void leaderboards()
////////    { }

////////    public void options()
////////    { }

////////    public void credits()
////////    { }

////////    public void quit()
////////    {
////////        {//SAVE GAME
////////            System.Type type = typeof(saves);
////////            XmlSerializer serilizer = new XmlSerializer(type);
////////            StreamWriter writer = new StreamWriter("../ProfileInfomation");
////////            Debug.Log("Writing Information");
////////            serilizer.Serialize(writer, stats);
////////            writer.Close();
////////        }//SAVE GAME
////////         //SceneManager.UnloadScene(0);
////////        Debug.Log("Quit");
////////        //Application.Quit();
////////        //SceneManager.UnloadScene(levelCount+1);
////////        //Application.EditorApplication.isPlaying = false;
////////        Application.Quit();


////////    }
////////    public void ButtonActive(string name)
////////    {

////////        if (name != "")
////////        {
////////            int i = 0;
////////            foreach (string function in firstSet)
////////            {
////////                if (name == function)
////////                { command = function; }

////////                i++;
////////            }
////////            comGo = false;
////////        }
////////        //buttons_FirstSet
////////        //buttons_SecondSet



////////    }
////////    void Update()
////////    {
////////        if (Input.GetKeyDown(KeyCode.Escape))
////////        {
////////            if (enter == false)
////////            { exit = true; command = ""; }

////////            else if (levelCount != 0)
////////            {
////////                SceneManager.LoadScene(levelCount);
////////                Time.timeScale = 1;
////////            }
////////        }

////////        if (command != "" && comGo != true)
////////        {
////////            Debug.Log("Check comGo!");
////////            int i = 0;
////////            foreach (string com in firstSet)
////////            {
////////                if (command == com)//Slots screen via (new/load/save)
////////                { Debug.Log("Check return; " + i); break; }
////////                i++;
////////            }
////////            Debug.Log("Do i get here? " + i);
////////            if (firstSet[i] == firstSet[1] || firstSet[i] == firstSet[2] || firstSet[i] == firstSet[3])
////////            { // (new/load/save)
////////                //if(firstSet is == firstSet[1])
////////                if (firstSet[i] == firstSet[1])
////////                { command = "slots/new"; }//"slots/new"
////////                if (firstSet[i] == firstSet[2])
////////                { command = "slots/save"; } //"slots/save"
////////                if (firstSet[i] == firstSet[3])
////////                { command = "slots/load"; } //"slots/load
////////            }
////////            comGo = true;
////////        }
////////        else if (buttons_FirstSet[3].activeInHierarchy != true && command == "")
////////        {

////////            foreach (GameObject but in buttons_FirstSet)
////////            { but.SetActive(true); }

////////            ////buttons_SecondSet[0].gameObject.SetActive(false);
////////            ////buttons_SecondSet[0].SetActive(false);

////////            buttons_SecondSet[0].gameObject.SetActive(false);
////////            buttons_SecondSet[0].SetActive(false);

////////            enter = true;
////////        }

////////        //int i = 0;
////////        //foreach (GameObject check in buttons_FirstSet)
////////        //{
////////        //    if (check.GetComponent<Button>.)
////////        //        i++;
////////        //}

////////        if (command.Contains("slots/"))
////////        {
////////            slots(0);
////////        }


////////    }
////////}
>>>>>>> 5b55d184a474bc4f8e47acd805e38090e639deac
