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
    int gb;

    private void Awake()
    {
        block = GameObject.FindGameObjectsWithTag("Block");
        Generate();
    }
    private void Update()
    {
        var nearblock = block.OrderBy(x => Vector3.Distance(new Vector3(0,x.transform.position.y,0), new Vector3(0,this.transform.position.y,0))).FirstOrDefault();
        Transform blockPosition = nearblock.GetComponent<Transform>();
        Vector3 generateBlockPosition = blockPosition.gameObject.transform.position;
        gameObject.transform.position = new Vector3(0,generateBlockPosition.y + distance,0);
    }

    public void Generate()
    {
        scoreSystem.AddScore();
        beforeBlock = gb;
        gb = Random.Range(0, blocks.Length - 1);
        Instantiate(blocks[Judge(gb)], genaratePoint.position,Quaternion.identity);
    }
    int Judge(int gb)
    {
        if(beforeBlock != gb)
        {
            Debug.Log("生成");
            return gb;
        }
        else
        {
            int a = Random.Range(0, blocks.Length - 1);
            Debug.Log("再起 " + a);
            return Judge(a);
        }
    }
}
