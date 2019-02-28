using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEst : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");
        rend.material.mainTextureScale = new Vector2(100.0f, 100.0f);
    }
	
	
}
