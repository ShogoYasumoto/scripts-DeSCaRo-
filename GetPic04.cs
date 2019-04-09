using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetPic04 : MonoBehaviour
{
    public Camera ShadowCamera;
    private Texture2D targetTexture;
    bool destroyob = false;
    bool dw = false;
    bool isCalled = false;
    int get = 13824;
    [HideInInspector]
    public int count = 0;
    [HideInInspector]
    public int[] coodinate = new int[35537];
    [HideInInspector]
    public List<int[]> getMemory = new List<int[]>();
    [HideInInspector]
    public List<int[]> newMemory = new List<int[]>();
    //[HideInInspector]
    //public int[] newArray = new int[35536];
    public int[] Array01 = new int[51712];




    //test
    public int countt = 0;
    public int counttt = 0;
    private int oppi = 0;
    public int megamax = 0;
    public int saigen = 0;
    public float Saigen = 0;
    public int ff01 = 0;

    // Use this for initialization
    void Start()
    {
        var tex = ShadowCamera.targetTexture;
        targetTexture = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);
        GameObject ob = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ob.layer = 1;
        ob.transform.localScale = new Vector3(50, 60, 1);
        ob.transform.localPosition = new Vector3(0, 0, 33);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 2.0f)
        {
            if (isCalled == false)
            {
                isCalled = true;
                FF();
            }
        }
    }

    public void FF()
    {
        var tex = ShadowCamera.targetTexture;
        targetTexture = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);
        RenderTexture.active = ShadowCamera.targetTexture;
        targetTexture.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        targetTexture.Apply();

        int ff03 = 0;

        /*for (int i = get; i< 35536; i++)
        {
            //int[] coodinate = new int[tex.height * tex.width];
            coodinate[i] = 0;
            saigen++;
        }*/
        //int[] Array01 = new int[51712];
        for (int i = 0; i < 51712; i++)
        {
            var color = targetTexture.GetPixel((i + 13825) % tex.width, (i + 13825) / tex.height);
            Array01[i] = 0;
            ff03++;
            if (color.r <= 0.8 && color.g <= 0.8 && color.b <= 0.8)
            {
                ff01++;
                Array01[i] = -1;
                Debug.Log(ff01);
            }
        }

        /*for (int i = get; i < 35536; i++)
        {
            var color = targetTexture.GetPixel(i % tex.width - 1, i / tex.width);
            if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
            {
                //int[] coodinate = new int[tex.height * tex.width];
                coodinate[i] = -1;
                //countt++;
            }
        }*/
        /*for (int i = tex.height * 54; i < tex.height * tex.width; i++)
        {
            var color = targetTexture.GetPixel(i % tex.width, i / tex.height);
            if (color.r <= 0.8 && color.g <= 0.8 && color.b <= 0.8)
            {
                ff01++;
                Array01[i] = -1;
            }
        }*/
        //Debug.Log(ff01);
        //Debug.Log(Temp.Length);
        //////////////////////////////////////////////////////////////////////
        destroyob = true;
        if (destroyob)
        {
            Destroy(GameObject.Find("SPlight"));
            Destroy(GameObject.Find("Cube"));
        }
    }
    //点数評価を行うメソッド
    public void FF3()
    {

        /*GameObject makeWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        makeWall.transform.localScale = new Vector3(45, 30, 1);
        makeWall.transform.localPosition = new Vector3(-0.5f, 18, -0.9f);
        makeWall.layer = 0;*/
        GameObject gameobj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        gameobj.transform.localScale = new Vector3(45, 30, 1);
        gameobj.transform.localPosition = new Vector3(-0.5f, 18, -0.9f);
        gameobj.layer = 1;

        //int[] coodinate = new int[1];
        //List<int[]> getMemory = new List<int[]>();
        counttt = 0;
        //count = 0;
        countt = 0;
        //rendertextureをアクティブに設定
        int ff04 = 0;
        int ff05 = 0;

        var tex = ShadowCamera.targetTexture;
        targetTexture = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);
        RenderTexture.active = ShadowCamera.targetTexture;
        targetTexture.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        targetTexture.Apply();

        //////////////////////////////////////////////////////////////////
        int[] Temp = new int[51712];
        Temp = Array01;
        int[] Array02 = new int[tex.height * tex.width];
        for (int i = 0; i < 51712; i++)
        {
            Array02[i] = 0;
            var color = targetTexture.GetPixel((i + 13825) % tex.width, (i + 13825) / tex.height);
            if (color.r <= 0.8 && color.g <= 0.8 && color.b <= 0.8)
            {
                Array02[i] = -1;
                ff04++;
            }
        }
        Debug.Log(ff04);

        for (int i = 0; i < 51712; i++)
        {
            if (Temp[i] == -1 && Array02[i] == -1)
            {
                ff05++;
                //重なり
            }
        }
        Debug.Log("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" + ff04);
        Debug.Log("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" + ff05);
        oppi = (100 * ff05) / (ff04 + ff05);
        Saigen = (100 * ff05) / ff01;
        count = oppi;
        countt = ff04;
        megamax = ff05;
        //////////////////////////////////////////////////////////////////

        //配列のコピー
        /*int[] newArray = new int[coodinate.Length];
        Array.Copy(coodinate, newArray, coodinate.Length);

        for (int i = get; i < 35536; i++)
        {
            var color = targetTexture.GetPixel(i % tex.width - 1, i / tex.width);
            if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
            {
                newArray[i] = coodinate[i] - 1;
            }
        }
        for (int i =get; i <35536; i++)
        {
            if (newArray[i] == -1)
            {
                countt++;
            }
            if (newArray[i] == -2)
            {
                counttt++;
            }
        }

        //適合率
        oppi = (100 * counttt) / (countt + counttt);
        //再現率
        Saigen = (100 * counttt) / saigen;
        count = oppi;
        megamax = counttt;
        Debug.Log("++++++++++++++++++++++++++++"+oppi+"+++++++++++++++++++++++++++++");
        Debug.Log("+++++++++++++++++++++++++++"+Saigen + "+++++++++++++++++++++++++++++");
        Debug.Log(countt + "**************************");
        Debug.Log(counttt + "**************************");*/
        //Debug.Log(answer(countt, counttt) + "%");
        dw = true;
        if (dw)
        {
            //Debug.Log("****************************************");
            Destroy(GameObject.Find("Cube"));
            dw = false;
        }
    }
}

