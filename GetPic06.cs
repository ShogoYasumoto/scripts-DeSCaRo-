using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPic06 : MonoBehaviour {
    public Camera ShadowCamera;
    private Texture2D targetTexture;
    private bool isCalled = false;
    public  int[] Array01 = new int[51712];
    public int count;
    private bool destroyob = false;
    private bool destroywall = false;
    private int FlagChild = 0;

    // Use this for initialization
    void Start () {
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
                evaluate();
            }
        }
    }

    public void evaluate()
    {
        FlagChild = GameObject.Find("GenericAlgorithms").GetComponent<GenericAlgorithms04>().Flag;
        /*if (FlagChild != 0)
        {
            GameObject LightGameObject = new GameObject("SPLight");
            Light lightCoomp = LightGameObject.AddComponent<Light>();
            LightGameObject.transform.position = new Vector3(1,0,10);
            LightGameObject.transform.Rotate(new Vector3(180,0,0));
            GameObject ob = GameObject.CreatePrimitive(PrimitiveType.Cube);
            ob.layer = 1;
            ob.transform.localScale = new Vector3(50, 60, 1);
            ob.transform.localPosition = new Vector3(0, 0, 33); 
        }*/
        var tex = ShadowCamera.targetTexture;
        targetTexture = new Texture2D(tex.width,tex.height,TextureFormat.ARGB32,false);
        RenderTexture.active = ShadowCamera.targetTexture;
        targetTexture.ReadPixels(new Rect(0,0,tex.width,tex.height),0,0);
        targetTexture.Apply();
        int test01 = 0;
        for (int i = 0;i< 51712;i++)
        {
            var color = targetTexture.GetPixel((i + 13825) % tex.width, (i + 13825) / tex.height);
            Array01[i] = 0;
            if (color.r <= 0.8 && color.g <= 0.8 && color.b <= 0.8)
            {
                Array01[i] = -1;
                test01++;
            }
        }
        Debug.Log(test01+"*********************");
        destroyob = true;
        if (destroyob)
        {
            Debug.Log("************D*D*D***************");
            Destroy(GameObject.Find("SPlight"));
            Destroy(GameObject.Find("Cube"));
            destroyob = false;
        }
    }

    public void evaluate02()
    {
        //壁の作成
        /*GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall.layer = 1;
        wall.transform.localScale = new Vector3(37, 23, 1);
        wall.transform.localPosition = new Vector3(1, 14, 0);*/

        var tex = ShadowCamera.targetTexture;
        targetTexture = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);
        RenderTexture.active = ShadowCamera.targetTexture;
        targetTexture.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        targetTexture.Apply();

        int[] first = new int[51712];
        first = Array01;
        int[] Array02 = new int[51712];

        int test02 = 0;
        count = 0;
        for (int i = 0; i < 51712; i++)
        {
            var color = targetTexture.GetPixel((i + 13825) % tex.width, (i + 13825) / tex.height);
            if (color.r <= 0.8 && color.g <= 0.8 && color.b <= 0.8)
            {
                Array02[i] = -1;
                test02++;
            }
        }
        //Debug.Log(test02+"++++++++++++++++++++++++++++++++++");
        //適合度
        for (int i = 0; i < 51712; i++)
        {
            if (first[i] == -1 && Array02[i] == -1)
            {
                count++;
            }
        }
        //Debug.Log("************"+count +"************");
        /*destroywall = true;
        if (destroywall)
        {
            Destroy(GameObject.Find("Cube"));
        }*/
    }
}
