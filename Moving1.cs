using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving1 : MonoBehaviour {
    public static float t;
    private bool isCalled = false;
    float speed = 360f;
    Quaternion baseAngle, purposeAngle, pop;
    int Degree;
    private int count = 0;
    private int oppi =  0;
	// Use this for initialization
	void Start () {
		
	}
    /*void Update()
    {
        if (Time.time > 1.0f)
        {
            if (isCalled == false)
            {
                isCalled = true;
                StartCoroutine("MovingArm");
            }
        }
    }*/
    public IEnumerator MovingArm()
    {
        int a = GameObject.Find("GenericAlgorithms").GetComponent<GenericAlgorithms05>().ArmNumber;
        int ArmNumberInMoving = 5 - a;
        //base
        GameObject ServoMotor = GameObject.Find("Base_Arm" + a);
        baseAngle = Quaternion.Euler(0f,0f,0f);
        pop.eulerAngles = new Vector3(0,0,270);
        purposeAngle = Quaternion.Euler(pop.eulerAngles);
        t += speed * Time.deltaTime;
        ServoMotor.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t);
        
        yield return new WaitForSeconds(0.1f);
        //servo2
        GameObject Servo2 = GameObject.Find("Motor" + ArmNumberInMoving + "-2");
        baseAngle = Quaternion.Euler(-90f, 0f, 0f);
        pop.eulerAngles = new Vector3(-90, 90, 0);
        purposeAngle = Quaternion.Euler(pop.eulerAngles);
        t += speed * Time.deltaTime;
        Servo2.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t);
        yield return new WaitForSeconds(0.1f);
        //servo3～servo10
        for (int i = 3;i<=10;i++)
        {
            Degree = GameObject.Find("GenericAlgorithms").GetComponent<GenericAlgorithms05>().currentPopulation[count][i-3];
            //Debug.Log(Degree+"角度********************");
            GameObject Servo = GameObject.Find("Motor" + ArmNumberInMoving + "-" + i);
            baseAngle = Quaternion.Euler(-90f,0f,0f);
            pop.eulerAngles = new Vector3(-90, Degree, 0);
            purposeAngle = Quaternion.Euler(pop.eulerAngles);
            t += speed * Time.deltaTime;
            Servo.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t);
            yield return new WaitForSeconds(0.01f);
        }
        count++;
        if (count == 20)
        {
            count = 0;
        }
    }
    public IEnumerator MovingArm2()
    {
        //int oppi;
        int b = GameObject.Find("GenericAlgorithms").GetComponent<GenericAlgorithms05>().ArmNumber;
        int ArmNumberInMoving = 5 - b;
        //servo3～servo10
        for (int i = 3; i <= 10; i++)
        {
            //Debug.Log(GameObject.Find("GenericAlgorithms").GetComponent<GenericAlgorithms05>().currentPopulation[oppi][i-3]);
            Degree = GameObject.Find("GenericAlgorithms").GetComponent<GenericAlgorithms05>().SubPopulation[oppi][i - 3];
            //Debug.Log("角度********************");
            GameObject Servo = GameObject.Find("Motor" + ArmNumberInMoving + "-" + i);
            baseAngle = Quaternion.Euler(-90f, 0f, 0f);
            pop.eulerAngles = new Vector3(-90, Degree, 0);
            purposeAngle = Quaternion.Euler(pop.eulerAngles);
            t += speed * Time.deltaTime;
            Servo.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t);
            yield return new WaitForSeconds(0.01f);
        }
        oppi++;
        if (oppi == 18)
        {
            oppi = 0;
        }
    }
    public IEnumerator MovingArm3()
    {
        int c = GameObject.Find("GenericAlgorithms").GetComponent<GenericAlgorithms05>().ArmNumber;
        int ArmNumberInMoving = 5 - c;

        for (int i = 3; i <= 10; i++)
        {
            //Debug.Log(GameObject.Find("GenericAlgorithms").GetComponent<GenericAlgorithms05>().currentPopulation[oppi][i-3]);
            Degree = GameObject.Find("GenericAlgorithms").GetComponent<GenericAlgorithms05>().Test[0][i - 3];
            //Debug.Log("角度********************");
            GameObject Servo = GameObject.Find("Motor" + ArmNumberInMoving + "-" + i);
            baseAngle = Quaternion.Euler(-90f, 0f, 0f);
            pop.eulerAngles = new Vector3(-90, Degree, 0);
            purposeAngle = Quaternion.Euler(pop.eulerAngles);
            t += speed * Time.deltaTime;
            Servo.transform.localRotation = Quaternion.Lerp(baseAngle, purposeAngle, t);
            yield return new WaitForSeconds(0.01f);
        }
    }

}
