using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample002 : MonoBehaviour {
    Renderer render;
    Color color;
    float d = -0.005f;
	// Use this for initialization
	void Start () {
        render = GetComponent<Renderer>();
        color = render.material.color;
	}
	
	// Update is called once per frame
	void Update () {

        /*if (Input.GetKey(KeyCode.C))
        {
            //gameObject.layer = 1;
            //MeshRenderer meshrender = GetComponent<MeshRenderer>();
            //meshrender.material.color = new Color(0f, 0f, 0f, 1.0f);

            color.a = 1.0f;
            Debug.Log("toumei");
            render.material.color = color;
        }*/
        bool down = Input.GetMouseButton(0);
        if (down) {
            if (color.a <= 0)
            {
                d = 0.005f;
            }
            if (color.a >= 1f)
            {
                d = -0.005f;
            }
            color.a += d;
            render.material.color = color;
        }
    }
}
