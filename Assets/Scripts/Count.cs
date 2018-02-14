using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour {

    public TextMesh Text;
    public int Score;
   
    

     void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("!!!");
            Score += 1;
            Text.text = (""+Score.ToString());

        }

    }


}
