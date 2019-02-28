using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSign : MonoBehaviour {
    private Vector3 PositionSign1 = new Vector3(-0.1f, 7.3f, 2.9f);
    private Vector3 PositionSign2 = new Vector3(12.01f, 7.3f, -2.81f);
    private Vector3 PositionSign3 = new Vector3(17.97f, 7.3f, 13.37f);
    private Vector3 PositionSign4 = new Vector3(1.64f, 7.3f, 18.72f);
    public bool entered1 = false;
    public bool entered2 = false;
    public bool entered3 = false;
    public bool entered4 = false;
    // Use this for initialization
    void Start ()
    {

        
		if (transform.position == PositionSign1)
        {
            transform.tag = "Sign1";
            entered1 = true;
        }
        else if (transform.position == PositionSign2)
        {
            transform.tag = "Sign2";
            entered2 = true;
        }
        else if (transform.position == PositionSign3)
        {
            transform.tag = "Sign3";
            entered3 = true;
        }
        else if(transform.position == PositionSign4)
        {
            transform.tag = "Sign4";
            entered4 = true;
        }
	}
	
	
	
}
