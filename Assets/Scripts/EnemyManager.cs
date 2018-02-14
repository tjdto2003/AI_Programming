using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public float RespwanCool;
    public float RespwanDelay;
    public GameObject Enemy;
    public Transform EnemyPosition;
    public int enemyCount;

    void Start ()
    {
		
	}
	
	
	void Update ()
    {
        RespwanCool += Time.deltaTime;
        if(RespwanCool > RespwanDelay)
        {
            RespwanCool = 0;
            enemyCount++;
            GameObject instacneEnemy = Instantiate(Enemy) as GameObject;
            instacneEnemy.name = "Enemy_" + enemyCount;
            instacneEnemy.transform.position = EnemyPosition.position;
            instacneEnemy.GetComponent<Crowdagent>().target = GameObject.FindGameObjectWithTag("EnemyGoal").transform;
        }
	}
}
