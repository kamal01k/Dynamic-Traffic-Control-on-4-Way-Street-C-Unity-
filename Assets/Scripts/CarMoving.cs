using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   

public class CarMoving : MonoBehaviour
{
    [SerializeField]
    public float Speed = 12.0f;
    private float rotate = 0.5f;
    private bool entered = false;    
    private Vector3 L1 = new Vector3(-63.7f, 8.17f, 5.55f);
    private Vector3 L2 = new Vector3(9.5f, 8.17f, -62.22f);
    private Vector3 L3 = new Vector3(76.56f, 8.17f, 10.66f);
    private Vector3 L4 = new Vector3(4.18f, 8.17f, 77.01686f);

    private Vector3 L1am = new Vector3(-63.7f, 7.03f, 5.55f);
    private Vector3 L2am = new Vector3(9.5f, 7.03f, -62.22f);
    private Vector3 L3am = new Vector3(76.56f, 7.03f, 10.66f);
    private Vector3 L4am = new Vector3(4.18f, 7.03f, 77.01686f);

    public bool L11 = false;
    public bool L22 = false;
    public bool L33 = false;
    public bool L44 = false;
    public bool RC = false;
    private bool GoStraight = true;
    public float N = 0.0f;
    private bool EnteredRay = false;

    private void Start()
    {

        if (transform.position.y < 7.0f)
        {
            Destroy(this.gameObject);
        }

        this.gameObject.name = "Car" + Time.time;

        if (transform.position.y == 7.03f)
        {
            N = 1.14f;
            Speed = 18;
            transform.name = "Emergency";
        }

        

        if (transform.position == L1 || transform.position == L1am)
        {
            transform.tag = "Lane1";
            L11 = true;
        }
        else if (transform.position == L2 || transform.position == L2am)
        {
            transform.tag = "Lane2";
            L22 = true;
        }


        else if (transform.position == L3 || transform.position == L3am)
        {
            transform.tag = "Lane3";
            L33 = true;
        }


        else if (transform.position == L4 || transform.position == L4am)
        {
            transform.tag = "Lane4";
            L44 = true;
        }



    }

    // Update is called once per frame
    void Update()

    {
        Sorting();

    }



    private void Sorting()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (this.gameObject.tag.Equals("Lane1"))
        {
            MovementL1(Random.Range(0, 3));
        }

        else if (this.gameObject.tag.Equals("Lane2"))
        {
            MovementL2(Random.Range(0, 3));
        }

        else if (this.gameObject.tag.Equals("Lane3"))
        {
            MovementL3(Random.Range(0, 3));
        }

