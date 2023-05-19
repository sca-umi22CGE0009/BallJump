using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    [SerializeField]
    private float speed = -3f; //背景をスクロールさせる速さ
    [SerializeField]
    private float startLine = 18; //背景移動の開始位置
    [SerializeField]
    private float deadLine = -18; //背景移動の終了位置

    void Start()
    {
    }

    void Update()
    {
        Scroll();
    }
    private void Scroll()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0); //x座標をscrollSpeed分動かす

        if (transform.position.x < deadLine) //deadLineより大きくなったら
        {
            transform.position = new Vector3(startLine, 0, 0);
        }
    }
}
