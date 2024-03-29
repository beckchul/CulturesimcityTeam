﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Promotion : MonoBehaviour
{
    public Text peopleText;
    public PlayerController playerController;

    public int people;
    public int limitpeople;

    public bool tv, radio, news, sns;   //tv= *4 radio= *3 news= *2 sns= *5
    int date;

    public bool tower;

    // Start is called before the first frame update
    void Start()
    {
        people = 200;       //관광객
        limitpeople = 100;  //최소관광객
        tv = false;
        radio = false;
        news = false;
        sns = false;
        tower = false;
        date = 5;
    }

    // Update is called once per frame
    void Update()
    {
        peopleText.text = people.ToString();
    }
    


    //날짜 지날때마다 관광객 수정
    public void UpdatePeople()
    {
        //홍보중인가?
        if (tv || radio || news || sns)
        {
            if (tv)
            {
                //카운트다운
                date--;
                //관광객수정
                people += playerController.ReturnLevelPeople_Promo(4);
                //
                if(date <= 0)
                {
                    date = 5;
                    //비활성화
                    tv = false;
                    playerController.OnActivePromoList();

                    //랜덤으로 거품끼던가 유지하던가
                    int rand = UnityEngine.Random.Range(0, 3);
                    if (rand <= 1)   //거품
                    {
                        int random = UnityEngine.Random.Range(0, 2);
                        if (random == 0)
                        {
                            people = people / 3;
                        }
                        else
                        {
                            people = people / 3 * 2;
                        }
                    }
                }
            }
            else if (radio)
            {
                //카운트다운
                date--;
                //관광객수정
                people += playerController.ReturnLevelPeople_Promo(3);
                if (date <= 0)
                {
                    date = 5;
                    //비활성화
                    radio = false;
                    playerController.OnActivePromoList();
                    
                    //랜덤으로 거품끼던가 유지하던가
                    int rand = UnityEngine.Random.Range(0, 3);
                    if(rand <= 1)   //거품
                    {
                        int random = UnityEngine.Random.Range(0, 2);
                        if (random == 0)
                        {
                            people = people / 3;
                        }
                        else
                        {
                            people = people / 3 * 2;
                        }
                    }
                }
            }
            else if(news)
            {
                //카운트다운
                date--;
                //관광객수정
                people += playerController.ReturnLevelPeople_Promo(2);
                if (date <= 0)
                {
                    date = 5;
                    //비활성화
                    news = false;
                    playerController.OnActivePromoList();

                    //랜덤으로 거품끼던가 유지하던가
                    int rand = UnityEngine.Random.Range(0, 3);
                    if (rand <= 1)   //거품
                    {
                        int random = UnityEngine.Random.Range(0, 2);
                        if (random == 0)
                        {
                            people = people / 3;
                        }
                        else
                        {
                            people = people / 3 * 2;
                        }
                    }
                }
            }
            else if(sns)
            {
                //카운트다운
                date--;
                //관광객수정
                people += playerController.ReturnLevelPeople_Promo(5);
                if (date <= 0)
                {
                    date = 5;
                    //비활성화
                    sns = false;
                    playerController.OnActivePromoList();

                    //랜덤으로 거품끼던가 유지하던가
                    int rand = UnityEngine.Random.Range(0, 3);
                    if (rand <= 1)   //거품
                    {
                        int random = UnityEngine.Random.Range(0, 2);
                        if (random == 0)
                        {
                            people = people / 3;
                        }
                        else
                        {
                            people = people / 3 * 2;
                        }
                    }
                }
            }
        }
        else
        {
            //건물을 방금 지었는가?
            if(tower)
            {
                people += playerController.ReturnLevelPeople_Tower();
                tower = false;
            }
            //평소인가?
            else
            {
                int rand = UnityEngine.Random.Range(0, 3);
                if (rand == 0)
                {
                    people += playerController.ReturnLevelPeople_Tower();
                }
                else
                {
                    people -= playerController.ReturnLevelPeople_Nomal();
                }
            }
        }
    }
}
