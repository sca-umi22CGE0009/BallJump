using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGoalScript : MonoBehaviour
{
    [SerializeField]
    private GameObject goalPrefab;
    [SerializeField]
    private GameObject bg;
    [SerializeField]
    private float lineMax = 3f;
    [SerializeField]
    private float lineMin = -1.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetGoal());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator SetGoal()
    {
        while (true)
        {
            Vector3 pos = new Vector3(11, Random.Range(lineMax, lineMin), 0);
            GameObject goal = Instantiate(goalPrefab, pos, transform.rotation) as GameObject;
            goal.transform.parent = bg.transform;
            //2ïbå„
            yield return new WaitForSeconds(2.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D othre)
    {
        if (othre.gameObject.name == "Player")
        {

        }
    }
}
