using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Cars;
    [SerializeField]
    private GameObject Jams;
    
    private Vector3 Lane1 = new Vector3(-63.7f, 8.17f, 5.55f);
    private Vector3 Lane2 = new Vector3(9.5f, 8.17f, -62.22f);
    private Vector3 Lane3 = new Vector3(76.56f, 8.17f, 10.66f);
    private Vector3 Lane4 = new Vector3(4.18f, 8.17f, 77.01686f);
    private Vector3 Lane = new Vector3(0.0f,0.0f,0.0f);

    private Vector3 Jam1L = new Vector3(22.8f, -47.48069f, 44.5f);
    private Vector3 Jam2L = new Vector3(-29.2f, -47.48069f, 27.9f);
    private Vector3 Jam3L = new Vector3(-12.1f, -47.48069f, -27.7f);    
    private Vector3 Jam4L = new Vector3(42.7f, -47.48069f, -11.5f);

    private float y=0.0f;
    private int AmbT = 0;

    public float SpawnTime = 4.0f;
    private float ChangeTime = 50.0f;
    public bool Jam1T = false;
    public bool Jam2T = false;
    public bool Jam3T = false;
    public bool Jam4T = false;

    private bool EJam1T = false;
    private bool EJam2T = false;
    private bool EJam3T = false;
    private bool EJam4T = false;


    public  bool Scenario1 = false;
    // public  bool Scenario2 = false;
   // public  bool Scenario3 = false;
    public  bool Auto = true;

    public bool Emergency = false;

    // Use this for initialization
    void Start()
    {
        
        StartCoroutine("CarsRoutine");

    }






    

    IEnumerator CarsRoutine()
    {
        while (true)
        {

            while (Scenario1)
            {
                
                Instantiate(Cars[0], Lane1, Quaternion.Euler(0, 90, 0));
                Instantiate(Cars[1], Lane2, Quaternion.Euler(0, 0, 0));
                Instantiate(Cars[3], Lane3, Quaternion.Euler(0, -90, 0));
                Instantiate(Cars[0], Lane4, Quaternion.Euler(0, 180, 0));
                yield return new WaitForSeconds(1);
                Instantiate(Cars[3], Lane1, Quaternion.Euler(0, 90, 0));
                Instantiate(Cars[2], Lane2, Quaternion.Euler(0, 0, 0));
                Instantiate(Cars[0], Lane3, Quaternion.Euler(0, -90, 0));
                Instantiate(Cars[1], Lane4, Quaternion.Euler(0, 180, 0));
                yield return new WaitForSeconds(1);
                Instantiate(Cars[0], Lane1, Quaternion.Euler(0, 90, 0));
                Instantiate(Cars[1], Lane2, Quaternion.Euler(0, 0, 0));
                Instantiate(Cars[3], Lane3, Quaternion.Euler(0, -90, 0));
                Instantiate(Cars[0], Lane4, Quaternion.Euler(0, 180, 0));
                Scenario1 = false;
            }
            




            while (Auto)
            {
                
                if (Jam1T && EJam1T == false)
                {
                    Instantiate(Jams, Jam1L, Quaternion.Euler(0, 90, 0));
                    EJam1T = true;

                }

                if (Jam2T && EJam2T == false)
                {
                    Instantiate(Jams, Jam2L, Quaternion.Euler(0, 0, 0));
                    EJam2T = true;

                }

                if (Jam3T && EJam3T == false)
                {
                    Instantiate(Jams, Jam3L, Quaternion.Euler(0, -90, 0));
                    EJam3T = true;

                }

                if (Jam4T && EJam4T == false)
                {
                    Instantiate(Jams, Jam4L, Quaternion.Euler(0, 180, 0));
                    EJam4T = true;
                }




                RandomizeLane();
                CreatingCars(Lane, y);
                yield return new WaitForSeconds(SpawnTime);

                /*
                if (Time.time > ChangeTime)
                {
                    if (SpawnTime == 1.5f)
                    {
                        SpawnTime = 4.0f;
                    }
                    else if (SpawnTime == 4.0f)
                    {
                        SpawnTime = 1.5f;
                    }

                    ChangeTime += 50;
                }
                */
                

            }
            yield return new WaitForSeconds(0.01f);

        }
        
        
    }

   

    private void RandomizeLane()
    {
        int L = Random.Range(0, 5);

        

        if (L == 0)
        {
            Lane = Lane1;
            y = 90;

        }

        else if (L == 1)
        {
            Lane = Lane2;
            y = 0;

        }

        else if (L == 2)
        {
            Lane = Lane3;
            y = -90;

        }
        else if (L == 3)
        {
            Lane = Lane4;
            y = 180;

        }
    }

    private void CreatingCars(Vector3 Lan, float R)
    {

        

        int x = Random.Range(0, 4);

        
        if (Emergency)
        {
            if (Jam1.JamOn1 == false || Jam2.JamOn2 == false || Jam3.JamOn3 == false || Jam4.JamOn4 == false)
            {
                if (AmbT > 5)
                {
                    x = 4;
                    AmbT = 0;

                    if (Jam1.JamOn1 == false)
                    {
                        Lan = Lane3;
                        R = -90;
                    }
                    else if (Jam2.JamOn2 == false)
                    {
                        Lan = Lane4;
                        R = 180;
                    }
                    else if (Jam3.JamOn3 == false)
                    {
                        Lan = Lane1;
                        R = 90;
                    }
                    else if (Jam4.JamOn4 == false)
                    {
                        Lan = Lane2;
                        R = 0;
                    }
                    Lan = Lan + new Vector3(0.0f, -1.14f, 0.0f);
                }
            }
            
        }

        

        Instantiate(Cars[x], Lan, Quaternion.Euler(0, R, 0));
        AmbT++;


    }
}
