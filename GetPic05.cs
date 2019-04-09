using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPic05 : MonoBehaviour {
    public Camera ShadowCamera;
    private Texture2D targetTexture;
    bool isCalled = false;
    private int bottom = 13824;
    public int[] Temp = new int[21739];
    bool destroyob = false;
    bool dw = false;
    // Use this for initialization
    void Start ()
    {
        var tex = ShadowCamera.targetTexture;
        targetTexture = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);
        GameObject ob = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ob.layer = 1;
        ob.transform.localScale = new Vector3(50, 60, 1);
        ob.transform.localPosition = new Vector3(0, 0, 33);
    }

    void Update()
    {
        if (Time.time > 2.0f)
        {
            if (isCalled == false)
            {
                isCalled = true;
                FF01();
            }
        }
    }
    public void FF01()
    {
        var tex = ShadowCamera.targetTexture;
        targetTexture = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);
        RenderTexture.active = ShadowCamera.targetTexture;
        targetTexture.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        targetTexture.Apply();
        int ff01 = 0;
        int ff03 = 0;

        int[] Array01 = new int[tex.height*tex.width];
        for (int i = tex.height * 54; i < tex.height * tex.width; i++)
        {
            Array01[i] = 0;
            ff03++;
        }
        Temp = Array01;
        for (int i = tex.height*54; i < tex.height * tex.width; i++)
        {
            var color = targetTexture.GetPixel(i % tex.width, i / tex.height);
            if (color.r <= 0.8 && color.g <= 0.8 && color.b <= 0.8)
            {
                ff01++;
                Array01[i] = -1;
            }
        }
        Debug.Log(ff03);
        Debug.Log(ff01);
        destroyob = true;
        if (destroyob)
        {
            Destroy(GameObject.Find("SPlight"));
            Destroy(GameObject.Find("Cube"));
        }
    }
    public void FF02()
    {
        var tex = ShadowCamera.targetTexture;
        targetTexture = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);
        RenderTexture.active = ShadowCamera.targetTexture;
        targetTexture.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        targetTexture.Apply();
        int ff02 = 0;

        int[] Array02 = new int[tex.height*tex.width];
        for (int i = tex.height * 54; i < tex.height * tex.width; i++)
        {
            Array02[i] = -1;
        }
        for (int i = tex.height * 54; i < tex.height * tex.width; i++)
        {
            var color = targetTexture.GetPixel(i % tex.width, i / tex.height);
            if (color.r <= 0.8 && color.g <= 0.8 && color.b <= 0.8)
            {
                ff02++;
            }
        }
        Debug.Log(ff02+"+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

        dw = true;
        if (dw)
        {
            Debug.Log("****************************************");
            Destroy(GameObject.Find("Cube"));
            dw = false;
        }
    }
}
