using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GenericAlgorithms04 : MonoBehaviour {
    System.Random Rnd = new System.Random();
    private const int GeneLength = 9;
    private const int kotainumber = 20;
    private int Age;
    private const double MutateRate = 0.05;
    private bool isCalled = false;
    private int number;
    private int EvaluatePoint;
    private int EvaluatePointNext;
    private bool yyy = false;
    public int AAA = 0;
    public int Flag = 0;
    //何番目のアームか
    [HideInInspector]
    public int ArmNumber = 4;
    [HideInInspector]
    public int rankNumber = 0;
    [HideInInspector]
    public int blackNumber = 0;
    [HideInInspector]
    public int Sceacence = 0;
    [HideInInspector]
    public List<int[]> currentPopulation;
    [HideInInspector]
    public List<int[]> currentPopulationSorted;
    [HideInInspector]
    public List<int[]> NextPopulation;
    [HideInInspector]
    public const int swhich = 1;
    [HideInInspector]
    public List<int[]> SubNextPopulation;
    [HideInInspector]
    public List<int[]> SubCurrentPopulation;
    public List<int[]> ellite;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 4.0f)
        {
            if (isCalled == false)
            {
                isCalled = true;
                StartCoroutine("State");
            }
        }
    }

    public IEnumerator State()
    {
        for (int m = 0; m < 4;m++)
        {
            Age = 1;
            currentPopulation = CreateInitialData();
            while (true)
            {
                Debug.Log("++++++++++++++++++" + Age + "世代++++++++++++++++++");
                //壁の作成///////////
                GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall.layer = 1;
                wall.transform.localScale = new Vector3(37, 23, 1);
                wall.transform.localPosition = new Vector3(1, 14, 0);
                /////////////////////
                Moving1 moving = new Moving1();
                //適応度の計算
                for (int i = 0; i < 20; i++)
                {
                    Debug.Log("******************" + i + "個体******************");
                    yield return StartCoroutine(moving.MovingArm());
                    GameObject.Find("overlap").GetComponent<GetPic06>().evaluate02();
                    EvaluatePoint = GameObject.Find("overlap").GetComponent<GetPic06>().count;
                    currentPopulation[i][8] = EvaluatePoint;
                    Debug.Log(EvaluatePoint + "第" + i + "個体の評価");
                }
                //適合率順にソート
                SortCurrentPopulation(currentPopulation);
                //エリート選択
                //NextPopulation.Add(currentPopulationSorted[0]);
                //次世代の個体を交叉と突然変異を用いて生成
                //int[] ellite = new int[GeneLength+1];
                List<int[]> ellite = new List<int[]>();
                ellite.Add(currentPopulationSorted[0]);
                Debug.Log(ellite[0][8]);
                currentPopulation.Add(ellite[0]);

                List<int[]> NextPopulation = new List<int[]>();
                for (int i = 0; i < kotainumber - 1; i++)
                {
                    if (Rnd.Next(0, 100) / 100 < 0.75)
                    {
                        if (i != kotainumber - 1)
                        {
                            //NextPopulation.Add(CrossOver(currentPopulationSorted[i], currentPopulationSorted[i + 1])[0]);
                            //temp = CrossOver(currentPopulationSorted[0], currentPopulationSorted[1]);
                            NextPopulation.Add(CrossOver(currentPopulationSorted[i], currentPopulationSorted[i+1])[0]);

                        }
                        else
                        {
                            //NextPopulation.Add(CrossOver(currentPopulationSorted[i], currentPopulationSorted[0])[0]);
                            //temp = CrossOver(currentPopulationSorted[i], currentPopulationSorted[i])[0];
                            NextPopulation.Add(CrossOver(currentPopulationSorted[i], currentPopulationSorted[0])[0]);
                        }
                    }
                    else
                    {
                        NextPopulation.Add(MutaRate(currentPopulationSorted[i])[0]);
                    }
                }
                SubNextPopulation = NextPopulation;
                /*List<int[]> SubCurrentPopulation = new List<int[]>();
                for (int i=0; i<kotainumber;i++)
                {
                    int[] mmm = new int[GeneLength+1]; 
                    for (int j=0;j<=GeneLength;j++)
                    {
                        mmm[j] = 0;
                    }
                    SubCurrentPopulation.Add(mmm);
                }
                for (int i=0;i<18;i++)
                { 
                    SubCurrentPopulation[i] = currentPopulationSorted[i];
                 }
                for (int i = 0; i < 5; i++)
                {
                    Debug.Log(SubCurrentPopulation[i][8] + "いいいいいいいいいいいいいいいいいい");
                }*/
                for (int i = 0; i < 5; i++)
                {
                    //Debug.Log(NextPopulation[i][8] + "いいいいいいいいsadfasいいいいいいいいいい");
                    Debug.Log(currentPopulation[i][8] + "えええええええええええええええええええ");
                }
                //次世代の適応度の計算
                //List<int> pointpoint = new List<int>();
                for (int i = 0; i < 19; i++)
                {
                    Debug.Log("次世代の適応度計算******************" + i + "個体******************");
                    yield return StartCoroutine(moving.MovingArm2());
                    GameObject.Find("overlap").GetComponent<GetPic06>().evaluate02();
                    EvaluatePointNext = GameObject.Find("overlap").GetComponent<GetPic06>().count;
                    //pointpoint.Add(EvaluatePointNext);
                    NextPopulation[i][8]= EvaluatePointNext;
                    Debug.Log(EvaluatePointNext + "第" + i + "世代の評価");
                }
                //NextPopulationとcurrentPopulationSortedの合体をソートするcoun                
                for (int i = 0; i < kotainumber - 1; i++)
                {
                    currentPopulationSorted.Add(NextPopulation[i]);
                }
                //SortLv2(currentPopulationSorted);
                Select(SortLv2(currentPopulationSorted));

                //壁の破壊//////
                yyy = true;
                if (yyy)
                {
                    Destroy(GameObject.Find("Cube"));
                }
                yyy = false;
                ////////////////

                //終了条件
                if (Age == 30)
                {
                    //20世代後に終了
                    break;
                }
                //ArmNumber--;
                Age++;
            }
            //ArmNumber--;
            //SwichCannel();
        }
        //return null;
    }

    private void SwichCannel()
    {
        //rayerの切り替え　
        if (ArmNumber == 3)
        {
            Flag = 1;
            GameObject.Find("Base_Arm3").layer = 0;
            GameObject.Find("overlap").GetComponent<GetPic06>().evaluate();
        }
        if (ArmNumber == 2)
        {
            Flag = 2;
            GameObject.Find("Base_Arm2").layer = 0;
            GameObject.Find("overlap").GetComponent<GetPic06>().evaluate();
        }
        if (ArmNumber == 1)
        {
            Flag = 3;
            GameObject.Find("Base_Arm1").layer = 0;
            GameObject.Find("overlap").GetComponent<GetPic06>().evaluate();
        }

    }

    private List<int[]> CreateInitialData()
    {
        List<int[]> ListArray = new List<int[]>();
        for (int i = 0; i < kotainumber; i++)
        {
            int[] Array = new int[GeneLength + 1];
            for (int j = 0; j <= GeneLength; j++)
            {
                Array[j] = Rnd.Next(-90, 90);
            }
            ListArray.Add(Array);
        }
        return ListArray;
    }
    private List<int[]> SortCurrentPopulation(List<int[]> currentPopulation)
    {
        int[] rank = new int[kotainumber];
        for (int i = 0; i < kotainumber; i++)
        {
            rank[i] = 0;
        }

        for (int i = 0; i < kotainumber; i++)
        {
            for (int j = 0; j < kotainumber; j++)
            {
                if (currentPopulation[i][8] < currentPopulation[j][8])
                {
                    rank[i]++;
                }
            }
        }
        List<int[]> aftersort = new List<int[]>();
        for (int i = 0; i < kotainumber; i++)
        {
            for (int j = 0; j < kotainumber; j++)
            {
                if (rank[j] == i)
                {
                    aftersort.Add(currentPopulation[j]);
                }
            }
        }
        
        currentPopulationSorted = aftersort;

        /*for (int i = 0; i < 5; i++)
        {
            Debug.Log(currentPopulationSorted[i][8] + "ああああああああああああああああああああああああああ");
        }*/
        return currentPopulationSorted;
    }

    private List<int[]> CrossOver(int[] GeneA, int[] GeneB)
    {
        int one = Rnd.Next(0, 7);
        int two = Rnd.Next(0, 7);
        int[] tempA = new int[8];
        int[] tempB = new int[8];


        while (one == two)
        {
            one = Rnd.Next(0, 7);
            two = Rnd.Next(0, 7);
            if (one != two)
            {
                break;
            }
        }
        if (one < two)
        {
            for (int i = one; i < two; i++)
            {
                tempB[i] = GeneB[i];
                tempA[i] = GeneA[i];
                GeneB[i] = tempA[i];
                GeneA[i] = tempB[i];
            }
        }
        if (two < one)
        {
            for (int i = two; i < one; i++)
            {
                tempB[i] = GeneB[i];
                tempA[i] = GeneA[i];
                GeneB[i] = tempA[i];
                GeneA[i] = tempB[i];
            }
        }

        List<int[]> AfterCrossOver = new List<int[]>();
        AfterCrossOver.Add(GeneA);
        AfterCrossOver.Add(GeneB);
        /*for (int i = 0; i < 8; i++)
        {
            Debug.Log("+++++++++++++++++++++++++++++++++++++++++" + AfterCrossOver[0][i]);
        }*/
        return AfterCrossOver;
    }
    private List<int[]> MutaRate(int[] GeneParent)
    {
        int MutateCount = Rnd.Next(0, 7);
        for (int i = 0; i < MutateCount; i++)
        {
            int RandomNumber = Rnd.Next(0, 7);
            GeneParent[RandomNumber] = GeneParent[RandomNumber] * -1;
        }
        List<int[]> AfterMutate = new List<int[]>();
        AfterMutate.Add(GeneParent);
        return AfterMutate;
    }
    private List<int[]> SortLv2(List<int[]> currentPopoulationSortedLv2)
    {
        int[] ranking = new int[kotainumber * 2 - 1];
        for (int i = 0; i < kotainumber * 2 - 1; i++)
        {
            ranking[i] = 0;
        }
        for (int i = 0; i < kotainumber * 2 - 1; i++)
        {
            for (int j = 0; j < kotainumber * 2 - 1; j++)
            {
                if (currentPopoulationSortedLv2[i][8] < currentPopoulationSortedLv2[j][8])
                {
                    ranking[i]++;
                }
            }
        }
        List<int[]> aftersortLv2 = new List<int[]>();
        for (int i = 0; i < kotainumber * 2 - 1; i++)
        {
            for (int j = 0; j < kotainumber * 2 - 1; j++)
            {
                if (ranking[j] == i)
                {
                    aftersortLv2.Add(currentPopoulationSortedLv2[j]);
                }
            }
        }
        /*for (int i = 0; i < 5; i++)
        {
            Debug.Log(aftersortLv2[i][8] + "AAAAAAAAAAAAAAAAAAAAAAAAA");
        }*/
        return aftersortLv2;
    }
    private List<int[]> Select(List<int[]> SortLv2)//39個の個体から19個の個体をルーレット方式でセレクト
    {
        int[] evaluateArray = new int[39];
        for (int i = 0; i < 38; i++)
        {
            evaluateArray[i] = SortLv2[i][8];
        }

        ///////////////////////

        ///////////////////////
        List<int[]> TempArray = new List<int[]>();
        for (int j = 0; j < 19; j++)
        {

            TempArray.Add(SortLv2[rouletteChoice(evaluateArray)]);
            //TempArray.Add(SortLv2[j]);
            //currentPopulation[j + 1] = TempArray[j];
            //TempArray.Add(currentPopulation[j]);
        }
        for (int i=0;i<19;i++)
        {
            currentPopulation[i + 1] = TempArray[i];
        }
        Debug.Log(currentPopulation[0][8]+"AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        //Debug.Log("Yeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeei");
        /*for (int i=1;i<18;i++)
        {
            currentPopulation[i] = TempArray[i-1];
        }*/
        //1位個体の挿入
        //List<int[]> ellite = new List<int[]>();
        //currentPopulation[0] = ellite[0];
        return currentPopulation;
    }
    private int rouletteChoice(int[] rate)//ルーレット選択
    {
        int max = 0;
        int temp = 0;
        for (int i = 0; i < rate.Length; i++)
        {
            max += rate[i];
            AAA++;
            //Debug.Log(rate[i]);
        }
        //Debug.Log(AAA+"++++++++++++++++++++++++++");
        temp = Rnd.Next(0, max);
        for (int i = 0; i < rate.Length; i++)
        {
            temp -= rate[i];
            if (temp < 0)
            {
                //Debug.Log("+++++++++++++++++++++結果"+ i + "ルーレット+++++++++++++++++++++++++++");
                return i;
            }
        }
        Debug.Log("error");
        return -1;
    }

    private void finishtatme(List<int[]> CurrentClew)
    {
        Debug.Log("Hello");
        
    }
}
