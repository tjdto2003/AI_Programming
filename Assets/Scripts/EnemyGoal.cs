using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGoal : MonoBehaviour {
    public static EnemyGoal _instance;


    public static EnemyGoal instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("EnemyGoal").GetComponent<EnemyGoal>();
            }
            return _instance;
        }
    }
    public int passedEnemy = 0;
    public int score = 0;
    public Text passedText;
    public Text scoreText;

    public void EnemyPassCheck()
    {
        passedEnemy++;
        passedText.text = "통과한적:" + passedEnemy;
    }
    public void ScoreCheck()
    {
        score += 10;
        scoreText.text = "Score" + score;
    }
}
