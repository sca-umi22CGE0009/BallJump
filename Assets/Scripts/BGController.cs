using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    [SerializeField]
    private GameObject goalPrefab;
    [SerializeField]
    private GameObject bg;
    [SerializeField]
    private float speed = 4;
    [SerializeField]
    private Camera camera;

    void Start()
    {
        StartCoroutine(MoveBg());
        StartCoroutine(SetGoal());
    }

    void Update()
    {
        camera.transform.position -= new Vector3(5.0f * Time.deltaTime, 0, 0);
    }
    IEnumerator SetGoal()
    {
        while (true)
        {
            Vector3 pos = new Vector3(11,Random.Range(3f,-1.5f),0);
            GameObject goal = Instantiate(goalPrefab, pos, transform.rotation) as GameObject;
            goal.transform.parent = bg.transform;
            yield return new WaitForSeconds (2.0f);
        }
    }
    IEnumerator MoveBg()
    {
        while (true)
        {
            Vector3 pos = bg.transform.position;
            pos.x -= speed * Time.deltaTime;
            bg.transform.position = pos;
            yield return 0;

        }
    }
}
