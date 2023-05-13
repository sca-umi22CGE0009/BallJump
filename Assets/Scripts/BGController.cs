using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    //[SerializeField]
    //private GameObject goalPrefab;
    [SerializeField]
    private GameObject bg;
    [SerializeField]
    private float speed = -5f; //背景をスクロールさせる速さ
    [SerializeField]
    private float startLine = 0; //背景移動の開始位置
    [SerializeField]
    private float deadLine = -18; //背景移動の終了位置

    void Start()
    {
        //StartCoroutine(MoveBg());
        //StartCoroutine(SetGoal());
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
        IEnumerator SetGoal()
    {
        while (true)
        {
            Vector3 pos = new Vector3(11,Random.Range(3f,-1.5f),0);
           // GameObject goal = Instantiate(goalPrefab, pos, transform.rotation) as GameObject;
           // goal.transform.parent = bg.transform;
            yield return new WaitForSeconds (2.0f);
        }
    }
    IEnumerator MoveBg()
    {
        while (true)
        {
            Vector3 pos = bg.transform.position;
            pos.x += speed * Time.deltaTime;
            bg.transform.position = pos;
            yield return 0;

        }
    }
}
