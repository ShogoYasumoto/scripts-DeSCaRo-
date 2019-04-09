using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPic03 : MonoBehaviour {
    public Camera ShadowCamera;
    private Texture2D targetTexture;
    bool destroyob = false;
    int count = 0;
    int count02 = 0, count03=0;
    bool isCalled = false;
    int xxx = 0, xMax = 0, xMin = 256;
    int countup = 0, countdown = 0;
    public int servo3 = 0, servo4 = 0, servo5 = 0, servo6 = 0, servo7 = 0, servo8 = 0, servo9 = 0, servo10 = 0;
    static public int baseangle;
    bool flagNN = false, flagMM = false;
    int num00 = 0, num01 = 0;

    // Use this for initialization
    void Start () {
        var tex = ShadowCamera.targetTexture;
        targetTexture = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);
        GameObject ob = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ob.layer = 1;
        ob.transform.localScale = new Vector3(50, 60, 1);
        ob.transform.localPosition = new Vector3(0, 0, 33);
    }

    // Update is called once per frame
    void Update () {
        if (Time.time > 2.0f)
        {
            if (isCalled == false)
            {
                isCalled = true;
                NextStage();
            }
        }
    }
    public void NextStage()
    {
        var tex = ShadowCamera.targetTexture;
        RenderTexture.active = ShadowCamera.targetTexture;
        targetTexture.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        targetTexture.Apply();
        //Color[] inputColors = targetTexture.GetPixels();
        //Color[] outputColors = new Color[tex.width * tex.height];
        //for (int y = 0; y < tex.height; y++)
        for (int y = 55; y < tex.height; y++)
        {
            count02++;
            for (int x = 0; x < tex.width; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                if (color.r <= 0.8f && color.g <= 0.8f && color.b <= 0.8f)
                {
                    count++;
                }
            }
        }

        Debug.Log("nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn" + count);
        //Debug.Log("yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy" + count02++);
        for (int y = 186; y < tex.height; y++)
        {
            for (int x = 0; x < tex.width; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                if (color.r <= 0.8f && color.g <= 0.8f && color.b <= 0.8f)
                {
                    count03++;
                }
            }
        }
        Debug.Log("wwwwwwwwwwwwwwwwwwwwwwwww" + count03);

        for (int y = 60; y <= 193; y++)
        {
            for (int x = 0; x <= 256; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                if (color.r <= 0.8f && color.g <= 0.8f && color.b <= 0.8f)
                {
                    //xxx = x;
                    getDegree(x, y);
                    break;
                }
            }
        }
            
        destroyob = true;
        if (destroyob)
        {
            Destroy(GameObject.Find("SPlight"));
            Destroy(GameObject.Find("Cube"));
        }
    }
    public void getDegree(int xx, int yy)
    {
        //flagNN = false;
        //flagMM = false;

        if (xxx < xx)
        {
            xxx = xx;
            //xMax = xxx;
            countup++;
            Debug.Log(xxx);
            if (countup == 4 || countup == 8 || countup == 12|| countup == 16 || countup == 20 || countup == 24 || countup == 28)
            {
                flagNN = true;
            }
        }
        if (flagNN)
        {
            xMin = xxx;
            degreelight();
            Debug.Log("Hi");
            flagNN = false;
        }
        /*if (xMax> xx)
        {
            Debug.Log("(" + xx + "," + yy + ")");
        }*/
        //xMin = xxx;
        if (xMin > xx)
        {
            xMin = xx;
            countdown++;
            Debug.Log(xMin);
            if (countdown == 4 || countdown == 8 || countdown == 12 || countdown == 16 || countdown == 20 || countdown == 24 || countdown == 28 || countdown == 32|| countdown==36||countdown ==40||countdown == 44)
            {
                flagMM = true;
            }
        }
        if (flagMM)
        {
            degreeleft();
            Debug.Log("Hireverse");
            flagMM = false;
        }

        Debug.Log("("+xx+","+yy+")");
        /*if (126 <= xx && xx <=130)
        {
            baseangle = 90;
        }*/
    }
    public void degreelight()
    {
        num00++;
        if (num00 == 1)
        {
            servo3 = -30;
            servo4 = -30;
            servo5 = -30;
            servo6 = -30;
            servo7 = -30;
            servo8 = -30;
            servo9 = -30;
            servo10 = -30;
        }
        if (num00 == 2) { }


    }

    public void degreeleft()
    {
        num01++;
        if (num01 == 1)
        { 
            servo3 = 30;
            servo4 = 30;
            servo5 = 30;
            servo6 = 30;
            servo7 = 30;
            servo8 = 30;
            servo9 = 30;
            servo10 = 30;  
         }
        if (num01 == 2) {
            servo3 = 30;
            servo4 = 30;
            servo5 = -40;
            servo6 = -10;
            servo7 = -30;
            servo8 = -20;
            servo9 = 0;
            servo10 = 5;
        }
    }
}
