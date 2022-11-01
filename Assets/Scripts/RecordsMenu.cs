using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordsMenu : MonoBehaviour
{
    public Text HIGHSCORE;
    public float HighscoreScore = 0;
    void Start()
    {
        HighscoreScore = PlayerPrefs.GetFloat("Highscore", 0);
    }
    void Update()
    {
        HIGHSCORE.text = "Highscore: " + HighscoreScore;
    }
}
