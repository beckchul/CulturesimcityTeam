using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int towermoney;  //날짜마다 얻는 가격
    public int price;       //문화재 업그레이드 가격
    public int free;        //문화재 관리비
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
        {
            Debug.Log("업그레이드 불가능");
            return;
        }
        ++level;
        Debug.Log(price + "원으로 업그레이드");
        //가격올라가기전에 돈빼주기
        MoneyManager.Instance.LoseMoney(price);
        Debug.Log(price + "원으로 업그레이드");
        //
        towermoney += 300;
        price += 200;
        free += 200;
        render.sprite = image_Background[level - 1];
    }

    void Update()
    {
        
    }
}
