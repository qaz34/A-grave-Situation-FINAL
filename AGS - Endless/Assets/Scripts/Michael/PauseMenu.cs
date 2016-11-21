//using UnityEngine;
//using System.Collections;

//public class PauseMenu : MonoBehaviour
//{
//    public GameObject firstMenu;
//    // Use this for initialization
//    void Start()
//    {

//    }
//    public void Quit()
//    {
//        Application.Quit();
//    }
//    // Update is called once per frame
//    void Update()
//    {
//        if (firstMenu.GetComponent<MenuSystem>() != null && firstMenu.GetComponent<MenuSystem>().command == "")
//        {
////            Debug.Log("Cameron script: 1 and 0,");
//            if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
//            {
////                Debug.Log("Cameron: 1");
//                Time.timeScale = 0;
//                firstMenu.SetActive(true);
//            }
//            else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
//            {
////                Debug.Log("Cameron: 0");
//                Time.timeScale = 1;
//                firstMenu.SetActive(false);
//            }
//        }
//    }
//}


/////Cameron's script, Michael altered to sync with original menu script due to been away when the script was needed. Altered to allow code to flow if menu is not on another layer beyond
/////the pause menu.
/////Michael added line 19.