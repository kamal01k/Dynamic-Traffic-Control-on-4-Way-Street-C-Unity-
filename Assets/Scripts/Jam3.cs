using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jam3 : MonoBehaviour {
    [SerializeField]
    public static bool JamOn3 = false;
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
            JamOn3 = true;
            entered = true;
        }

        J = JamOn3;
    }

    void OnTriggerExit(Collider other)
    {
        JamOn3 = false;
        entered = false;
        J = JamOn3;

    }
}
