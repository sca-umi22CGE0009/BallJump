using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net.Http.Headers;

public class PlayerController : MonoBehaviour
{
    [SerializeField,Header("ジャンプ力")] private float jumping = 5.0f;
    [SerializeField,Header("ボールが落ちるときの速度")]private float posDown = 0.5f;
    float playerY;

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

        Vector2 pos = new Vector2(0, -playerY) * Time.deltaTime;
        transform.Translate(pos);
        //自由落下
        float g = 9.8f;
        playerY = g * posDown;

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
            //playerY = jumping * posDown;
        }
        if (isTouch)
        {
            StartCoroutine(totalScore());
        }
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
