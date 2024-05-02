using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGController : MonoBehaviour
{
    private const float maxLength = 1f;
    private const string k_propName = "_MainTex";

    [SerializeField] private Vector2 scrollSpeed;
    [SerializeField] private Material material;

    void Start()
    {
        if (GetComponent<Image>() is Image i)
        {
            material = i.material;
        }
    }

    void Update()
    {
        if (material)
        {
            float x = Mathf.Repeat(Time.time * scrollSpeed.x, maxLength);
            Vector2 offset = new Vector2(x, 0);
            material.SetTextureOffset(k_propName, offset);
        }
    }
    private void OnDestroy()
    {
        if (material)
        {
            material.SetTextureOffset(k_propName, Vector2.zero);
        }
    }
}
