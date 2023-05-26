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

        //�O�t���[������̎��Ԃ����Z���Ă���
        time += Time.deltaTime;

        if (time >= 2.5f)
        {
            RandomRange();

            //GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
            int item = Random.Range(0, goalPrefab.Length);
            Instantiate(goalPrefab[item], new Vector2(x, y), goalPrefab[item].transform.rotation);

            //�o�ߎ��Ԃ̏�����
            time = 0.0f;
        }
    }
}
