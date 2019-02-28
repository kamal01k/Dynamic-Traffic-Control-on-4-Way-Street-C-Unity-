using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSM : MonoBehaviour {

    [SerializeField]
    private GameObject GreenSign;
    [SerializeField]
    private GameObject RedSign;
    private Vector3 PositionSign1 = new Vector3(-0.1f, 7.3f, 2.9f);
    private Vector3 PositionSign2 = new Vector3(12.01f, 7.3f, -2.81f);
    private Vector3 PositionSign3 = new Vector3(17.97f, 7.3f, 13.37f);
    private Vector3 PositionSign4 = new Vector3(1.64f, 7.3f, 18.72f);
    public bool entered4 = false;
    public bool enteredchecking = false;
    

    // Use this for initialization

    void Start()
    {
        Instantiate(RedSign, PositionSign1, Quaternion.Euler(0, 0, 0));
        Instantiate(RedSign, PositionSign2, Quaternion.Euler(0, -90, 0));
        Instantiate(RedSign, PositionSign3, Quaternion.Euler(0, 180, 0));
        Instantiate(RedSign, PositionSign4, Quaternion.Euler(0, 90, 0));
        
    }

     void Update()
    {
        if (TrafficManagement.Green1 == true)
        {
            Destroy(GameObject.FindWithTag("Sign1"));
            Instantiate(GreenSign, PositionSign1, Quaternion.Euler(0, 0, 0));

        }
        else
        {
            Destroy(GameObject.FindWithTag("Sign1"));
            Instantiate(RedSign, PositionSign1, Quaternion.Euler(0, 0, 0));
        }

        if (TrafficManagement.Green2 == true)
        {
            Destroy(GameObject.FindWithTag("Sign2"));
            Instantiate(GreenSign, PositionSign2, Quaternion.Euler(0, -90, 0));

        }
        else
        {
            Destroy(GameObject.FindWithTag("Sign2"));
            Instantiate(RedSign, PositionSign2, Quaternion.Euler(0, -90, 0));
        }



        if (TrafficManagement.Green3 == true)
        {
            Destroy(GameObject.FindWithTag("Sign3"));
            Instantiate(GreenSign, PositionSign3, Quaternion.Euler(0, 180, 0));

        }
        else
        {
            Destroy(GameObject.FindWithTag("Sign3"));
            Instantiate(RedSign, PositionSign3, Quaternion.Euler(0, 180, 0));
        }


        if (TrafficManagement.Green4 == true)
        {
            Destroy(GameObject.FindWithTag("Sign4"));
            Instantiate(GreenSign, PositionSign4, Quaternion.Euler(0, 90, 0));


        }
        else
        {
            Destroy(GameObject.FindWithTag("Sign4"));
            Instantiate(RedSign, PositionSign4, Quaternion.Euler(0, 90, 0));
        }

        
    }
}







    
        


