using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalCam : MonoBehaviour {
    [SerializeField]
    private Transform target;
    private Vector3 targetPosition;
    private void Updete()
    {
        targetPosition = transform.position;
        targetPosition.z = target.transform.position.z;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
    }


	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}
}