        else if (this.gameObject.tag.Equals("Lane4"))
        {
            MovementL4(Random.Range(0, 3));
        }
        else if (Physics.Raycast(transform.position + new Vector3(0.0f, N, 0.0f), fwd, 5))
        {
            RC = true;
            transform.Translate(Vector3.forward * 0);
        }
        else if (GoStraight == true)
            Straight();
    }

    public void MovementL1(int x)
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position + new Vector3(0.0f,N,0.0f), fwd, 5))
        {
            RC = true;
            transform.Translate(Vector3.forward * 0);
            EnteredRay = true;
        }

        else if(EnteredRay == true)
        {
            StartCoroutine("Delay");
        }

        else if (transform.position.x >= -8.84 & entered == false)
        {
            entered = true;
            StartCoroutine("Turn1", x);
        }

        else if (GoStraight == true)
        {
            Straight();
        }

    }

    public void MovementL2(int x)
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position + new Vector3(0.0f, N, 0.0f), fwd, 5))
        {
            RC = true;
            transform.Translate(Vector3.forward * 0);
            EnteredRay = true;
        }

        else if (EnteredRay == true)
        {
            StartCoroutine("Delay");
        }

        else if (transform.position.z >= -7 & entered == false)
        {
            entered = true;
            StartCoroutine("Turn2", x);
        }

        else if (GoStraight == true)
        {
            Straight();
        }
    }

        public void MovementL3(int x)
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position + new Vector3(0.0f, N, 0.0f), fwd, 5))
        {
            RC = true;
            transform.Translate(Vector3.forward * 0);
            EnteredRay = true;
        }

        else if (EnteredRay == true)
        {
            StartCoroutine("Delay");
        }

        else if (transform.position.x <= 22 & entered == false)
        {
            entered = true;
            StartCoroutine("Turn3", x);
        }

        else if (GoStraight == true)
        {
                Straight();
            }

        }

    public void MovementL4(int x)
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position + new Vector3(0.0f, N, 0.0f), fwd, 5))
        {
            RC = true;
            transform.Translate(Vector3.forward * 0);
            EnteredRay = true;
        }

        else if (EnteredRay == true)
        {
            StartCoroutine("Delay");
        }

        else if (transform.position.z <= 23 & entered == false)
        {
            entered = true;
            StartCoroutine("Turn4", x);
        }

        else if (GoStraight == true)
        {
            Straight();
        }

    }

    IEnumerator Delay()
    {
        Speed = 0;
        yield return new WaitForSeconds(0.25f);
        Speed = 2.0f ;
        yield return new WaitForSeconds(0.25f);
        Speed = 15.0f;
        EnteredRay = false;
    }


    IEnumerator Turn1(int x)
        {

        if (ERoadSign1.Situation == 0)
        {
            x = 2;
        }
        else if (ERoadSign1.Situation == 1)
        {
            x = 0;
        }
        else if (ERoadSign1.Situation == 2)
        {
            x = 1;
        }
        else if (ERoadSign1.Situation == 3)
        {
            if (Random.value < 0.5f)
                x = 0;
            else
                x = 2;
        }
        else if (ERoadSign1.Situation == 3)
        {
            if (Random.value < 0.5f)
                x = 0;
            else
                x = 2;
        }
        else if (ERoadSign1.Situation == 4)
        {
            if (Random.value < 0.5f)
                x = 0;
            else
                x = 1;
        }
        else if (ERoadSign1.Situation == 5)
        {
            if (Random.value < 0.5f)
                x = 1;
            else
                x = 2;
        }



        if (N == 1.14f)
            x = 1;

            if (x == 0)
            {
                RightF();
                yield return new WaitForSeconds(10);
               // DestroyObject(this.gameObject);
            }
            else if (x == 1)
            {
                GoStraight = true;
                yield return new WaitForSeconds(10);
               // DestroyObject(this.gameObject);
            }
            else if (x == 2)
            {
                LeftF();
                yield return new WaitForSeconds(10);
               // DestroyObject(this.gameObject);
            }
        }

    IEnumerator Turn2(int x)
    {

        if (ERoadSign2.Situation == 0)
        {
            x = 2;
        }
        else if (ERoadSign2.Situation == 1)
        {
            x = 0;
        }
        else if (ERoadSign2.Situation == 2)
        {
            x = 1;
        }
        else if (ERoadSign2.Situation == 3)
        {
            if (Random.value < 0.5f)
                x = 0;
            else
                x = 2;
        }
        else if (ERoadSign2.Situation == 3)
        {
            if (Random.value < 0.5f)
                x = 0;
            else
                x = 2;
        }
        else if (ERoadSign2.Situation == 4)
        {
            if (Random.value < 0.5f)
                x = 0;
            else
                x = 1;
        }
        else if (ERoadSign2.Situation == 5)
        {
            if (Random.value < 0.5f)
                x = 1;
            else
                x = 2;
        }

        if (N == 1.14f)
            x = 1;


        if (x == 0)
        {
            Right2();
            yield return new WaitForSeconds(10);
           // DestroyObject(this.gameObject);
        }
        else if (x == 1)
        {
            GoStraight = true;
            yield return new WaitForSeconds(10);
           // DestroyObject(this.gameObject);
        }
        else if (x == 2)
        {
            Left2();
            yield return new WaitForSeconds(10);
           // DestroyObject(this.gameObject);
        }
    }

    IEnumerator Turn3(int x)
    {
        if (ERoadSign3.Situation == 0)
        {
            x = 2;
        }
        else if (ERoadSign3.Situation == 1)
        {
            x = 0;
        }
        else if (ERoadSign3.Situation == 2)
        {
            x = 1;
        }
        else if (ERoadSign3.Situation == 3)
        {
            if (Random.value < 0.5f)
                x = 0;
            else
                x = 2;
        }
        else if (ERoadSign3.Situation == 3)
        {
            if (Random.value < 0.5f)
                x = 0;
            else
                x = 2;
        }
        else if (ERoadSign3.Situation == 4)
        {
            if (Random.value < 0.5f)
                x = 0;
            else
                x = 1;
        }
        else if (ERoadSign3.Situation == 5)
        {
            if (Random.value < 0.5f)
                x = 1;
            else
                x = 2;
        }


        if (N == 1.14f)
            x = 1;



        if (x == 0)
        {
            Right3();
            yield return new WaitForSeconds(10);
          //  DestroyObject(this.gameObject);
        }
        else if (x == 1)
        {
            GoStraight = true;
            yield return new WaitForSeconds(10);
           // DestroyObject(this.gameObject);
        }
        else if (x == 2)
        {
            Left3();
            yield return new WaitForSeconds(10);
          //  DestroyObject(this.gameObject);
        }
    }

    IEnumerator Turn4(int x)
    {
        if (ERoadSign4.Situation == 0)
        {
            x = 2;
        }
        else if (ERoadSign4.Situation == 1)
        {
            x = 0;
        }
        else if (ERoadSign4.Situation == 2)
        {
            x = 1;
        }
        else if (ERoadSign4.Situation == 3)
        {
            if (Random.value < 0.5f)
                x = 0;
            else
                x = 2;
        }
        else if (ERoadSign4.Situation == 3)
        {
            if (Random.value < 0.5f)
                x = 0;
            else
                x = 2;
        }
        else if (ERoadSign4.Situation == 4)
        {
            if (Random.value < 0.5f)
                x = 0;
            else
                x = 1;
        }
        else if (ERoadSign4.Situation == 5)
        {
            if (Random.value < 0.5f)
                x = 1;
            else
                x = 2;
        }

        if (N == 1.14f)
            x = 1;

        if (x == 0)
        {
            Right4();
            yield return new WaitForSeconds(10);
           // DestroyObject(this.gameObject);
        }
        else if (x == 1)
        {
            GoStraight = true;
            yield return new WaitForSeconds(10);
          //  DestroyObject(this.gameObject);
        }
        else if (x == 2)
        {
            Left4();
            yield return new WaitForSeconds(10);
          //  DestroyObject(this.gameObject);
        }
    }


    private void Straight()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }


    private void RightF()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("RightF"), "time",15 , "orientToPath", true));
    }

    private void Right2()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Right2"), "time", 15, "orientToPath", true));
    }

    private void Right3()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Right3"), "time", 15, "orientToPath", true));
    }

    private void Right4()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Right4"), "time", 15, "orientToPath", true));
    }

    private void LeftF()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("LeftF"), "time", 15, "orientToPath", true));
    }
    private void Left2()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Left2"), "time", 15, "orientToPath", true));
    }

    private void Left3()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Left3"), "time", 15, "orientToPath", true));
    }

    private void Left4()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Left4"), "time", 15, "orientToPath", true));
    }



}

 


    

