using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTrigger : MonoBehaviour
{

    public GameObject ExposionPrefab;

    public int enemyHp = 100;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "EnemyGoal")
        {

            Debug.Log("목적지도착!!!");
            EnemyGoal.instance.EnemyPassCheck();
            Destroy(gameObject);
          
        }
        


        if (col.gameObject.tag == "Bullet")
        {
            enemyHp -= 100;
            if (enemyHp <= 0)
            {
                Instantiate(ExposionPrefab, transform.position, transform.rotation);
                Destroy(GameObject.Find("Exposion(Clone)"), 1);
                EnemyGoal.instance.ScoreCheck();
                Destroy(gameObject);
            }
            else
            {
                Instantiate(ExposionPrefab, transform.position, transform.rotation);

            }
        }
    }
}

