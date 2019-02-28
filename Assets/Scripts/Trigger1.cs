using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1 : MonoBehaviour {
    private bool entered = false;
    private bool TurnedGreen = false;
    private float StoppingTme = 0.0f;
	
	

    void OnTriggerEnter(Collider other)
    {
        TrafficManagement.Trigger1 = true;
        if (TrafficManagement.Green1 == false)
        {
            TrafficManagement.TriggerTime1 = Time.time;
            StoppingTme = Time.time;
        }
             
        
        
    }


    void OnTriggerStay(Collider other)
    {
        TrafficManagement.Trigger1 = true;
        CarMoving car = other.GetComponent<CarMoving>();

        if (TrafficManagement.Green1 == false)
        {
            car.Speed = 0.0f;
            TurnedGreen = false;
        }
        else if ((Time.time - StoppingTme) > 2)
        {
            StartCoroutine("Delay");
        }
        else
            TurnedGreen = true;

        if (TurnedGreen == true)
        {
            if (car.N == 1.14f)
                car.Speed = 23.0f;
            else
                car.Speed = 15.0f;
        }
        

        if (TrafficManagement.Green1==false && entered == false && TrafficManagement.TriggerTime1==0.0f)
        {
            entered = true;
            TrafficManagement.TriggerTime1 = Time.time;
            
        }
        else if(TrafficManagement.TriggerTime1==0.0f && car.Speed == 0.0f)
        {
            entered = false;
        }
    }


    void OnTriggerExit(Collider other)
    {
        TrafficManagement.Trigger1 = false;
        TrafficManagement.TriggerTime1 = 0.0f;
        CarMoving car = other.GetComponent<CarMoving>();
        car.tag = "defaull";

    }

    IEnumerator Delay()
    {
         yield return new WaitForSeconds(1f);
        TurnedGreen = true;
    }


}
