using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TileList : MonoBehaviour
{
    private List<TileInfo> listTile;
    private List<List<TileInfo>> tileInfos;

    private void Awake()
    {
        //Создание списков доступных чанков в зависимоти от их типа

        listTile =new List<TileInfo>( Resources.LoadAll<TileInfo>("chunks"));
        Debug.Log("SizeOfAtribute" + Enum.GetValues(typeof(TileInfo.AtributeOfChunk)).Length + "  " + listTile.Count );
        tileInfos = new List<List<TileInfo>>();
        for(int i=0;i< Enum.GetValues(typeof(TileInfo.AtributeOfChunk)).Length; i++)
        {
            tileInfos.Add(new List<TileInfo>());
        }
        Debug.Log(tileInfos.Count);
        foreach (TileInfo elem in listTile)
        {           
            tileInfos[elem.Atribute].Add(elem);
        }
        int j = 0;
        foreach(List<TileInfo> elem in tileInfos)
        {
            j++;
            Debug.Log(j+ " "+ elem.Count);
        }
    }
    public TileInfo GetValue(int i)
    {
       // Debug.Log(i);
        Debug.Log("Atribute"+tileInfos[i][0].Atribute +"  "+i);  
        return tileInfos[i][0];
    }
}
