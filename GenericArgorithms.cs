using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class GA:MonoBehaviour
{
    private const int GeneLength = 10;      // 遺伝子長
    private int Age;                        // 現在の世代
    private const double MutateRate = 0.05; // 突然変異の確率5%
    System.Random Rnd = new System.Random();

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("KKKKKKKKKKKKKKKKKKKKKKKKKKKKK");
            //Run();
        }
    }

    // 実行
    /*public void Run()
    {
        // 初期設定(適当な4個体を用意)
        Age = 1;
        var currentPopulation = CreateInitialData();
        Debug.Log(currentPopulation[0]);

        while (true)
        {
            DebugState(Age, currentPopulation);

            // 選択
            var selected = Select(currentPopulation).ToList();

            // 交差
            var children = CrossOver(selected[0], selected[1]).ToList();

            // 突然変異
            var nextPopulation = selected.Concat(children).Select(individual =>
            {
                if (Rnd.NextDouble() < MutateRate)
                {
                    return Mutate(individual);
                }
                return individual;
            });

            // 次世代に進む
            currentPopulation = nextPopulation.ToList();

            // 終了
            if (IsConverged(currentPopulation)) break;
            Age++;
        }
        DebugState(Age, currentPopulation);
    }

    // 初期データ
    private List<int[]> CreateInitialData()
    {
        return Enumerable.Range(0, 4).Select(_ =>
        {
            var array = new int[GeneLength];
            for (int i = 0; i < GeneLength; i++)
            {
                array[i] = Rnd.Next(-90, 90);
            }
            return array;
        }).ToList();
    }

    // 選択・淘汰
    private IEnumerable<int[]> Select(List<int[]> currentPopulation)
    {
        // 1の数が多い順に並べる
        var nextPopulation = currentPopulation.OrderByDescending(d => d.Count(b => b)).ToList();

        // 成績上位2個体を選択
        yield return nextPopulation[0];
        yield return nextPopulation[1];
    }

    // 交差
    private IEnumerable<int[]> CrossOver(int[] GeneA, int[] GeneB)
    {
        // 個体A, Bをランダムな点で分割し A=A1B2, B=B1A2 とする
        // 分割点
        var point = Rnd.Next(1, GeneLength - 1);

        // 親を複製
        var splitedA1 = GeneA.Take(point);
        var splitedA2 = GeneA.Skip(point).Take(GeneLength - point);
        var splitedB1 = GeneB.Take(point);
        var splitedB2 = GeneB.Skip(point).Take(GeneLength - point);

        // 結合して返す
        yield return splitedA1.Concat(splitedB2).ToArray();
        yield return splitedB1.Concat(splitedA2).ToArray();
    }

    // 突然変異
    private int[] Mutate(int[] data)
    {
        // ランダム位置で1ビットのみ反転
        var point = Rnd.Next(0, GeneLength);
        if (point >= 0) data[point] = !data[point];
        return data;
    }

    // 収束評価(すべて1になっていれば終了)
    private int IsConverged(List<int[]> Population)
    {
        var top = Population.OrderByDescending(d => d.Count(b => b)).First();
        return top.Count(b => b) == top.Count();
    }

    // 状態確認用
    public void DebugState(int age, List<int[]> Population)
    {
        Debug.Log($"世代数: {age}");
        foreach (var indivisual in Population.OrderByDescending(d => d.Count(b => b)))
        {
            foreach (var b in indivisual) Debug.Log(b ? "1" : "0");
            Debug.Log($"");
        }
    }*/
}