using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario3Amb : MonoBehaviour {

    private float GT;


    public static bool Trigger1 = false;
    public static bool Green1 = false;
    public static float TriggerTime1;
    public bool T1 = false;
    public bool G1 = false;
    public float TT1;

    public static bool Trigger2 = false;
    public static bool Green2 = false;
    public static float TriggerTime2;
    public bool T2 = false;
    public bool G2 = false;
    public float TT2;

    public static bool Trigger3 = false;
    public static bool Green3 = false;
    public static float TriggerTime3;
    public bool T3 = false;
    public bool G3 = false;
    public float TT3;

    public static bool Trigger4 = false;
    public static bool Green4 = false;
    public static float TriggerTime4;
    public bool T4 = false;
    public bool G4 = false;
    public float TT4;
    private float[] Times = { 0.0f, 0.0f, 0.0f, 0.0f };

    public bool entered1 = false;
    public bool entered2 = false;
    public bool entered3 = false;
    public bool entered4 = false;

    private string ambTag = "";
    private int y = -1;
    public static bool Emerg = false;
    public static bool EmergT1 = false;
    public static bool EmergT2 = false;
    public static bool EmergT3 = false;
    public static bool EmergT4 = false;
    // Update is called once per frame
    void Update()
    {


        if (Emerg == true)
        {

            if (EmergT1 == true)
            {
                TrafficManagement.Green1 = true;
                TrafficManagement.Green2 = false;
                TrafficManagement.Green3 = false;
                TrafficManagement.Green4 = false;
            }

            else if (EmergT2 == true)
            {
                TrafficManagement.Green1 = false;
                TrafficManagement.Green2 = true;
                TrafficManagement.Green3 = false;
                TrafficManagement.Green4 = false;
            }

            else if (EmergT3 == true)
            {
                TrafficManagement.Green1 = false;
                TrafficManagement.Green2 = false;
                TrafficManagement.Green3 = true;
                TrafficManagement.Green4 = false;
            }
            else if (EmergT4 == true)
            {
                TrafficManagement.Green1 = false;
                TrafficManagement.Green2 = false;
                TrafficManagement.Green3 = false;
                TrafficManagement.Green4 = true;
            }
        }

        else
        {
            Setting();

            Sorting();

            Manage();

            Times = new float[] { 0.0f, 0.0f, 0.0f, 0.0f };
        }















    }

    private void Setting()
    {
        T1 = Trigger1;
        G1 = Green1;
        TT1 = TriggerTime1;

        T2 = Trigger2;
        G2 = Green2;
        TT2 = TriggerTime2;

        T3 = Trigger3;
        G3 = Green3;
        TT3 = TriggerTime3;

        T4 = Trigger4;
        G4 = Green4;
        TT4 = TriggerTime4;


        Times[0] = TriggerTime1;
        Times[1] = TriggerTime2;
        Times[2] = TriggerTime3;
        Times[3] = TriggerTime4;

    }

    private void Sorting()
    {
        float temp = 0.0f;
        for (int write = 0; write < Times.Length; write++)
        {
            for (int sort = 0; sort < Times.Length - 1; sort++)
            {
                if (Times[sort] > Times[sort + 1])
                {
                    temp = Times[sort + 1];
                    Times[sort + 1] = Times[sort];
                    Times[sort] = temp;
                }
            }
        }
    }



    private void Manage()
    {

        for (int i = 0; i < 4; i++)
        {
            if (Times[i] == TT1 && TT1 != 0.0f)
            {

                StartCoroutine(Greening(1));
            }
            else if (Times[i] == TT2 && TT2 != 0.0f)
            {

                StartCoroutine(Greening(2));
            }
            else if (Times[i] == TT3 && TT3 != 0.0f)
            {

                StartCoroutine(Greening(3));
            }
            else if (Times[i] == TT4 && TT4 != 0.0f)
            {

                StartCoroutine(Greening(4));
            }
        }


    }

    IEnumerator Greening(int x)
    {




        if (x == 1 && entered1 == false)
        {

            GT = (GameObject.FindGameObjectsWithTag("Lane1").Length) * 1.3f;



            entered1 = true;
            TrafficManagement.Green1 = true;
            TrafficManagement.Green2 = false;
            TrafficManagement.Green3 = false;
            TrafficManagement.Green4 = false;

            yield return new WaitForSeconds(GT);
            TrafficManagement.Green1 = false;
            TrafficManagement.Green2 = false;
            TrafficManagement.Green3 = false;
            TrafficManagement.Green4 = false;

            yield return new WaitForSeconds(2);
            entered1 = false;

        }

        else if (x == 2 && entered1 == false)
        {

            GT = (GameObject.FindGameObjectsWithTag("Lane2").Length) * 1.3f;



            entered1 = true;
            TrafficManagement.Green1 = false;
            TrafficManagement.Green2 = true;
            TrafficManagement.Green3 = false;
            TrafficManagement.Green4 = false;
            yield return new WaitForSeconds(GT);
            TrafficManagement.Green1 = false;
            TrafficManagement.Green2 = false;
            TrafficManagement.Green3 = false;
            TrafficManagement.Green4 = false;

            yield return new WaitForSeconds(2);
            entered1 = false;

        }
        else if (x == 3 && entered1 == false)
        {

            GT = (GameObject.FindGameObjectsWithTag("Lane3").Length) * 1.3f;




            entered1 = true;
            TrafficManagement.Green1 = false;
            TrafficManagement.Green2 = false;
            TrafficManagement.Green3 = true;
            TrafficManagement.Green4 = false;

            yield return new WaitForSeconds(GT);
            TrafficManagement.Green1 = false;
            TrafficManagement.Green2 = false;
            TrafficManagement.Green3 = false;
            TrafficManagement.Green4 = false;

            yield return new WaitForSeconds(2);
            entered1 = false;

        }

        else if (x == 4 && entered1 == false)
        {


            GT = (GameObject.FindGameObjectsWithTag("Lane4").Length) * 1.3f;



            entered1 = true;
            TrafficManagement.Green1 = false;
            TrafficManagement.Green2 = false;
            TrafficManagement.Green3 = false;
            TrafficManagement.Green4 = true;
            yield return new WaitForSeconds(GT);
            TrafficManagement.Green1 = false;
            TrafficManagement.Green2 = false;
            TrafficManagement.Green3 = false;
            TrafficManagement.Green4 = false;

            yield return new WaitForSeconds(2);
            entered1 = false;

        }


    }
}

