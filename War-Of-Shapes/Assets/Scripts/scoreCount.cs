using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreCount : MonoBehaviour
{
    public static int scoreValue = 0;
    public Text score;
    public Text hightext;
    public static int highscore = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highestScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (score != null)
        {
            score.text = scoreValue.ToString();

            if(scoreValue > highscore) 
            {
                highscore = scoreValue;
            }
            hightext.text = highscore.ToString();
        }
    }
}
