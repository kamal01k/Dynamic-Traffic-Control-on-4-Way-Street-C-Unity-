﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergT1 : MonoBehaviour {



    void OnTriggerEnter(Collider other)
    {
        CarMoving car = other.GetComponent<CarMoving>();
        if(car.name=="Emergency")
        {
            TrafficManagement.Emerg = true;
            TrafficManagement.EmergT1 = true;
        }
    }



}
