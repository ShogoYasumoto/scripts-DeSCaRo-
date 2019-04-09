using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class DeSCaRoAgent :Agent
{
    public Transform Base_1;
    public GameObject Servo2_1;
    public GameObject Servo3_1;
    public GameObject Servo4_1;
    public GameObject Servo5_1;
    public GameObject Servo6_1;
    public GameObject Servo7_1;
    public GameObject Servo8_1;
    public GameObject Servo9_1;
    public GameObject Servo10_1;
    public Transform Base_2;
    public GameObject Servo2_2;
    public GameObject Servo3_2;
    public GameObject Servo4_2;
    public GameObject Servo5_2;
    public GameObject Servo6_2;
    public GameObject Servo7_2;
    public GameObject Servo8_2;
    public GameObject Servo9_2;
    public GameObject Servo10_2;
    public Transform Base_3;
    public GameObject Servo2_3;
    public GameObject Servo3_3;
    public GameObject Servo4_3;
    public GameObject Servo5_3;
    public GameObject Servo6_3;
    public GameObject Servo7_3;
    public GameObject Servo8_3;
    public GameObject Servo9_3;
    public GameObject Servo10_3;
    public Transform Base_4;
    public GameObject Servo2_4;
    public GameObject Servo3_4;
    public GameObject Servo4_4;
    public GameObject Servo5_4;
    public GameObject Servo6_4;
    public GameObject Servo7_4;
    public GameObject Servo8_4;
    public GameObject Servo9_4;
    public GameObject Servo10_4;

    Quaternion BaseAngle, pp_BaseAngle;
    Quaternion ServoAngle, pp_ServoAngle;

    public RenderTexture rendertexture;

    float ranAngle;
    //初期化
    public override void InitializeAgent()
    {
        base.InitializeAgent();

    }
    //state情報をリストに保管
    public override void CollectObservations()
    {
        AddVectorObs(BaseAngle);
        AddVectorObs(ServoAngle);
        AddVectorObs(pp_BaseAngle);
        AddVectorObs(pp_ServoAngle);
    }
    //報酬獲得
    public void StateTransition()
    {
    }
    //報酬獲得までの行動
    public void MoveAgent(float[] act)
    {
        int action = Mathf.FloorToInt(act[0]);
        BaseAngle = Quaternion.Euler(0f, 0f, 0f);
        ServoAngle = Quaternion.Euler(-90f, 0f, 0f);

        /* Texture2D tex = new Texture2D(rendertexture.width, rendertexture.height, TextureFormat.RGB24, false);
        RenderTexture.active = rendertexture;
        tex.ReadPixels(new Rect(0, 0, rendertexture.width, rendertexture.height), 0, 0);
        tex.Apply();
        byte[] bytes = tex.EncodeToPNG();
        UnityEngine.Object.Destroy(tex);*/
        Texture2D mainTexture = (Texture2D)GameObject.Find("RawImage").GetComponent<Renderer>().material.mainTexture;
        Color[] pixels = mainTexture.GetPixels();
        Color[] change_pixels = new Color[pixels.Length];


        //pp_BaseAngle = Quaternion.Euler();
        //pp_ServoAngle = Quaternion.Euler();

        if (action == 0)
        {
            //ranAngle = Random.Range
           /* Base_1.localRotation = Quaternion.Euler();
            Base_2.localRotation = Quaternion.Euler();
            Base_3.localRotation = Quaternion.Euler();
            Base_4.localRotation = Quaternion.Euler();*/
        }
        if (action == 1)
        {
            
        }
        if (action == 2) { }
        if (action == 3) { }
        if (action == 4) { }
    }
    //行動から報酬獲得までのシーケンス
    public override void AgentAction(float[] vectorAction, string textAction)
    {
        MoveAgent(vectorAction);

        StateTransition();

    }
    //初期状態に戻す
    public override void AgentReset()
    {
        BaseAngle = Quaternion.Euler(0f, 0f, 0f);
        ServoAngle = Quaternion.Euler(-90f, 0f, 0f);
        Base_1.localRotation = BaseAngle;
        Base_2.localRotation = BaseAngle;
        Base_3.localRotation = BaseAngle;
        Base_4.localRotation = BaseAngle;

        Servo2_1.transform.localRotation = ServoAngle;
        Servo3_1.transform.localRotation = ServoAngle;
        Servo4_1.transform.localRotation = ServoAngle;
        Servo5_1.transform.localRotation = ServoAngle;
        Servo6_1.transform.localRotation = ServoAngle;
        Servo7_1.transform.localRotation = ServoAngle;
        Servo8_1.transform.localRotation = ServoAngle;
        Servo9_1.transform.localRotation = ServoAngle;
        Servo10_1.transform.localRotation = ServoAngle;

        Servo2_2.transform.localRotation = ServoAngle;
        Servo3_2.transform.localRotation = ServoAngle;
        Servo4_2.transform.localRotation = ServoAngle;
        Servo5_2.transform.localRotation = ServoAngle;
        Servo6_2.transform.localRotation = ServoAngle;
        Servo7_2.transform.localRotation = ServoAngle;
        Servo8_2.transform.localRotation = ServoAngle;
        Servo9_2.transform.localRotation = ServoAngle;
        Servo10_2.transform.localRotation = ServoAngle;

        Servo2_3.transform.localRotation = ServoAngle;
        Servo3_3.transform.localRotation = ServoAngle;
        Servo4_3.transform.localRotation = ServoAngle;
        Servo5_3.transform.localRotation = ServoAngle;
        Servo6_3.transform.localRotation = ServoAngle;
        Servo7_3.transform.localRotation = ServoAngle;
        Servo8_3.transform.localRotation = ServoAngle;
        Servo9_3.transform.localRotation = ServoAngle;
        Servo10_3.transform.localRotation = ServoAngle;

        Servo2_4.transform.localRotation = ServoAngle;
        Servo3_4.transform.localRotation = ServoAngle;
        Servo4_4.transform.localRotation = ServoAngle;
        Servo5_4.transform.localRotation = ServoAngle;
        Servo6_4.transform.localRotation = ServoAngle;
        Servo7_4.transform.localRotation = ServoAngle;
        Servo8_4.transform.localRotation = ServoAngle;
        Servo9_4.transform.localRotation = ServoAngle;
        Servo10_4.transform.localRotation = ServoAngle;
    }
    public override void AgentOnDone()
    {

    }
    void OnCllisionEnter(Collision collision)
    {

    }
}