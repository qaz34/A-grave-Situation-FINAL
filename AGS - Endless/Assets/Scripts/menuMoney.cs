using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class menuMoney : MonoBehaviour
{
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("GameManager") != null)
        GetComponent<Text>().text = "Current Money: " + GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().Money.ToString();
    }
}
