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

    [SerializeField] private float randomTime = 2.5f;
    private float time;

    private float x;
    private float y;

    void Start()
    {
        time = randomTime;
    }
    // Update is called once per frame
    void Update()
    {

        time -= Time.deltaTime;

        //time秒たったらランダムで生成する
        if (time <= 0)
        {
            RandomRange();

            //GameObjectを上記で決まったランダムな場所に生成
            int item = Random.Range(0, goalPrefab.Length);
            Instantiate(goalPrefab[item], new Vector2(x, y), goalPrefab[item].transform.rotation);

            time = randomTime;
        }
    }
    //範囲指定
    private void RandomRange()
    {
        x = 10;

        y = Random.Range(lineMin, lineMax);
    }
}
