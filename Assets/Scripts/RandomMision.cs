using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMision : MonoBehaviour
{
    public GameObject missionCanvas;
    public GameObject buyCanvas;
    public GameObject PromoCanvas;
    public PlayerController playerController;
    public Sprite[] missionSprite;

    int rand;
    int missionNum;

    public bool missionBool;

    // Start is called before the first frame update
    void Start()
    {
        missionBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(rand == 1)
        {
            missionBool = true;
            //열려있는 창 꺼주기
            CloseOtherCanvas();
            StartRandomMission();
            rand = 0;
        }
    }

    public void GetRadomNum()
    {
        if (!missionBool)
        {
            rand = UnityEngine.Random.Range(0, 100) + 1;
        }
    }

    //미션 시작
    private void StartRandomMission()
    {
        //미션뽑기
        missionNum = UnityEngine.Random.Range(0, 3);
        missionCanvas.GetComponent<SpriteRenderer>().sprite = missionSprite[missionNum];
        missionCanvas.SetActive(true);
    }

    public int ReturnMissionResult()
    {
        //0:O 1:X 2:X
        if(missionNum == 0)
        {
            return 0;
        }
        return 1;
    }

    private void CloseOtherCanvas()
    {
        buyCanvas.SetActive(false);
        PromoCanvas.SetActive(false);
    }
}
