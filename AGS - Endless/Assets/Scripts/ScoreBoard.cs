using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
public class ScoreBoard : MonoBehaviour
{
    public TextAsset scoreboard;
    public GameObject scoreLbl;
    List<ScoreInfo> scores = new List<ScoreInfo>();
    void Start()
    {
        sortLeaderboard();
        for (int i = 0; i < 5; i++)
        {
            GameObject go = Instantiate<GameObject>(scoreLbl);
            go.transform.SetParent(transform, false);
            ScoreLbl sl = go.GetComponent<ScoreLbl>();
            sl.username.text = scores[i].name;
            sl.coins.text = scores[i].coins.ToString();
            sl.time.text = scores[i].time;
        }
    }
    public static int sort(ScoreInfo a, ScoreInfo b)
    {
        return b.coins.CompareTo(a.coins);
    }
    void sortLeaderboard()
    {
        string[] linesFromfile = scoreboard.text.Split("\n"[0]);
        StreamWriter writer = new StreamWriter("assets/Resources/HighScores.txt");
        for (int i = 0; i < 15; i += 3)
        {
            scores.Add(new ScoreInfo(linesFromfile[i], Convert.ToInt32(linesFromfile[i + 1]), linesFromfile[i + 2]));
        }
        if (GameObject.FindGameObjectWithTag("GameManager"))
            if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().career)
            {
                GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
                scores.Add(new ScoreInfo(gm.Name, gm.Money, gm.time.ToString()));
            }
        scores.Sort(sort);
        for (int i = 0; i < 5; i++)
        {
            writer.WriteLine(scores[i].name);
            writer.WriteLine(scores[i].coins);
            writer.WriteLine(scores[i].time);
        }
        writer.Close();
    }
}
public struct ScoreInfo
{
    public string name;
    public int coins;
    public string time;
    public ScoreInfo(string _name, int _coins, string _time)
    {
        name = _name;
        coins = _coins;
        time = _time;
    }
}
