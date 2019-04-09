using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalAlgolizme : MonoBehaviour
{
    //GameObject Overlap;

    public Transform BaseA;
    public Transform BaseB;
    public Transform BaseC;
    public Transform BaseD;
    public GameObject ServoA2;
    public GameObject ServoA3;
    public GameObject ServoA4;
    public GameObject ServoA5;
    public GameObject ServoA6;
    public GameObject ServoA7;
    public GameObject ServoA8;
    public GameObject ServoA9;
    public GameObject ServoA10;
    public GameObject ServoB2;
    public GameObject ServoB3;
    public GameObject ServoB4;
    public GameObject ServoB5;
    public GameObject ServoB6;
    public GameObject ServoB7;
    public GameObject ServoB8;
    public GameObject ServoB9;
    public GameObject ServoB10;
    public GameObject ServoC2;
    public GameObject ServoC3;
    public GameObject ServoC4;
    public GameObject ServoC5;
    public GameObject ServoC6;
    public GameObject ServoC7;
    public GameObject ServoC8;
    public GameObject ServoC9;
    public GameObject ServoC10;
    public GameObject ServoD2;
    public GameObject ServoD3;
    public GameObject ServoD4;
    public GameObject ServoD5;
    public GameObject ServoD6;
    public GameObject ServoD7;
    public GameObject ServoD8;
    public GameObject ServoD9;
    public GameObject ServoD10;

    Quaternion baseAngle, purposeAngle, tempAngle;
    float speed = 360f;
    public static float t;
    int randomDegree, randomDegree01;
    int servo3deg;
    // Use this for initializaon
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Start");
            StartCoroutine("konezu01");
        }
    }
    public IEnumerator konezu01()
    {
        //Debug.Log("haiiteru?"+randomDegree01);
        //randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree;
        //Debug.Log(randomDegree01);

        baseAngle = Quaternion.Euler(0f, 0f, 0f);
        //BaseA
        randomDegree = Random.Range(0, 359);
        tempAngle.eulerAngles = new Vector3(0, 0, randomDegree);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        t += speed * Time.deltaTime;
        BaseA.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //BaseB
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree;
        tempAngle.eulerAngles = new Vector3(0, 0, randomDegree01);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        t += speed * Time.deltaTime;
        BaseB.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //BaseC
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree01;
        tempAngle.eulerAngles = new Vector3(0, 0, randomDegree01);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        t += speed * Time.deltaTime;
        BaseC.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //BaseD
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree02;
        tempAngle.eulerAngles = new Vector3(0, 0, randomDegree01);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        t += speed * Time.deltaTime;
        BaseD.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);

        yield return new WaitForSeconds(1.0f);

        //randomDegree = Random.Range(0, 359);
        //ServoA2
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f,90f,0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoA2.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoB2
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f,90f, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoB2.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoC2
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f,90f, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoC2.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoD2
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f,90f, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoD2.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);

        yield return new WaitForSeconds(1.0f);
        //ServoA3
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree101;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoA3.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoB3
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree101;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoB3.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoC3
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree102;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoC3.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoD3
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree103;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoD3.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);

        yield return new WaitForSeconds(1.0f);

        //ServoA4
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree101;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoA4.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoB4
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree101;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoB4.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoC4
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree102;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoC4.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoD4
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree103;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoD4.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        yield return new WaitForSeconds(1.0f);

        //ServoA5
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree201;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoA5.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoB5
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree201;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoB5.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoC5
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree202;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoC5.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoD5
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree203;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoD5.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        yield return new WaitForSeconds(1.0f);

        //ServoA6
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree201;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoA6.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoB6
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree201;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoB6.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoC6
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree202;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoC6.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoD6
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree203;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoD6.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        yield return new WaitForSeconds(1.0f);

        //ServoA7
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree301;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoA7.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoB7
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree301;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoB7.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoC7
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree302;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoC7.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoD7
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree303;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoD7.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        yield return new WaitForSeconds(1.0f);

        //ServoA8
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree301;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoA8.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoB8
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree301;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoB8.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoC8
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree302;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoC8.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoD8
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree303;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoD8.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        yield return new WaitForSeconds(1.0f);

        //ServoA9
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree401;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoA9.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoB9
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree401;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoB9.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoC9
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree402;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoC9.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoD9
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree403;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoD9.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        yield return new WaitForSeconds(1.0f);

        //ServoA10
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree501;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoA10.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoB10
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree501;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoB10.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoC10
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree502;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoC10.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        //ServoD10
        //Servo3degree();
        randomDegree01 = GameObject.Find("overlap").GetComponent<GetPic01>().degree503;
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        tempAngle.eulerAngles = new Vector3(-90f, randomDegree01, 0f);
        purposeAngle = Quaternion.Euler(tempAngle.eulerAngles);
        ServoD10.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t / 10);
        yield return new WaitForSeconds(1.0f);
        //GameObject.Find("overlap").GetComponent<GetPic01>().overlap();
    }

    private int Servo3degree()
    {
        servo3deg = Random.Range(-90, 90);
        return servo3deg;
    }
}
