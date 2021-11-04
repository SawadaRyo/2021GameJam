using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// オブジェクト操作スクリプト
/// オブジェクト落下前に回転させ、
/// 落下ボタンで操作を受け付けなくする
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class ObjectController : MonoBehaviour
{
    /// <summary>
    /// オブジェクトのRigidbody2D
    /// </summary>
    Rigidbody2D rb = default;

    [Header("操作ボタン名")]
    /// <summary>
    /// 移動用ボタン名
    /// </summary>
    [SerializeField]
    string buttonNameMove = "HorizontalAD";
    /// <summary>
    /// 回転用ボタン名
    /// </summary>
    [SerializeField]
    string buttonNameRoll = "Horizontal";
    /// <summary>
    /// 落下用ボタン名
    /// </summary>
    [SerializeField]
    string buttonNameDoFall = "Jump";

    [Header("タグ名")]
    /// <summary>
    /// ブロック専用タグ名
    /// </summary>
    [SerializeField]
    string tagNameBlock = "Block";

    [Space]

    /// <summary>
    /// 移動速度係数
    /// </summary>
    [SerializeField]
    float moveSpeedRatio = 1.0f;

    [Space]

    /// <summary>
    /// 次のオブジェクト生成のために遅延させる時間
    /// </summary>
    [SerializeField]
    float delayOfNextGenerate = 1.0f;

    /// <summary>
    /// ブロック生成コンポーネント
    /// </summary>
    Generator gen = default;


    /// <summary>
    /// 初期重力値
    /// </summary>
    float defaultGravityScale = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultGravityScale = rb.gravityScale;
        gen = FindObjectOfType<Generator>();
        SetUseGravity(false);
    }

    // Update is called once per frame
    void Update()
    {
        //横移動
        Vector2 move = transform.position;
        move.x += Input.GetAxis(buttonNameMove) * moveSpeedRatio * Time.deltaTime;
        transform.position = move;
        //回転
        if (Input.GetButtonDown(buttonNameRoll))
        {
            transform.Rotate(0f, 0f, 90f * Input.GetAxisRaw(buttonNameRoll));
        }
        //落下&次のブロックを出現
        if (Input.GetButtonDown(buttonNameDoFall))
        {
            SetUseGravity(true);
            gameObject.tag = tagNameBlock;
            enabled = false;
            StartCoroutine(NextObjectGenerate());
        }
    }

    /// <summary>
    /// 重力を働かせるか設定する
    /// </summary>
    /// <param name="isUse">true:重力を働かせる</param>
    void SetUseGravity(bool isUse)
    {
        if (isUse) rb.gravityScale = defaultGravityScale;
        else rb.gravityScale = 0.0f;
    }

    /// <summary>
    /// 次のオブジェクトを生成するコルーチン
    /// </summary>
    /// <returns></returns>
    IEnumerator NextObjectGenerate()
    {
        yield return new WaitForSeconds(delayOfNextGenerate);

        gen.Generate();
    }
}
