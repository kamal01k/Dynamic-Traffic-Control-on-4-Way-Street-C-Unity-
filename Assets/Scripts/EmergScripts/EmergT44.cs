using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergT44 : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        CarMoving car = other.GetComponent<CarMoving>();
        if (car.name == "Emergency")
        {
            TrafficManagement.Emerg = false;
            TrafficManagement.EmergT4 = false;
        }
    }
}
