using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour {
    public List<int> a = new List<int>();
    public List<int> b, c = new List<int>();
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 5; i++)
        {
            a.Add(3);
        }
        for (int i=0;i<5;i++)
        {
            b.Add(a[i]);
        }
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(a[i]+"AAAAAAAAAAAAAAAAAAAA");
        }
        test();
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(a[i]+"BBBBBBBBBBBBBBBBBBBBBB");
        }
        List<int[]> aaa = new List<int[]>();
        for (int i=0;i<5;i++)
        {
            int[] bbb = new int[5];
            for (int j=0;j<4;j++)
            {
                bbb[j] =0;
            }
            aaa.Add(bbb);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void test()
    {
        for (int i = 0; i < 5; i++)
        {
            c.Add(7);
            b = c;
            Debug.Log("Hello");
        }


    }
}
