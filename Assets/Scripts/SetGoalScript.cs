using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGoalScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] goalPrefab;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float lineMax = 3f;
    [SerializeField]
    private float lineMin = -1.5f;

    private float time;

    private float player_x; //�v���C���[��x��

    private float x;
    private float y;

    private float speed = -5;
    int count;

    private void RandomRange()
    {
        x = Random.Range(transform.position.x, x);

        y = Random.Range(lineMin, lineMax);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        //�O�t���[������̎��Ԃ����Z���Ă���
        time += Time.deltaTime;

        if (time >= 4)
        {
            RandomRange();

            //GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
            int item = Random.Range(0, goalPrefab.Length);
            Instantiate(goalPrefab[item], new Vector2(2 + player_x, y), goalPrefab[item].transform.rotation);

            //�o�ߎ��Ԃ̏�����
            time = 0.0f;
            count++;
        }
        if (count >= 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D othre)
    {
        if (othre.gameObject.tag == "item")
        {
            Destroy(gameObject);
        }
    }
}
