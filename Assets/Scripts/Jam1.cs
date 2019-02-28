using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jam1 : MonoBehaviour {
    [SerializeField]
    public static bool JamOn1 = false;
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
            JamOn1 = true;
            entered = true;
        }
        J = JamOn1;
        

    }

    void OnTriggerExit(Collider other)
    {
        JamOn1 = false;
        J = JamOn1;
        entered = false;
    }
}
