using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net.Http.Headers;

public class PlayerController : MonoBehaviour
{
    [SerializeField,Header("ジャンプ力")] private float jumping = 1.0f;
    [SerializeField,Header("ボールが落ちるときの速度")]private float posDown = 1f;
    float playerY;
    float playerPosY;
    float beforePos;
    float speedAfter;
    float speedBefore;
    [SerializeField, Header("床のobj")] private GameObject groundObj;

    [SerializeField,Header("シーン遷移するときの時間")] private float sceneTime;
    [SerializeField,Header("スコアのUI")] private Text countText;

    private bool isTouch;
    private bool isPush;
    public static int score;

    public static int GetScore()
    {
        return score;
    }
    void Start()
    {
        isTouch = false;
        isPush = false;
        sceneTime = 1.5f;
        score = 0;
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        //反発係数
        //float vA = 10;
        //float vB = 8;
        //float e;
        //e = vB / vA;

        //自由落下
        float g = 9.8f;
        playerY = g * -posDown;

        if (!isPush)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPush = true;
            playerPosY = this.transform.position.y;

            beforePos = groundObj.transform.position.y - playerPosY;
            float afterPos = 2 / beforePos;
            Debug.Log(beforePos);
            //元の速さ
            speedBefore = (jumping * playerY * beforePos) / 2;
            //後の速さ
            speedAfter = speedBefore + afterPos;
            playerY = speedAfter;
        }
        if (isTouch)
        {
            StartCoroutine(totalScore());
        }

        Vector2 pos = new Vector2(0, playerY) * Time.deltaTime;
        transform.Translate(pos);

    }
    //sceneTime秒後シーン遷移
    private IEnumerator totalScore()
    {
        yield return new WaitForSeconds(sceneTime);
        SceneManager.LoadScene("Score");
    }
    //ゴールにふれたらスコア加算
    private void OnTriggerEnter2D(Collider2D othre)
    {
        if (othre.gameObject.tag == "item")
        {
            score = score + 1;
            SetCountText();
        }
        if (othre.gameObject.tag == "GoldGoal")
        {
            score = score + 3;
            SetCountText();
        }
    }
    //GameOverタグに当たったらシーン遷移
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "GameOver")
        {
            isTouch = true;
        }
    }
    // UI の表示を更新する
    void SetCountText()
    {
        // スコアの表示を更新
        countText.text = score.ToString();
    }
}
