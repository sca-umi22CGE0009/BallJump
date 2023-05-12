using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField]
    private float jumping = 5.0f;
    [SerializeField]
    private float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //瞬間的にY軸にjumpingの力を加える
            rb2d.AddForce(Vector2.up * jumping, ForceMode2D.Impulse);
        }
    }
}
