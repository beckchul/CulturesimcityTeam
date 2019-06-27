using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Promotion promotion;

    public int endpeople;   //감소하는 최대인원수
    public int price;       //문화재 업그레이드 가격
    public int level;       //레벨

    public Sprite image_UI;
    public Sprite image_Background;

    private SpriteRenderer render;

    void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        promotion = GameObject.Find("PromotionManager").GetComponent<Promotion>();
    }
    public int LevelUp()
    {
        if (level >= 3)
        {
            Debug.Log("업그레이드 불가능");
            return level;
        }
        ++level;
        //가격올라가기전에 돈빼주기
        MoneyManager.Instance.LoseMoney(price);
        Debug.Log(price + "원으로 업그레이드");
<<<<<<< HEAD
        //건물을 방금 지음
        promotion.tower = true;
        price += 50000;
        render.sprite = image_Background[level - 1];
=======
        //
        towermoney += 300;
        price += 200;
        free += 200;
        GetComponent<SpriteRenderer>().sprite = image_Background;
        return level;
>>>>>>> 3aa3b3898d71b6f36858fadd3da321c05d30982a
    }

    void Update()
    {
        
    }
}
