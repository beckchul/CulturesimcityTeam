using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region 싱글톤
    private static MoneyManager _instance = null;
    public static MoneyManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(MoneyManager)) as MoneyManager;
                if (_instance == null)
                {
                    Debug.LogError("Error MoneyManager");
                }
            }
            return _instance;
        }
    }
    #endregion
    
    public PlayerController playerController;
    public Promotion promotion;

    public Text text;
    public int playerMoney;   //플레이어의 첫 가격

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        text.text = playerMoney.ToString() + " 원";
    }


    
    
    //
    public void GetMoney(int money)     //money만큼 돈을 얻는다
    {
        //(관광객 수 - 최소 관광객) * money
        playerMoney += (promotion.people - promotion.limitpeople) + money; 
    }

    public void LoseMoney(int money)    //money만큼 돈을 잃는다
    {
        //돈을 가지고있을때
        if(playerMoney>=money)
        {
            playerMoney -= money;
        }
        //돈이 없을때 (파산)
        else
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
