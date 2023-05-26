using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField]
    private float jumping = 5.0f;
    [SerializeField]
    private GameObject cube;
    [SerializeField]
    private Text countText;

    private bool isTouch;
    public static int score;

    private float speed = 4;
    private float time;

    public static int GetScore()
    {
        return score;
    }
    void Start()
    {
        isTouch = false;
        score = 0;
        rb2d = GetComponent<Rigidbody2D>();
       
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTouch)
        {
            Destroy(cube, 1f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //削除
                Destroy(cube);
                //瞬間的にY軸にjumpingの力を加える
                rb2d.AddForce(Vector2.up * jumping, ForceMode2D.Impulse);
            }
        }
        if (isTouch)
        {
            time += Time.deltaTime; 
            if(time > 1.5f)
            {
                SceneManager.LoadScene("Score");
            }
        }
    }
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
