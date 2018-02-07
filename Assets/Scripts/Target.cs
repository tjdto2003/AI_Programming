using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public Transform targetMarker;
    

    void Start()
    {
        
    }

    void Update ()
    {
        int button = 0;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray.origin,ray.direction,out hitInfo))//ray origin = 카메라  ray.direction 방향 
            {
                Vector3 targetPosition = hitInfo.point;
                targetMarker.position = targetPosition;

            }
        }
	}
}
