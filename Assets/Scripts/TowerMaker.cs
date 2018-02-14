using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMaker : MonoBehaviour {

    public GameObject towerPrefab;

    
	void Update ()
    {
        if (Input.GetKeyDown ( KeyCode.Mouse0))
            {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray.origin,ray.direction, out hitInfo))
            {
                // Debug.Log(hitInfo.transform.name);
                switch(hitInfo.transform.tag )
                {
                    case"Wall":
                        Instantiate(towerPrefab,hitInfo.transform.position+new Vector3(0,1f,0),towerPrefab.transform.rotation);
                        break;
                    case "Plane":
                        Debug.Log("그곳에는 타워를 설치할수없습니다.!!");
                        break;
                    case "Enemy":
                        Debug.Log("선택된 적의 이름은:"+hitInfo.transform.name);
                        break;
                }
               
            }
        }
	}
}
