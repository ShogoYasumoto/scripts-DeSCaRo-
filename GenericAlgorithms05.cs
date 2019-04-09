using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class GenericAlgorithms05 : MonoBehaviour {
    System.Random Rnd = new System.Random();
    private bool isCalled = false;
    private int Age = 0;
    private int kotainumber = 20;
    private int GeneLength = 9;
    private int EvaluatePoint = 0;
    private int EvaluatePointNext = 0;
    public int ArmNumber = 3;
    private int AAA = 0;
    private int master = 0;
    private bool yyy = false;
    [HideInInspector]
    public List<int[]> currentPopulation;
    [HideInInspector]
    public List<int[]> currentPopulationSorted;
    //[HideInInspector]
    public List<int[]> NextPopulation;
    [HideInInspector]
    public List<int[]> SubPopulation;
    [HideInInspector]
    public List<int[]> GetBeautifull;
    [HideInInspector]
    public List<int[]> finish;
    [HideInInspector]
    public List<int[]> Test;
    public int[] Master;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Time.time > 4.0f)
        {
            if (isCalled == false)
            {
                isCalled = true;
                StartCoroutine("Amazon");
            }
        }
    }
    public IEnumerator Amazon()
    {
        //for (int M = 0; M < 4; M++)
        //{
            Age = 1;
            currentPopulation = CreateInitialData();
            /*for (int i = 0; i < 20; i++)
            {
                Debug.Log(i + "世代");
                for (int j = 0; j < 8; j++)
                {
                    Debug.Log(currentPopulation[i][j]);
                }
            }*/
            while (true)
            {
            Debug.Log(Age+"世代***************************************************************************");
                GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall.layer = 1;
                wall.transform.localScale = new Vector3(37, 23, 1);
                wall.transform.localPosition = new Vector3(1, 14, 0);
                Moving1 moving = new Moving1();
                for (int i = 0; i < kotainumber; i++)
                {
                    yield return StartCoroutine(moving.MovingArm());
                    GameObject.Find("overlap").GetComponent<GetPic06>().evaluate02();
                    EvaluatePoint = GameObject.Find("overlap").GetComponent<GetPic06>().count;
                    currentPopulation[i][8] = EvaluatePoint;
                    Debug.Log(EvaluatePoint + "第" + i + "個体の評価");
                }
                SortVer1(currentPopulation);
                int[,] SubCurrentPopulation = new int[kotainumber,GeneLength];
                for (int i =0; i<kotainumber;i++)
                {
                    for (int j = 0; j < GeneLength; j++)
                    {
                        SubCurrentPopulation[i, j] = currentPopulationSorted[i][j];
                    }
                }

                /*for (int i = 0; i < 20; i++)
                {
                    Debug.Log(i + "個体");
                    for (int j = 0; j < 9; j++)
                    {
                        Debug.Log(currentPopulationSorted[i][j] + "***************");
                    }
                }*/
                int[] ellite = new int[GeneLength];
                for (int i=0;i<GeneLength;i++)
                {
                    ellite[i] = 0; 
                }
                for (int i=0;i<GeneLength;i++)
                {
                    if (ellite[8] < Master[8])
                    {
                        ellite[i] = Master[i];
                    }
                }
                //Debug.Log(ellite[8]+"LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL");
                /*for (int i = 0; i < GeneLength; i++)
                {
                    Debug.Log("ELLLLLLLLLLLLLLLLLLLLITE" + ellite[i]);
                    Debug.Log("ELLLLLLLLLLLLLLLLLLLLITE" + SubCurrentPopulation[0, 8]);
                }*/

                int[] point = new int[kotainumber];
                for (int i=0;i<kotainumber;i++)
                {
                    point[i] = 0;
                    point[i] = currentPopulationSorted[i][8];
                }
                /*for (int i = 0; i < kotainumber; i++)
                {
                    Debug.Log(point[i]+"+++++++++++++++++++++++++");
                    Debug.Log(rouletteChoice(point)+"L*+++++++++++++++++++++++++++++");
                }*/

                //NextPopulation = CrossOver(currentPopulationSorted[rouletteChoice(point)], currentPopulationSorted[rouletteChoice(point) + 1]);

                /*for (int i=0;i<5;i++)
                {
                    Debug.Log(currentPopulationSorted[i][8]+ "L*+++++++++++++++++++++++++++++");
                }*/
                List<int[]> NextPopulation = new List<int[]>();
                for (int i=0;i<kotainumber-1;i++ )
                {
                    int ff = rouletteChoice(point);
                    int ff2 = rouletteChoice(point);
                    int ff3 = Rnd.Next(0, kotainumber-15) ;
                    if (Rnd.Next(0, 100) / 100 < 0.9)
                    {
                        if (i != kotainumber - 1)
                        {
                            //NextPopulation.Add(CrossOver(currentPopulationSorted[i], currentPopulationSorted[i + 1])[0]);
                            NextPopulation.Add(CrossOver(currentPopulationSorted[ff], currentPopulationSorted[ff2]));//ff,ff2
                            //NextPopulation.Add(NextArray);
                        }
                        else
                        {
                            //NextPopulation[i] = CrossOver(currentPopulationSorted[0], currentPopulationSorted[1])[0];
                            NextPopulation.Add(CrossOver(currentPopulationSorted[0], currentPopulationSorted[1]));
                        }
                    }
                    else
                    {
                        NextPopulation[i] = MutaRate(currentPopulationSorted[i])[i];
                    }
                }
                /*for (int i= 0;i<5;i++)
                {
                    Debug.Log(currentPopulationSorted[i][8]+"PPPPPPPPPPPPPPPPPPPPPPPPPP");
                    //Debug.Log(currentPopulation[0]);
                    //Debug.Log(currentPopulationSorted[0]);
                    //Debug.Log(NextPopulation[0]);
                }*/
                SubPopulation = new List<int[]>(NextPopulation);
                for (int i=0; i<kotainumber-2;i++)
                {
                    Debug.Log("次世代の適応度計算******************" + i + "個体******************");
                    yield return StartCoroutine(moving.MovingArm2());
                    GameObject.Find("overlap").GetComponent<GetPic06>().evaluate02();
                    EvaluatePointNext = GameObject.Find("overlap").GetComponent<GetPic06>().count;
                    SubPopulation[i][8] = EvaluatePointNext;
                }
                /*for (int i = 0; i < 19; i++)
                {
                    //Debug.Log("ELLLLLLLLLLLLLLLLLLLLITE" + ellite[i]);
                    //Debug.Log(currentPopulationSorted[i][8] + "L*+++++++++++++++++++++++++++++");
                    Debug.Log(SubPopulation[i][8] + "L*+++++++++++++++++++++++++++++");
                    Debug.Log(SubCurrentPopulation[i,8]);
                }*/
                int[,] SubSubPopulation = new int[kotainumber, GeneLength];
                for (int i = 0; i < kotainumber-1; i++)
                {
                    for (int j = 0; j < GeneLength; j++)
                    {
                        SubSubPopulation[i, j] = SubPopulation[i][j];
                    }
                }
                //配列の合成
                int[,] newPopulation  = new int[SubCurrentPopulation.Length+SubSubPopulation.Length,GeneLength];
                Array.Copy(SubCurrentPopulation,newPopulation,SubCurrentPopulation.Length);
                Array.Copy(SubSubPopulation, 0, newPopulation, SubCurrentPopulation.Length, SubSubPopulation.Length);
                //SubCurrentPopulation.CopyTo(newPopulation, 0);
                //SubSubPopulation.CopyTo(newPopulation, SubCurrentPopulation.Length);

                //合成配列のソート  
                //SortLv2(newPopulation);
                //上位20個体の選出
                //評価値渡すプロフラム
                int[] pointLv2 = new int[kotainumber];
                for (int i=0; i<kotainumber-1;i++)
                {
                    pointLv2[i] = SortLv2(newPopulation)[i,8];
                }
                int[,] newPopulationLv1_2 = new int[kotainumber*2 - 1, GeneLength];
                for (int i=0;i<kotainumber*2-1;i++)
                {
                    for (int j=0;j<GeneLength;j++)
                    {
                        newPopulationLv1_2[i, j] = SortLv2(newPopulation)[i,j];
                    }
                }
                int[,] newPopulationLv2 = new int[kotainumber,GeneLength];
                for (int i = 1; i < kotainumber-1; i++)
                {
                    for (int j = 1; j < GeneLength; j++)
                    {
                        newPopulationLv2[i, j] = newPopulationLv1_2[rouletteChoice(pointLv2),j];
                    }
                }
                /*for (int i = 0; i < kotainumber - 1; i++)
                {
                    Debug.Log(newPopulationLv2[i,8]);
                }*/
                /*newPopulationLv2 = new int[kotainumber,GeneLength];
                for (int i = 0; i < GeneLength-1; i++)
                {
                    Debug.Log(ellite[i]);
                    newPopulationLv2[kotainumber, i] = ellite[i];
                }*/
                //newPopulationLv2[kotainumber,GeneLength-1] = ellite[];
                //int[] newPopulationLv3 = ellite.Concat(ellite).ToArray();

                List<int[]> GetBeautifull = new List<int[]>();
                for (int i = 0;i<kotainumber-1;i++)
                {
                    int[] aaa = new int[GeneLength];
                    for (int j =0;j<GeneLength;j++)
                    {
                        aaa[j] = newPopulationLv2[i, j];
                        //Debug.Log(aaa[j] = newPopulationLv1_2[i, j]);
                    }
                    GetBeautifull.Add(aaa);
                    //Debug.Log(aaa[8]+"GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG");
                }

                currentPopulation = new List<int[]>(GetBeautifull);
                currentPopulation.Add(ellite);
                /*for (int i = 0; i < kotainumber-1; i++)
                {
                    Debug.Log(GetBeautifull[i][8] + "************FFFFFFFFFFFFFFFFFFF*************************");
                }*/
                //currentPopulation = newPopulationLv2;
                //GetBeautifull = 
                /*int[] temp = new int[GeneLength];
                for (int i =0;i<kotainumber;i++)
                {
                    for (int j =0;j<GeneLength;j++)
                    {
                        temp[j] = SubCurrentPopulation[i, j];
                    }
                }*/
                /*for (int i=0;i<39;i++)
                {
                    Debug.Log(SubPopulation[i]);
                }*/
                //ortLv2(SubPopulation);
                /*for (int i = 0; i < kotainumber; i++)
                {
                    Debug.Log(pointLv2[i]+"*************************************");
                }*/
                //壁の破壊//////
                yyy = true;
                if (yyy)
                {
                    Destroy(GameObject.Find("Cube"));
                }
                yyy = false;
                ////////////////
                //終了条件
                if (Age == 20)
                {

                    ArmNumber--;
                    break;
                    //20世代後に終了
                    /*List<int[]> finish = new List<int[]>(SortVer1(currentPopulation));
                    yield return StartCoroutine(moving.MovingArm3());
                    Debug.Log(finish[0][8]+"結果+++++++++++++++++++++++++++++++++++");*/
                }
            Age++;
        }
            Moving1 moving2 = new Moving1();
            List<int[]> finish = new List<int[]>(SortVer1(currentPopulation));
            yield return StartCoroutine(moving2.MovingArm3());
            Debug.Log(finish[0][8] + "結果+++++++++++++++++++++++++++++++++++");
            ArmNumber--;
        //}

    }
    /*private int[] convert(int[] Array)
    {

    }*/
    private List<int[]> CreateInitialData()
    {
        List<int[]> ListArray = new List<int[]>();
        for (int i=0;i<kotainumber;i++)
        {
            int[] Array = new int[GeneLength + 1];
            for (int j=0;j<=GeneLength;j++)
            {
                Array[j] = Rnd.Next(-90, 90);
            }
            ListArray.Add(Array);
        }
        return ListArray;
    }
    private List<int[]> SortVer1(List<int[]> cp)
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
                if (cp[i][8] < cp[j][8])
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
                    aftersort.Add(cp[j]);
                }
            }
        }
        for (int i=0;i<GeneLength;i++)
        {
            Master = aftersort[0];
        }
        
        currentPopulationSorted = new List<int[]>(aftersort);
        return currentPopulationSorted;
    }
    public int[] CrossOver(int[] GeneA, int[] GeneB)
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
        //AfterCrossOver.Add(GeneA);
        //AfterCrossOver.Add(GeneB);

        int[] AfterCrossOver = new int[GeneLength];
        for (int i= 0; i<GeneLength-1;i++)
        {
            AfterCrossOver[i] = 0;
        }
        AfterCrossOver = GeneA;
        return AfterCrossOver;
    }
    public int rouletteChoice(int[] rate)//ルーレット選択
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
    private int[,] SortLv2(int[,] newPopulation)
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
                if (newPopulation[i,8] < newPopulation[j,8])
                {
                    ranking[i]++;
                }
            }
        }
        int[,] aftersortLv2 = new int[kotainumber*2-1,GeneLength];
        for (int i = 0; i < kotainumber * 2 - 1; i++)
        {
            for (int j = 0; j < kotainumber * 2 - 1; j++)
            {
                if (ranking[j] == i)
                {
                    for (int k=0;k<GeneLength;k++)
                    {
                        aftersortLv2[i, k] = newPopulation[j, k];
                    }
                }
            }
        }
        for (int i=0; i<kotainumber*2-1;i++)
        {
            if (aftersortLv2[i, 8] == 0)
            {
                aftersortLv2[i, 8] = aftersortLv2[i - 1, 8];
            }
        }
        return aftersortLv2;
    }
}
