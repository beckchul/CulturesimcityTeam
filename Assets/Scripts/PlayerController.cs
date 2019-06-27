using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] CulturalHeritageList;
    private GameObject target;
    private GameObject BuyUIObject;
    private GameObject UpgradeObject;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    void Start()
    {
        BuyUIObject = GameObject.Find("BuyUI").gameObject;
        BuyUIObject.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ClickCheck();   
    }

    private void ClickCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
            if (!target)
            {
                BuyUIObject.SetActive(false);
                return;
            }
            else if (target.tag == "Point" && !BuyUIObject.active)
            {
                foreach (GameObject CulturalHeritage in CulturalHeritageList)
                {
                    if (CulturalHeritage.gameObject == target.gameObject)
                    {
                        UpgradeObject = target.gameObject;
                        BuyUIObject.SetActive(true);
                        BuyUIObject.GetComponent<BuyUI>().setTarget(target.gameObject);
                    }
                }
            }
            else if (target.tag == "UpgradeUI")
            {
                UpgradeObject.GetComponent<Tower>().LevelUp();
                BuyUIObject.SetActive(false);
            }
        }
    }

    void CastRay() // 유닛 히트처리 부분.  레이를 쏴서 처리합니다. 
    {
        target = null;
        Vector2 pos = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null)
        {
            target = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정
        }
    }


    //건물버는가격받아오기
    public int ReturnTowerMoney()
    {
        int value = 0;
        foreach (GameObject CulturalHeritage in CulturalHeritageList)
        {
            value += CulturalHeritage.GetComponent<Tower>().towermoney;
            Debug.Log(CulturalHeritage.name + "건물비" + CulturalHeritage.GetComponent<Tower>().towermoney);
        }
        return value;
    }
    //건물관리비받아오기
    public int ReturnTowerFree()
    {
        int value = 0;
        foreach (GameObject CulturalHeritage in CulturalHeritageList)
        {
            value += CulturalHeritage.GetComponent<Tower>().free;
            Debug.Log(CulturalHeritage.name + "관리비" + CulturalHeritage.GetComponent<Tower>().free);
        }
        return value;
    }
}
