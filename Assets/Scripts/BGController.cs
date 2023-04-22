using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;//スクロールの速さ
    [SerializeField]
    private float startLine;//BG開始位置
    [SerializeField]
    private float deadLine;//BG終了位置

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0, 0);//x座標をspeed分動かす

        //もしdeadLineより大きくなったら
        if (transform.position.x < deadLine)
        {
            transform.position = new Vector3(startLine, 0, 0);//startLineに戻る
        }
    }
}
