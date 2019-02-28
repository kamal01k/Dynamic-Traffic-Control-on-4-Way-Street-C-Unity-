using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTL1 : MonoBehaviour {

    public Vector3 myPos;
    public Transform myPlay;

    public void Update()
    {
        transform.position = myPlay.position + myPos;
    }

}
