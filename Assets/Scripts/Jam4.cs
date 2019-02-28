using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jam4 : MonoBehaviour {
    [SerializeField]
    public static bool JamOn4 = false;
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
            JamOn4 = true;
            entered = true;
        }

        J = JamOn4;
        

    }

    void OnTriggerExit(Collider other)
    {
        JamOn4 = false;
        J = JamOn4;
        entered = false;
    }
}
