using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public int price;
    public int free;
    public int level = 1;

    public Sprite image_UI;
    public Sprite[] image_Background;

    private SpriteRenderer render;

    void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }
    public void LevelUp()
    {
        if (level >= 3)
            return;
        ++level;
        price += 200;
        free += 200;
        render.sprite = image_Background[level - 1];
    }

    void Update()
    {
        
    }
}
