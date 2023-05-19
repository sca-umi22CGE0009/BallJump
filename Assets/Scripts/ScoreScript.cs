using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField]
    private Text ScoreText;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerController.getscore();
        ScoreText.text = string.Format("Score {0}‰ñ", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
