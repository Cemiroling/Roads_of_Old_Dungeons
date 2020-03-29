using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationContoller : MonoBehaviour
{

    [SerializeField] private TileList chunkList;
    [SerializeField] private int sizeOfBlockX;
    [SerializeField] private int sizeOfBlockY;

    void Start()
    { 
        AlgorithmGeneration algorithmGeneration = new AlgorithmGeneration();
        LoadStatus.MessageInfo = "Preparation for peace";
        LoadStatus.PercentOfLoad = 0.0f;
        algorithmGeneration.SetPath();     
        LoadStatus.MessageInfo = "Game world rendering";
        LoadStatus.PercentOfLoad = 0.5f;
      //  StartCoroutine(Generation(algorithmGeneration));
        for (int i = 0; i < algorithmGeneration.Y; ++i)
        {
            for (int j = 0; j < algorithmGeneration.X; ++j)
            {
             
                    TileInfo tile = chunkList.GetValue(algorithmGeneration.Map[j, i]);
                    Instantiate(tile, new Vector2( j * sizeOfBlockX , algorithmGeneration.Y * sizeOfBlockY - i * sizeOfBlockY ), new Quaternion());

            }
           // LoadStatus.PercentOfLoad = LoadStatus.PercentOfLoad + 0.05f;
        }
    }


    IEnumerator Generation(AlgorithmGeneration algorithmGeneration)
    {
        
        yield return null;
    }
}

