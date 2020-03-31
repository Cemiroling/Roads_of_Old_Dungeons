using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AlgorithmGeneration
{
    public int[,] Map { get { return map; } }

    private int[,] map;

    private int x;
    private int y;

    public int X { get { return x; } }

    private int startIndex;

    private int endIndex;

    public int Y { get { return y; } }

    public  bool isFinish = false;
    public  int prevDir = -1;

    public AlgorithmGeneration()
    {
        x = Random.Range(6, 15);
        y = Random.Range(6, 9);
        map = new int[x, y];
    }

    public void SetPath()
    {
        startIndex = Random.Range(0, x - 1);
        endIndex = startIndex;
        int dir;
        int[] ms = new int[2];

        int start = Random.Range(0, y);
        map[0, start] = 1;
        ms[1] = start;

        while (!isFinish)
        {
            dir = Random.Range(0, 4);
            switch (dir)
            {
                case 0:
                    movingUpside(map, ms, ref prevDir, ref isFinish, x);
                    break;
                case 1:
                    movingForward(map, ms, ref prevDir, ref isFinish, x);
                    break;
                case 2:
                    movingForward(map, ms, ref prevDir, ref isFinish, x);
                    break;
                case 3:
                    movingDownside(map, ms, ref prevDir, ref isFinish, x, y);
                    break;
            }
        }
    }

    public static void movingUpside(int[,] mx, int[] ms, ref int prevDir, ref bool isFinish, int x)
    {
        if (ms[0] == x - 1)
            return;
        ms[1]--;
        if (ms[1] < 0)
            ms[1]++;
        else
        {
            if (mx[ms[0], ms[1]] != 0)
                ms[1]++;
            else
            {
                switch (prevDir)
                {
                    case -1:
                        mx[ms[0], ms[1] + 1] = 9;
                        prevDir = 0;
                        break;
                    case 0:
                        mx[ms[0], ms[1] + 1] = 4;
                        prevDir = 0;
                        break;
                    case 2:
                        mx[ms[0], ms[1] + 1] = 5;
                        prevDir = 0;
                        break;
                }
            }
        }
    }

    public static void movingDownside(int[,] mx, int[] ms, ref int prevDir, ref bool isFinish, int x, int y)
    {
        if (ms[0] == x - 1)
            return;
        ms[1]++;
        if (ms[1] > y - 1)
            ms[1]--;
        else
        {
            if (mx[ms[0], ms[1]] != 0)
                ms[1]--;
            else
                switch (prevDir)
                {
                    case -1:
                        mx[ms[0], ms[1] - 1] = 10;
                        prevDir = 3;
                        break;
                    case 2:
                        mx[ms[0], ms[1] - 1] = 6;
                        prevDir = 3;
                        break;
                    case 3:
                        mx[ms[0], ms[1] - 1] = 4;
                        prevDir = 3;
                        break;
                }
        }
    }

    public static void movingForward(int[,] mx, int[] ms, ref int prevDir, ref bool isFinish, int x)
    {

        switch (prevDir)
        {
            case -1:
                mx[ms[0], ms[1]] = 1;
                prevDir = 2;
                break;
            case 0:
                mx[ms[0], ms[1]] = 7;
                prevDir = 2;
                break;
            case 2:
                if (ms[0] == x - 1)
                    mx[ms[0], ms[1]] = 2;
                else
                    mx[ms[0], ms[1]] = 3;
                prevDir = 2;
                break;
            case 3:
                mx[ms[0], ms[1]] = 8;
                prevDir = 2;
                break;
        }
        ms[0]++;
        if (ms[0] == x)
            isFinish = true;

    }
}