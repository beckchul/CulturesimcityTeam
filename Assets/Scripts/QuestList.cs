using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestList : MonoBehaviour
{
    // Start is called before the first frame update

    public bool[] QuestListCheck;
    public string[] QuestListString;
    public GameObject[] QuestListObject;
    private PlayerController PlayerControl;
    void Start()
    {
        PlayerControl = GameObject.Find("Player").gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < QuestListCheck.Length; ++i)
            QuestListCheck[i] = true;

        foreach (GameObject CulturalHeritage in PlayerControl.CulturalHeritageList)
        {
            if (CulturalHeritage.GetComponent<Tower>().level < 1)
                QuestListCheck[0] = false;

            if (CulturalHeritage.GetComponent<Tower>().level < 2)
                QuestListCheck[1] = false;

            if (CulturalHeritage.GetComponent<Tower>().level < 3)
                QuestListCheck[2] = false;

            if (MoneyManager.Instance.playerMoney < 300000)
                QuestListCheck[3] = false;
        }

        if (PlayerControl.CulturalHeritageList[0].GetComponent<Tower>().level == 0 ||
            PlayerControl.CulturalHeritageList[1].GetComponent<Tower>().level == 0)
            QuestListCheck[4] = false;


        for (int i = 0; i < QuestListCheck.Length; ++i)
        {
            if(QuestListCheck[i])   // 퀘스트 달성 시
            {
                QuestListObject[i].GetComponent<Text>().text = QuestListString[i] + "(1 / 1)";
            }
            else// 퀘스트 미 달성 시
            {
                QuestListObject[i].GetComponent<Text>().text = QuestListString[i] + "(0 / 1)";
            }
        }

        if(QuestListCheck[2] == true)
        {
            SceneManager.LoadScene(4);
        }
    }
}
