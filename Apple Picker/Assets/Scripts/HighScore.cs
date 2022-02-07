/***
 * Created by: Thomas Nguyen
 * Date Created: 2/7/2022
 * 
 * Last Edited: 2/7/2022
 * Last Edited by: Thomas Nguyen
 * 
 * Description: High Score manager 
***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 1000;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("Highscore");
        }

        PlayerPrefs.SetInt("Highscore", score);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;

        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
    }
}
