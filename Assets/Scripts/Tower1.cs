using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower1 : MonoBehaviour
{

    public float fireCool;
    public float fireDelay;
    public GameObject bullet;
    public Transform firePosition;
    public List<GameObject> lookOBJ;
    public float rotationSpeed = 60f;
    void Start()
    {

    }


    void Update()
    {

        if (lookOBJ.Count > 0)
        {
            if (lookOBJ[0] != null)
            {
                Vector3 dir = lookOBJ[0].transform.position - transform.position;
                dir.y = 0.0f;
                dir.Normalize();
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
                fireCool += Time.deltaTime;


                if (fireCool > fireDelay)
                {
                    fireCool = 0;
                    GameObject towerBullet = Instantiate(bullet) as GameObject;
                    firePosition.transform.LookAt(lookOBJ[0].transform);
                    towerBullet.transform.position = firePosition.position;
                    towerBullet.transform.localRotation = firePosition.rotation;

                }
            }
            else
            {
                lookOBJ.RemoveAt(0);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {

       if (col.gameObject.tag == "Enemy")
        {
            Debug.Log(col.name);
            lookOBJ.Add(col.gameObject);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log(col.name);
            lookOBJ.Remove(col.gameObject);
          
        }
    
    }
}



