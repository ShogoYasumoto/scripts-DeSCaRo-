using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class GenericArgorithms03 : MonoBehaviour {
    System.Random Rnd = new System.Random();
    private const int GeneLength = 32;//33個
    private const int kotainumber = 100;//1世代の個体数
    private int Age;
    private const double MutateRate = 0.05;
    private bool isCalled = false;
    private int number;
    [HideInInspector]
    public int rankinnumber = 0;
    [HideInInspector]
    public int blacknumber = 0;
    [HideInInspector]
    public int Seacence = 0;
    private int point;
    private int shadow;
    private int black;
    [HideInInspector]
    public List<int[]> currentPopulation;//現世代の個体の配列リスト
    [HideInInspector]
    public List<int[]> nextPopulation;//次世代の個体の保管配列リスト
    [HideInInspector]
    public List<int[]> currentPopulationSorted;//ソート後の個体の配列リスト
    [HideInInspector]
    public List<int[]> selected;
    [HideInInspector]
    public int[] evaluate = new int[kotainumber];//評価値を代入する配列
    [HideInInspector]
    public List<int[]> shadowpoint;//ソート後の個体の配列リスト
    [HideInInspector]
    public List<int[]> blackpoint;//ソート後の個体の配列リスト

    public int AAA =0;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 4.0f)
        {
            if (isCalled == false)
            {
                isCalled = true;
                StartCoroutine("Mas");
            }
        }
    }
    public IEnumerator Mas()
    {
        Age = 1;
        currentPopulation = CreateInitialData();//初期集団の生成

        while (true)//評価関数より現世代の各個体の適応度を計算する
        {
            int Nkotai = 0;
            int choicenumber = 0;
            List<int[]> shadowpoint = new List<int[]>();
            for (int i = 0; i <= kotainumber; i++)
            {
                int[] list = new int[2];
                for (int j = 0; j <= 1; j++)
                {
                    list[j] = 0;
                }
                shadowpoint.Add(list);
            }
            List<int[]> blackpoint = new List<int[]>();
            for (int i = 0; i <= kotainumber; i++)
            {
                int[] list = new int[2];
                for (int j = 0; j <= 1; j++)
                {
                    list[j] = 0;
                }
                blackpoint.Add(list);
            }

            Seacence = 0;
            Debug.Log("******************" + Age + "世代" + "******************");//現在の世代数
            Moving moving = new Moving();//DeSCaRo起動プログラムのインスタンス化

            yield return StartCoroutine(moving.Randommove());//DeSCaRoを起動
            Debug.Log("11111111111111111111");//各個体の評価
            ////////////////////////
            GameObject.Find("overlap").GetComponent<GetPic05>().FF02();
            ////////////////////////
            GameObject.Find("overlap").GetComponent<GetPic04>().FF3();
            point = GameObject.Find("overlap").GetComponent<GetPic04>().count;
            shadow = GameObject.Find("overlap").GetComponent<GetPic04>().megamax;
            black = GameObject.Find("overlap").GetComponent<GetPic04>().countt;
            currentPopulation[0][32] = point;
            shadowpoint[0][0] = shadow;
            blackpoint[0][0] = black;

            GameObject.Find("Base_Arm4").GetComponent<Moving>().num = 0;

            for (int i=0;i<kotainumber-1;i++) {
                int aaa;
                aaa = i+1;
                Seacence = GameObject.Find("Base_Arm4").GetComponent<Moving>().num++ + 1;
                yield return StartCoroutine(moving.Randommove());
                Debug.Log("[" + aaa + "]個体目 --------------------------------------------------");
                GameObject.Find("overlap").GetComponent<GetPic04>().FF3();
                point = GameObject.Find("overlap").GetComponent<GetPic04>().count;
                shadow = GameObject.Find("overlap").GetComponent<GetPic04>().megamax;
                black = GameObject.Find("overlap").GetComponent<GetPic04>().countt;
                currentPopulation[i+1][32] = point;
                shadowpoint[i+1][0] = shadow;
                blackpoint[i+1][0] = black;
            }

            Sort(currentPopulation);//各個体の評価順にソート
            blackpointSort(blackpoint);
            ShadowSort(shadowpoint);
            List<int[]> nextPopulation = new List<int[]>();

            int[] evaluate = new int[kotainumber];
            for (int i = 0;i < kotainumber; i++)//評価値のみを抽出
            {
                evaluate[i] = currentPopulationSorted[i][32];
                //Debug.Log(evaluate[i]+"++++++++++++++++++++++++");
            }

            while (true)
            {
                number = 0;
                number = Rnd.Next(1, 10);
                if (number == 1 || number == 2 )//40％の確率で選択(そのままコピー)
                {
                    nextPopulation.Add(currentPopulationSorted[blacknumber]);
                    choicenumber = rouletteChoice(evaluate);//ルーレット選択方式
                    nextPopulation.Add(currentPopulationSorted[choicenumber]);
                    Nkotai +=2;
                    //Debug.Log("*************************" + "一" + "*************************");
                }
                if (number == 5 || number == 6 || number == 8)//40％の確率で選択(交叉)
                {
                    //choicenumber = rouletteChoice(evaluate);//ルーレット選択方式
                    List<int[]> elisasa = new List<int[]>();
                    elisasa = CrossOver(currentPopulationSorted);
                    nextPopulation.Add(elisasa[0]);
                    nextPopulation.Add(elisasa[1]);
                    /*nextPopulation.Add(CrossOver(currentPopulationSorted)[0]);
                    nextPopulation.Add(CrossOver(currentPopulationSorted)[1]);*/
                    //nextPopulation.Add(CrossOver(currentPopulationSorted)[rouletteChoice(evaluate)]);
                    Nkotai += 2;
                    //Debug.Log("*************************" + "二" + "*************************");
                }
                if (number == 3 || number == 4 || number == 7 )
                {

                    List<int[]> elisa = new List<int[]>();
                    elisa = CrossOverPremium(currentPopulationSorted, rankinnumber, blacknumber);
                    nextPopulation.Add(elisa[0]);
                    nextPopulation.Add(elisa[1]);
                    Nkotai += 2;
                    //Debug.Log("*************************" + "三" + "*************************");
                }
                if (number == 9 || number == 10 )//20％の確率で選択(突然変異)
                {
                    nextPopulation.Add(Mutate(currentPopulationSorted)[0]);
                    Nkotai++;
                    //Debug.Log("*************************" + "四" + "*************************");
                }
                if (Nkotai == 97)
                {
                    if (currentPopulationSorted[0][32] > 1500)
                    {
                        nextPopulation.Add(currentPopulationSorted[1]);
                    }
                    else
                    { 
                    nextPopulation.Add(currentPopulationSorted[0]);
                    }
                    nextPopulation.Add(currentPopulationSorted[rankinnumber]);
                    nextPopulation.Add(currentPopulationSorted[blacknumber]);

                    ////////////////////////////////////////////////
                    /*Debug.Log(nextPopulation);
                    for (int i = 0;i < 7;i++)
                    {
                        Debug.Log("***************************個体" +i+"番目******************************" );
                        for (int j =0; j< 32;j++)
                        {
                            Debug.Log(nextPopulation[i][j]);
                        }
                    }*/
                    ////////////////////////////////////////////////    
                    break;
                }
                if (Nkotai == 98)
                {
                    nextPopulation.RemoveAt(97);
                    if (currentPopulationSorted[0][32] > 1500)
                    {
                        nextPopulation.Add(currentPopulationSorted[1]);
                    }
                    else
                    {
                        nextPopulation.Add(currentPopulationSorted[0]);
                    }
                    //nextPopulation.Add(currentPopulationSorted[0]);
                    nextPopulation.Add(currentPopulationSorted[rankinnumber]);
                    nextPopulation.Add(currentPopulationSorted[blacknumber]);
                    break;
                }
            }
            /*for (int i=0;i<8;i++)
            {
                Debug.Log(i + "番目の個体++++++++++++++++++++++++++");
                for (int j=0;j<32; j++)
                {
                    Debug.Log(nextPopulation[i][j]);
                }
            }*/
            Destroy(GameObject.Find("Cube"));
            currentPopulation = nextPopulation.ToList();
            Age++;
        }
    }

    private List<int[]> CreateInitialData()//初期個体の生成(ランダム)
    {
        List<int[]> ListArray = new List<int[]>();

        for (int i = 0;i <= kotainumber; i++ )// 8個体生成する．
        {
            int[] list = new int[GeneLength + 1];
            for (int j = 0; j <= GeneLength; j++)
            {
                list[j] = Rnd.Next(-90,90);
            }
            ListArray.Add(list);
        }
        return ListArray;
    }
    private int ShadowSort(List<int[]> shapo)
    {
        int[] rankin = new int[kotainumber];
        for (int i = 0; i < kotainumber; i++)
        {
            rankin[i] = 0;
        }
        for (int i=0; i<kotainumber;i++)
        {
            for (int j=0;j<kotainumber; j++)
            {
                if (shapo[i][0] < shapo[j][0])
                {
                    rankin[i]++;
                }
            }
        }
        List<int[]> afterShadowSort = new List<int[]>();
        for (int i = 0; i < kotainumber; i++)
        {
            for (int j = 0; j < kotainumber; j++)
            {
                if (rankin[j] == 0) 
                {
                    rankinnumber = j;
                }
            }
        }
        return rankinnumber;
    }
    private int blackpointSort(List<int[]> blackpoint)
    {
        int[] rankin = new int[kotainumber];
        for (int i = 0; i < kotainumber; i++)
        {
            rankin[i] = 0;
        }
        for (int i = 0; i < kotainumber; i++)
        {
            for (int j = 0; j < kotainumber; j++)
            {
                if (blackpoint[i][0] > blackpoint[j][0])
                {
                    rankin[i]++;
                }
            }
        }
        List<int[]> afterblackpointSort = new List<int[]>();
        for (int i = 0; i < kotainumber; i++)
        {
            for (int j = 0; j < kotainumber; j++)
            {
                if (rankin[j] == 0)
                {
                    blacknumber = j;
                }
            }
        }
        return blacknumber;
    }
    private List<int[]> Sort(List<int[]> sort)//個体のソート
    {
        //List<int[]> currentPopulationSorted = new List<int[]>();
        int[] rank = new int[kotainumber];//適応度順の個体のソート
        for (int i = 0; i < kotainumber; i++)
        {
            rank[i] =  0;
        }

        for (int i = 0; i < kotainumber; i++)
        {
            for (int j = 0; j < kotainumber; j++)
            {
                if(sort[i][32] < sort[j][32])
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
                    aftersort.Add(sort[j]);
                }
            }
        }
        // currentPopulationSorted.Add(aftersort);
        currentPopulationSorted = aftersort;
        return currentPopulationSorted;
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

    private List<int[]> CrossOver(List<int[]> cps)//交叉(引数はcurrentPopulationSorted)
    {
        List<int[]> crossoverList = new List<int[]>();
        int one;
        int two;
        int[] crossoverA = new int[32];
        int[] crossoverB = new int[32];
        int[] tempA = new int[32];
        int[] tempB = new int[32];

        int[] evaluate = new int[kotainumber];//評価値を代入する配列
        for (int i = 0; i < kotainumber; i++)//評価値のみを抽出
        {
            evaluate[i] = currentPopulationSorted[i][32];
        }
        crossoverA = cps[rouletteChoice(evaluate)];
        crossoverB = cps[rouletteChoice(evaluate)];
        one = Rnd.Next(0, 31);
        two = Rnd.Next(0, 31);
        int integram = 0;

        integram = Rnd.Next(1, 100);
        if (integram != 99 || integram != 98)
        {
            while (one == two)
            {
                one = Rnd.Next(0, 31);
                two = Rnd.Next(0, 31);
                if (one != two)
                {
                    break;
                }
            }
            //tempB = crossoverB;
            //Debug.Log("one****************"+one+"two*****************"+two);
            if (one < two)
            {
                for (int i = one; i < two; i++)
                {
                    tempB[i] = crossoverB[i];
                    tempA[i] = crossoverA[i];
                    crossoverB[i] = tempA[i];
                    crossoverA[i] = tempB[i];
                    //Debug.Log("++++++++++++++++++++++");
                }
            }
            if (two < one)
            {
                for (int i = two; i < one; i++)
                {
                    tempB[i] = crossoverB[i];
                    tempA[i] = crossoverA[i];
                    crossoverB[i] = tempA[i];
                    crossoverA[i] = tempB[i];
                    //Debug.Log("----------------------");
                }
            }
        }
        else
        {
            Debug.Log("//交叉なし//");
        }
        crossoverList.Add(crossoverA);
        crossoverList.Add(crossoverB);
        return crossoverList;
    }
    private List<int[]> CrossOverPremium(List<int[]> cps,int rank,int black)
    {
        List<int[]> ArrayList = new List<int[]>();
        int[] crossoverpremiumA = new int[32];
        int[] crossoverpremiumB = new int[32];

        crossoverpremiumA = cps[rank];
        crossoverpremiumB = cps[black];
        int[] tempA = new int[32];
        int[] tempB = new int[32];
        int one;
        int two;
        one = Rnd.Next(0, 31);
        two = Rnd.Next(0, 31);
        while (one == two)
        {
            one = Rnd.Next(0, 31);
            two = Rnd.Next(0, 31);
            if (one != two)
            {
                break;
            }
        }
        if (one < two)
        {
            for (int i = one; i < two; i++)
            {
                tempB[i] = crossoverpremiumB[i];
                tempA[i] = crossoverpremiumA[i];
                crossoverpremiumB[i] = tempA[i];
                crossoverpremiumA[i] = tempB[i];
                //Debug.Log("++++++++++++++++++++++");
            }
        }
        if (two < one)
        {
            for (int i = two; i < one; i++)
            {
                tempB[i] = crossoverpremiumB[i];
                tempA[i] = crossoverpremiumA[i];
                crossoverpremiumB[i] = tempA[i];
                crossoverpremiumA[i] = tempB[i];
                //Debug.Log("----------------------");
            }
        }
        ArrayList.Add(crossoverpremiumA);
        ArrayList.Add(crossoverpremiumB);
        return ArrayList;
    }
    private List<int[]> Mutate(List<int[]> cps)//突然変異(引数はcurrentPopulationSorted)
    {
        List<int[]> temp = new List<int[]>();
        int[] mutate = new int[32];
        int mutaterate;
        mutate = cps[Rnd.Next(0, 8)];
        mutaterate = Rnd.Next(1, 100);
        if (mutaterate == 1 || mutaterate == 2 || mutaterate == 3 || mutaterate == 4 || mutaterate == 5 || mutaterate == 6 || mutaterate == 7 || mutaterate == 8 || mutaterate == 9 || mutaterate == 10 || mutaterate == 11 || mutaterate == 12 || mutaterate == 13 || mutaterate == 14 || mutaterate == 15 || mutaterate == 16 || mutaterate == 17 || mutaterate == 18 || mutaterate == 19 || mutaterate == 20 || mutaterate == 21 || mutaterate == 22 || mutaterate == 23 || mutaterate == 24 || mutaterate == 25 ) 
        {
            for (int i = 1; i < 15; i++)
            {
                mutate[2 * i] = Rnd.Next(-90, 90);
            }
            temp.Add(mutate);
        }
        else
        {
            temp.Add(mutate);
        }
        return temp;
    }
}

