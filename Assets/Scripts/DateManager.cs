using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateManager : MonoBehaviour
{
    public RandomMision randomMision;
    public Text dateText;
    public PlayerController playerController;
    public Promotion promotion;

    private float time;
    private float timeinit = 4f;//1일 = 5초

    private bool timer = true;  //false면 time초기화해주고 날짜를 하루 지나게
    public int month, day;      

    // Start is called before the first frame update
    void Start()
    {
        month = 1;
        day = 1;
        time = timeinit;
        UpdateDate();
    }

    // Update is called once per frame
    void Update()
    {
        if (!timer)
        {
            if (day < 30)       //한달 30일
            {
                day++;
                UpdateDate();
                MoneyManage();
            }
            else
            {
                month++;
                day = 1;
                UpdateDate();
                MoneyManage();
            }
            timer = true;
        }
        time -= Time.deltaTime;

        //타이머 꺼주기
        if (time < 0f)
        {
            timer = false;
        }
    }

    private void MoneyManage()  //날짜가 지날때마다 발생
    {
        randomMision.GetRadomNum();
        promotion.UpdatePeople();
        MoneyManager.Instance.GetMoney(playerController.ReturnTowerMoney());   //건물비용 획득
    }

    void UpdateDate()   //날짜갱신
    {
        time = timeinit;
        dateText.text = month + "월" + day + "일";
    }
}
