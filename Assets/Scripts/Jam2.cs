using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jam2 : MonoBehaviour {
    [SerializeField]
    public static bool JamOn2 = false;
    private float SteppedOn = 0.0f;
    public bool J = false;
    private bool entered = false;


    void OnTriggerEnter(Collider other)

    {
        SteppedOn = Time.time;

    }

    void OnTriggerStay(Collider other)
    {
        if ((Time.time - SteppedOn) > 1 && entered == false)
        {
            JamOn2 = true;
            entered = true;
        }        
        J = JamOn2;
        
    }

    void OnTriggerExit(Collider other)
    {
        JamOn2 = false;
        J = JamOn2;
        entered = false;
    }
}
