using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGoalScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] goalPrefab;
    [SerializeField]
    private float lineMax = 4f;
    [SerializeField]
    private float lineMin = -2f;

    private float time;

    private float x;
    private float y;


    private void RandomRange()
    {
        x = 10;

        y = Random.Range(lineMin, lineMax);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        //前フレームからの時間を加算していく
        time += Time.deltaTime;

        if (time >= 2.5f)
        {
            RandomRange();

            //GameObjectを上記で決まったランダムな場所に生成
            int item = Random.Range(0, goalPrefab.Length);
            Instantiate(goalPrefab[item], new Vector2(x, y), goalPrefab[item].transform.rotation);

            //経過時間の初期化
            time = 0.0f;
        }
    }
}
