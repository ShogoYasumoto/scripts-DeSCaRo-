using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenericAlgorithms02 : MonoBehaviour {
    System.Random Rnd = new System.Random();
    private const int GeneLength = 32;//遺伝子長
    private int Age;                  // 現在の世代
    private const double MutateRate = 0.05; //突然変異の確率
    private bool isCalled = false;
    [HideInInspector]
    public int Seacence = 0;
    private int point;
    [HideInInspector]
    public List<int[]> currentPopulation;
    [HideInInspector]
    public List<int[]> selected;
    [HideInInspector]
    public List<int[]> nextPopulation;
    [HideInInspector]
    public List<int[]> children;

    void Start()
    {
        //List<int[]> currentPopulation = new List<int[]>();

    }

    // Update is called once per frame
    void Update() {
        if (Time.time > 4.0f)
        {
            if (isCalled == false)
            {
                isCalled = true;
                StartCoroutine("Run");
            }
        }
    }
    //実行
    public IEnumerator Run() 
    {
        //初期設定(現世代)
        Age = 1;
        //publicのListへ変換
        currentPopulation = CreateInitialData01();
        //Debug.Log(currentPopulation[4][0]);//エラー

        while (true)
        {
            Seacence = 0;
            Debug.Log("第"+Age+"世代");
            //ランダム出力した角度を各Armに渡す
            Moving moving = new Moving();
            yield return StartCoroutine(moving.Randommove());
            /*Debug.Log(currentPopulation[0][0]);
            Debug.Log(currentPopulation[0][1]);
            Debug.Log(currentPopulation[0][2]);
            Debug.Log(currentPopulation[0][3]);
            Debug.Log(currentPopulation[0][4]);
            Debug.Log(currentPopulation[0][5]);
            Debug.Log(currentPopulation[0][6]);
            Debug.Log(currentPopulation[0][7]);*/
            Debug.Log("sssssssssssssssssssssssssssssssssssssssssssss");
            //評価関数呼び出し
            GameObject.Find("overlap").GetComponent<GetPic04>().FF3();
            yield return new WaitForSeconds(1.0f);
            point = GameObject.Find("overlap").GetComponent<GetPic04>().count;
            currentPopulation[0][32] = point;
            Debug.Log(currentPopulation[0][32]);

            GameObject.Find("Base_Arm4").GetComponent<Moving>().num = 0;

            Seacence = GameObject.Find("Base_Arm4").GetComponent<Moving>().num++ + 1;
            yield return StartCoroutine(moving.Randommove());
            /*Debug.Log(currentPopulation[1][0]);
            Debug.Log(currentPopulation[1][1]);
            Debug.Log(currentPopulation[1][2]);
            Debug.Log(currentPopulation[1][3]);
            Debug.Log(currentPopulation[1][4]);
            Debug.Log(currentPopulation[1][5]);
            Debug.Log(currentPopulation[1][6]);
            Debug.Log(currentPopulation[1][7]);*/
            Debug.Log("ttttttttttttttttttttttttttttttttttttttttttttt");
            //評価関数呼び出し
            GameObject.Find("overlap").GetComponent<GetPic04>().FF3();
            yield return new WaitForSeconds(1.0f);
            point = GameObject.Find("overlap").GetComponent<GetPic04>().count;
            currentPopulation[1][32] = point;
            Debug.Log(currentPopulation[1][32]);

            Seacence = GameObject.Find("Base_Arm4").GetComponent<Moving>().num++ + 1;
            yield return StartCoroutine(moving.Randommove());
            /*Debug.Log(currentPopulation[2][0]);
            Debug.Log(currentPopulation[2][1]);
            Debug.Log(currentPopulation[2][2]);
            Debug.Log(currentPopulation[2][3]);
            Debug.Log(currentPopulation[2][4]);
            Debug.Log(currentPopulation[2][5]);
            Debug.Log(currentPopulation[2][6]);
            Debug.Log(currentPopulation[2][7]);*/
            Debug.Log("333333333333333333333333333333333333333333333");
            //評価関数呼び出し
            GameObject.Find("overlap").GetComponent<GetPic04>().FF3();
            yield return new WaitForSeconds(1.0f);
            point = GameObject.Find("overlap").GetComponent<GetPic04>().count;
            currentPopulation[2][32] = point;
            Debug.Log(currentPopulation[2][32]);

            Seacence = GameObject.Find("Base_Arm4").GetComponent<Moving>().num++ + 1;
            yield return StartCoroutine(moving.Randommove());
            /*Debug.Log(currentPopulation[3][0]);
            Debug.Log(currentPopulation[3][1]);
            Debug.Log(currentPopulation[3][2]);
            Debug.Log(currentPopulation[3][3]);
            Debug.Log(currentPopulation[3][4]);
            Debug.Log(currentPopulation[3][5]);
            Debug.Log(currentPopulation[3][6]);
            Debug.Log(currentPopulation[3][7]);*/
            Debug.Log("44444444444444444444444444444444444444444444");
            //評価関数呼び出し
            GameObject.Find("overlap").GetComponent<GetPic04>().FF3();
            yield return new WaitForSeconds(1.0f);
            point = GameObject.Find("overlap").GetComponent<GetPic04>().count;
            currentPopulation[3][32] = point;
            Debug.Log(currentPopulation[3][32]);

            //選択select結果をリストで受け取る
            selected = Select(currentPopulation).ToList();

            //交叉
            children = CrossOver(selected[0], selected[1]).ToList();

            //突然変異
            var NextPopulation = selected.Concat(children).Select(individual =>
            {
                if (Rnd.NextDouble() < MutateRate)
                {
                    Debug.Log("+++++++++++++突然変異+++++++++++++");
                    return Mutate(individual);
                }
                return individual;
            });

            //次世代に進む
            currentPopulation = NextPopulation.ToList();

            //終了シーケンス
            //if (IsConverged(currentPopulation)) break;
            Age++;
        }

    }
    //初期データ
    private List<int[]> CreateInitialData01()
    {
        List<int[]> ListArray = new List<int[]>();

        for (int j = 0; j <= 3; j++)
        {
            int[] array = new int[GeneLength + 1];
            for (int i = 0; i <= GeneLength; i++)
            {
                //Debug.Log(array);
                array[i] = Rnd.Next(-90, 90);
            }
            ListArray.Add(array);
        }
        return ListArray;
    }
    //選択・淘汰
    private IEnumerable<int[]> Select(List<int[]> currentPopulation)
    {
        //成績上位順に並べる
        int[] rank = new int[4];
        //配列の初期化
        for (int i = 0; i < 4; i++)
        {
            rank[i] = 0;
        }
        //4人の並べ替え
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                if (currentPopulation[i][32] < currentPopulation[j][32]) {
                    rank[i]++;
                }
            }
        }
        List<int[]> nextArray = new List<int[]>();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if(rank[j] == i)
                {
                    // 格納する
                    nextArray.Add(currentPopulation[j]);
                }
            }
        }
        Debug.Log(nextArray[0][32]+"*************************");
        Debug.Log(nextArray[1][32]+"*************************");
        //上位2位を選択
        yield return nextArray[0];
        yield return nextArray[1];
    }
    //交叉
    private IEnumerable<int[]> CrossOver(int[] GeneA, int[] GeneB)
    {
        //配列の第8要素(point)を取り除く
        List<int> geneA = new List<int>(GeneA);
        List<int> geneB = new List<int>(GeneB);
        geneA.RemoveAt(32);
        geneB.RemoveAt(32);
        geneA.Add(0);
        geneB.Add(0);
        GeneA = geneA.ToArray();
        GeneB = geneB.ToArray();
        //偶数列の要素を交換(親の複製)
        int[] GeneA1 = { GeneA[0], GeneB[1], GeneA[2], GeneB[3], GeneA[4], GeneB[5], GeneA[6], GeneB[7],GeneA[8], GeneB[9], GeneA[10], GeneB[11], GeneA[12], GeneB[13], GeneA[14], GeneB[15], GeneA[16], GeneB[17], GeneA[18], GeneB[19], GeneA[20], GeneB[21], GeneA[22], GeneB[23], GeneA[24], GeneB[25], GeneA[26], GeneB[27], GeneA[28], GeneB[29], GeneA[30], GeneB[31],GeneA[32] };
        int[] GeneB1 = { GeneB[0], GeneA[1], GeneB[2], GeneA[3], GeneB[4], GeneA[5], GeneB[6], GeneA[7],GeneB[8], GeneA[9], GeneB[10], GeneA[11], GeneB[12], GeneA[13], GeneB[14], GeneA[15], GeneB[16], GeneA[17], GeneB[18], GeneA[19], GeneB[20], GeneA[21], GeneB[22], GeneA[23], GeneB[24], GeneA[25], GeneB[26], GeneA[27], GeneB[28], GeneA[29], GeneB[30], GeneA[31],GeneB[32] };
        //配列の格納(不要)
        var GeneAB = GeneA1;
        var GeneBA = GeneB1;

        yield return GeneAB.ToArray();
        yield return GeneBA.ToArray();
    }
    //突然変異　
    private int[] Mutate(int[] data)
    {
        //ランダム位置で値を更新(1箇所)
        var point = Rnd.Next(0,GeneLength-1);
        data[point] = Rnd.Next(-90, 90);
        return data;
    }
    //終了条件
    private int IsConverged(List<int[]> Population)
    {
       return 0;
    }
}
