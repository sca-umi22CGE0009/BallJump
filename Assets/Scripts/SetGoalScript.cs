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

        //time�b�������烉���_���Ő�������
        if (time <= 0)
        {
            RandomRange();

            //GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
            int item = Random.Range(0, goalPrefab.Length);
            Instantiate(goalPrefab[item], new Vector2(x, y), goalPrefab[item].transform.rotation);

            time = randomTime;
        }
    }
    //�͈͎w��
    private void RandomRange()
    {
        x = 10;

        y = Random.Range(lineMin, lineMax);
    }
}
