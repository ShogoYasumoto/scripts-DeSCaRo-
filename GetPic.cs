using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPic : MonoBehaviour {

    //[SerializeField]
    //public new RenderTexture renderer;

    public static float answer = 0;
    public static int black = 0;
    public static int white = 0;

    //Texture2D texture;

   /* public Color[] GetPixels()
    {
        //RenderTexture _target; 
       /* RenderTexture renderer;
        var currentRT = RenderTexture.active;
        RenderTexture.active = renderer;
        float H, S, V;

        Debug.Log(renderer);
        var texture = new Texture2D(renderer.width,renderer.height);
        texture.ReadPixels(new Rect(0, 0, renderer.width, renderer.height), 0, 0);
        texture.Apply();
        Color[] pixels = texture.GetPixels();
        Color[] Cpixels = new Color[pixels.Length];

        for (int i = 0; i < pixels.Length; i++)
        {
            Color pixel = pixels[i];
            Color.RGBToHSV(new Color(pixel.r, pixel.g, pixel.b, pixel.a), out H, out S, out V);
            if (H >= 0.8f && H <= 1.0f && V >= 0.1f && V <= 0.7f)
            {
                black++;
            }
            else if (S <= 0.1f && V >= 0.6f)
            {
                white++;
            }
        }
        answerer(black, white);
        var colors = texture.GetPixels();
        RenderTexture.active = currentRT;
        return colors;
    }*/

    public static void  answerer(int bla,int whi)
    {
        answer = bla / (bla + whi);
        Debug.Log(answer);
    }
}
