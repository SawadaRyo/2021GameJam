using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject[] blocks;
    [SerializeField] Transform genaratePoint;
    int beforeBlock;
    
    void Generate()
    {
        var gb = Random.Range(0, blocks.Length-1);
        int judge = Judge(gb);
        Instantiate(blocks[judge], genaratePoint.position,Quaternion.identity);
    }
    int Judge(int gb)
    {
        if(beforeBlock != gb)
        {
            beforeBlock = gb;
            return gb;
        }
        else
        {
            return Judge(Random.Range(0, blocks.Length - 1));
        }
    }
}
