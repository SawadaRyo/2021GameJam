using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject[] blocks;
    [SerializeField] Transform genaratePoint;
    [SerializeField] ScoreSystem scoreSystem;
    [SerializeField] float distance = 5f;
    int beforeBlock = 10000;
    GameObject[] block;

    private void Awake()
    {
        block = GameObject.FindGameObjectsWithTag("Block");
        Generate();
    }
    private void Update()
    {
        var nearblock = block.OrderBy(x => Vector3.Distance(new Vector3(0,x.transform.position.y,0), new Vector3(0,this.transform.position.y,0))).FirstOrDefault();
        Transform blockPosition = nearblock.GetComponent<Transform>();
        Vector3 generateBlockPosition = this.gameObject.transform.position;
        blockPosition.position = new Vector3(0,generateBlockPosition.y + distance,0);
        
    }

    public void Generate()
    {
        scoreSystem.AddScore();
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
