using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPic01 : MonoBehaviour {
    //[SerializeField]
    public Camera ShadowCamera;
    private Texture2D targetTexture;
    bool isCalled = false;
    bool destroyob = false;

    public int degree=0,degree01=0,degree02=0;
    public int degree101 = 0, degree102 = 0, degree103 = 0, degree201 = 0, degree202 = 0, degree203 = 0, degree301 = 0, degree302 = 0, degree303 = 0, degree401 = 0, degree402 = 0, degree403 = 0, degree501 = 0, degree502 = 0, degree503 = 0;

    void Start()
    {
        var tex = ShadowCamera.targetTexture;
        targetTexture = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);
        GameObject ob = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ob.layer = 1;
        ob.transform.localScale = new Vector3(50,60,1);
        ob.transform.localPosition = new Vector3(0,0,33);
        
    }
    void Update()
    {
        if (Time.time > 2.0f)
        {
            if (isCalled == false)
            {
                isCalled = true;
                overlap();
            }
        }

    }

    public void overlap()
    {
        int countll = 0, countl = 0, countr = 0, countrr = 0;
        int count11 = 0, count12 = 0, count13 = 0, count14 = 0, count21 = 0, count22 = 0, count23 = 0, count24 = 0, count31 = 0, count32 = 0, count33 = 0, count34 = 0, count41 = 0, count42 = 0, count43 = 0, count44 = 0, count52 = 0, count53 = 0;
        float H, S, V;
        int tempMax=0;
        var tex = ShadowCamera.targetTexture;
        RenderTexture.active = ShadowCamera.targetTexture;
        targetTexture.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        targetTexture.Apply();
        for (int y = 192; y <= tex.height - 32; y++)
        {
            for (int x = 0; x <= tex.width-192; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //Debug.Log(color.ToString());
                //if (H >= 0.8f && H <= 1.0f && V >= 0.1f && V <= 0.7f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    //Debug.Log("error");
                    countll++;
                }
                
            }
            for (int x = 64; x <= tex.width-128; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //if(H >= 0.8f && H <= 1.0f && V >= 0.1f && V <= 0.7f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    countl++;
                }
            }
            for (int x = 128; x <= tex.width-64; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                /*targetTexture.SetPixel(x, y, Color.blue);
                targetTexture.Apply();*/
                //if(H >= 0.8f && H <= 1.0f && V >= 0.1f && V <= 0.7f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    countr++;
                }
            }
            for (int x = 192; x <= tex.width; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                if (H >= 0.8f && H <= 1.0f && V >= 0.1f && V <= 0.7f)
                //if (S >= 0.1 && V <= 0.633f)
                {
                    //Debug.Log("error");
                    countrr++;
                }
            }
        }
        //第一層
        for (int y = 160; y <= tex.height - 64; y++)
        {
            for (int x = 0; x <= tex.width - 192; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                //Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                if(color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                //if (H >= 0.1f && H <= 1.0f && V >= 0.1f && V <= 1.0f)
                {
                    count11++;
                }
            }
            for (int x = 64; x <= tex.width - 128; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                //Debug.Log(color.ToString());
                //Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //if (H >= 0.1f && H <= 1.0f && V >= 0.1f && V <= 1.0f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    count12++;
                }
            }
            for (int x = 128; x <= tex.width - 64; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                //Debug.Log(color.ToString());
                //Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //if (H >= 0.1f && H <= 1.0f && V >= 0.1f && V <= 1.0f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    count13++;
                }
            }
            for (int x = 192; x <= tex.width; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                //Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //if (H >= 0.1f && H <= 1.0f && V >= 0.1f && V <= 1.0f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    count14++;
                }
            }
        }
        //第二層
        for (int y = 128; y <= tex.height - 96; y++)
        {
            for (int x = 0; x <= tex.width - 192; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                //Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //if (H >= 0.1f && H <= 1.0f && V >= 0.1f && V <= 1.0f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    count21++;
                }
            }
            for (int x = 64; x <= tex.width - 128; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                //Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //if (H >= 0.1f && H <= 1.0f && V >= 0.1f && V <= 1.0f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    count22++;
                }
            }
            for (int x = 128; x <= tex.width - 64; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                //Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //if(H >= 0.1f && H <= 1.0f && V >= 0.1f && V <= 1.0f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    count23++;
                }
            }
            for (int x = 192; x <= tex.width; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                //Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //if (H >= 0.1f && H <= 1.0f && V >= 0.1f && V <= 1.0f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    count24++;
                }
            }
        }
        //第三層
        for (int y = 96; y <= tex.height - 128; y++)
        {
            for (int x = 0; x <= tex.width - 192; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                //Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //if (H >= 0.1f && H <= 1.0f && V >= 0.1f && V <= 1.0f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    count31++;
                }
            }
            for (int x = 64; x <= tex.width - 128; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                //Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //if (H >= 0.1f && H <= 1.0f && V >= 0.1f && V <= 1.0f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    count32++;
                }
            }
            for (int x = 128; x <= tex.width - 64; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                //Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //if (H >= 0.1f && H <= 1.0f && V >= 0.1f && V <= 1.0f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    count33++;
                }
            }
            for (int x = 192; x <= tex.width; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                //Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //if (H >= 0.1f && H <= 1.0f && V >= 0.1f && V <= 1.0f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    count34++;
                }
            }
        }
        //第四層
        for (int y = 64; y <= tex.height - 160; y++)
        {
            for (int x = 0; x <= tex.width - 192; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                //Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //if (H >= 0.1f && H <= 1.0f && V >= 0.1f && V <= 1.0f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    count41++;
                }
            }
            for (int x = 64; x <= tex.width - 128; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                //Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //if (H >= 0.1f && H <= 1.0f && V >= 0.1f && V <= 1.0f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    count42++;
                }
            }
            for (int x = 128; x <= tex.width - 64; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                //Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //if (H >= 0.1f && H <= 1.0f && V >= 0.1f && V <= 1.0f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    count43++;
                }
            }
            for (int x = 192; x <= tex.width; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                //Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //if (H >= 0.1f && H <= 1.0f && V >= 0.1f && V <= 1.0f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    count44++;
                }
            }
        }
        //第五層
        for (int y = 32; y <= tex.height - 192; y++)
        {
            for (int x = 64; x <= tex.width - 128; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                //Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //if (H >= 0.2f && H <= 1.0f && V >= 0.1f && V <= 1.0f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    count52++;
                }
            }
            for (int x = 128; x <= tex.width - 64; x++)
            {
                var color = targetTexture.GetPixel(x, y);
                //Color.RGBToHSV(new Color(color.r, color.g, color.b, color.a), out H, out S, out V);
                //if (H >= 0.2f && H <= 1.0f && V >= 0.1f && V <= 1.0f)
                if (color.r <= 0.5f && color.g <= 0.5f && color.b <= 0.5f)
                {
                    count53++;
                }
            }
        }

        //一番下の層
        tempMax = countll;
        if (countl > tempMax) { tempMax = countl; }
        if (countr > tempMax) { tempMax = countr; }
        if (countrr > tempMax) { tempMax = countrr; }
        //Debug.Log(tempMax);
        Debug.Log(countl + countr);
        Debug.Log(countl);
        Debug.Log(countr);
        getDegree(countl, countr);
        getDegree01(countl, countr);
        getDegree02(countl, countr);

        //160-192層
        /*tempMax = count11;
        if (count12 > tempMax) { tempMax = count12; }
        if (count13 > tempMax) { tempMax = count13; }
        if (count14 > tempMax) { tempMax = count14; }*/
        Debug.Log(count12 + count13);
        Debug.Log(count12);
        Debug.Log(count13);
        getDegree101(count12,count13);
        getDegree102(count12, count13);
        getDegree103(count12, count13);

        //128-160層
        /*tempMax = count21;
        if (count22 > tempMax) { tempMax = count22; }
        if (count23 > tempMax) { tempMax = count23; }
        if (count24 > tempMax) { tempMax = count24; }*/
        Debug.Log(count22 + count23);
        Debug.Log(count22);
        Debug.Log(count23);
        getDegree201(count22, count23);
        getDegree202(count22, count23);
        getDegree203(count22, count23);

        //96-128層
        /*tempMax = count31;
        if (count32 > tempMax) { tempMax = count32; }
        if (count33 > tempMax) { tempMax = count33; }
        if (count34 > tempMax) { tempMax = count34; }*/
        Debug.Log(count32 + count33);
        Debug.Log(count32);
        Debug.Log(count33);
        getDegree301(count32, count33);
        getDegree302(count32, count33);
        getDegree303(count32, count33);

        //64-96層
        /*tempMax = count41;
        if (count42 > tempMax) { tempMax = count42; }
        if (count43 > tempMax) { tempMax = count43; }
        if (count44 > tempMax) { tempMax = count44; }*/
        Debug.Log(count42+count43);
        Debug.Log(count42);
        Debug.Log(count43);
        getDegree401(count42, count43);
        getDegree402(count42, count43);
        getDegree403(count42, count43);

        //32-64層
        /*tempMax = count52;
        if (count53 > tempMax) { tempMax = count53; }*/
        getDegree501(count52, count53);
        getDegree502(count52, count53);
        getDegree503(count52, count53);

        destroyob = true;
        if (destroyob)
        {
            Destroy(GameObject.Find("SPlight"));
            Destroy(GameObject.Find("Cube"));
        }
        //Debug.Log("finnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn");
        //Debug.Log(degree);
        /*Debug.Log(countll);
        Debug.Log(countl);
        Debug.Log(countr);
        Debug.Log(countrr);*/
    }

    public int getDegree(int right, int left)
    {
        if (left > right)
        {
            degree = Random.Range(95, 135);
            Debug.Log("left");
        }
        else if (right > left)
        {
            degree = Random.Range(45, 85);
            Debug.Log("right");
        }
        return degree;
    }
    public int getDegree01(int right, int left)
    {
        if (left > right)
        {
            degree01 = Random.Range(95, 135);
            Debug.Log("left");
        }
        else if (right > left)
        {
            degree01 = Random.Range(45, 85);
            Debug.Log("right");
        }
        return degree01;
    }
    public int getDegree02(int right, int left)
    {
        if (left > right)
        {
            degree02 = Random.Range(95, 135);
            Debug.Log("left");
        }
        else if (right > left)
        {
            degree02 = Random.Range(45, 85);
            Debug.Log("right");
        }
        return degree02;
    }
    //160-192層
    public int getDegree101(int right, int left)
    {
        if (left > right)
        {
            degree101 = Random.Range(0,30);
            Debug.Log("left");
        }
        else if (right > left)
        {
            degree101 = Random.Range(-30,0);
            Debug.Log("right");
        }
        return degree101;
    }
    public int getDegree102(int right, int left)
    {
        if (left > right)
        {
            degree102 = Random.Range(0, 30);
            Debug.Log("left");
        }
        else if (right > left)
        {
            degree102 = Random.Range(-30, 0);
            Debug.Log("right");
        }
        return degree102;
    }
    public int getDegree103(int right, int left)
    {
        if (left > right)
        {
            degree103 = Random.Range(0, 30);
            Debug.Log("left");
        }
        else if (right > left)
        {
            degree103 = Random.Range(-30, 0);
            Debug.Log("right");
        }
        return degree103;
    }
    //128-160層
    public int getDegree201(int right, int left)
    {
        if (left > right)
        {
            degree201 = Random.Range(0, 45);
            Debug.Log("left");
        }
        else if (right > left)
        {
            degree201 = Random.Range(-45, 0);
            Debug.Log("right");
        }
        return degree201;
    }
    public int getDegree202(int right, int left)
    {
        if (left > right)
        {
            degree202 = Random.Range(0, 45);
            Debug.Log("left");
        }
        else if (right > left)
        {
            degree202 = Random.Range(-45, 0);
            Debug.Log("right");
        }
        return degree202;
    }
    public int getDegree203(int right, int left)
    {
        if (left > right)
        {
            degree203 = Random.Range(0, 45);
            Debug.Log("left");
        }
        else if (right > left)
        {
            degree203 = Random.Range(-45, 0);
            Debug.Log("right");
        }
        return degree203;
    }
    //96-128層
    public int getDegree301(int right, int left)
    {
        if (left > right)
        {
            degree301 = Random.Range(0, 30);
            Debug.Log("left");
        }
        else if (right > left)
        {
            degree301 = Random.Range(-30, 0);
            Debug.Log("right");
        }
        return degree301;
    }
    public int getDegree302(int right, int left)
    {
        if (left > right)
        {
            degree302 = Random.Range(0, 30);
            Debug.Log("left");
        }
        else if (right > left)
        {
            degree302 = Random.Range(-30, 0);
            Debug.Log("right");
        }
        return degree302;
    }
    public int getDegree303(int right, int left)
    {
        if (left > right)
        {
            degree303 = Random.Range(0, 30);
            Debug.Log("left");
        }
        else if (right > left)
        {
            degree303 = Random.Range(-30, 0);
            Debug.Log("right");
        }
        return degree303;
    }
    //64-96層
    public int getDegree401(int right, int left)
    {
        if (left > right)
        {
            degree401 = Random.Range(0, 45);
            Debug.Log("left");
        }
        else if (right > left)
        {
            degree401 = Random.Range(-45, 0);
            Debug.Log("right");
        }
        return degree401;
    }
    public int getDegree402(int right, int left)
    {
        if (left > right)
        {
            degree402 = Random.Range(0, 45);
            Debug.Log("left");
        }
        else if (right > left)
        {
            degree402 = Random.Range(-45, 0);
            Debug.Log("right");
        }
        return degree402;
    }
    public int getDegree403(int right, int left)
    {
        if (left > right)
        {
            degree403 = Random.Range(0, 45);
            Debug.Log("left");
        }
        else if (right > left)
        {
            degree403 = Random.Range(-45, 0);
            Debug.Log("right");
        }
        return degree403;
    }
    //32-64層
    public int getDegree501(int right, int left)
    {
        if (left > right)
        {
            degree501 = Random.Range(0, 30);
            Debug.Log("left");
        }
        else if (right > left)
        {
            degree501 = Random.Range(-30, 0);
            Debug.Log("right");
        }
        return degree501;
    }
    public int getDegree502(int right, int left)
    {
        if (left > right)
        {
            degree502 = Random.Range(0, 30);
            Debug.Log("left");
        }
        else if (right > left)
        {
            degree502 = Random.Range(-30, 0);
            Debug.Log("right");
        }
        return degree502;
    }
    public int getDegree503(int right, int left)
    {
        if (left > right)
        {
            degree503 = Random.Range(0, 30);
            Debug.Log("left");
        }
        else if (right > left)
        {
            degree503 = Random.Range(-30, 0);
            Debug.Log("right");
        }
        return degree503;
    }

}
