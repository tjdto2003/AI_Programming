using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour
{

    public Transform targetTransfrom;
    private float movementSpeed;
    private float rotSpeed;

    void Start()
    {
        movementSpeed = 10.0f;
        rotSpeed = 2.0f;
        targetTransfrom = GameObject.Find("Target").transform;
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, targetTransfrom.position) < 5.0f)//타겟과의 거리가 5보다작으면 작동중이
            return;

        Vector3 tarPos = targetTransfrom.position;
        tarPos.y = transform.position.y;
        Vector3 dirRot = tarPos - transform.position;
        Quaternion tarRot = Quaternion.LookRotation(dirRot);
        transform.rotation = Quaternion.Slerp(transform.rotation, tarRot, rotSpeed * Time.deltaTime);
        transform.Translate(new Vector3(0, 0, movementSpeed * Time.deltaTime));
    }
}



