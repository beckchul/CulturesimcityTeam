using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Promotion promotion;

    public GameObject[] CulturalHeritageList;
    private GameObject target;
    private GameObject BuyUIObject;
    private GameObject PromoUIObject;
    private GameObject UpgradeObject;

    public GameObject[] btnlist;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    void Start()
    {
        BuyUIObject = GameObject.Find("BuyUI").gameObject;
        PromoUIObject = GameObject.Find("PromotionUI").gameObject;
        BuyUIObject.SetActive(false);
        PromoUIObject.SetActive(false);
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

            #region 문화재 클릭 & 업그레이드 & 닫기
            if (!target)
            {
                BuyUIObject.SetActive(false);
                PromoUIObject.SetActive(false);
                return;
            }
            else if (target.tag == "Point" && !BuyUIObject.active && !PromoUIObject.active)
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

            //
            else if (target.tag == "UpgradeUI")
            {
<<<<<<< HEAD
                UpgradeObject.GetComponent<Tower>().LevelUp();
=======
                Debug.Log("?");
                int Level = UpgradeObject.GetComponent<Tower>().LevelUp();
                UpgradeObject.transform.localScale = new Vector3(0.2f + Level * 0.05f, 0.2f + Level * 0.05f, 1.0f);
>>>>>>> 3aa3b3898d71b6f36858fadd3da321c05d30982a
                BuyUIObject.SetActive(false);
            }
            else if (target.tag == "CloseUI")
            {
                BuyUIObject.SetActive(false);
                PromoUIObject.SetActive(false);
                return;
            }
            //
            #endregion

            #region 홍보관련
            //
            else if (target.tag == "PromotionUI" && !BuyUIObject.active)
            {
                PromoUIObject.SetActive(true);
            }

            //홍보버튼클릭
            else if (target.tag == "PromotionStartBtn")
            {
                if (target.gameObject.name == "PromoBtn_TV")
                {
                    //돈차감
                    MoneyManager.Instance.LoseMoney(30000);
                    //활성화
                    promotion.tv = true;
                    PromoUIObject.SetActive(false);
                }
                else if (target.gameObject.name == "PromoBtn_Radio")
                {
                    //돈차감
                    MoneyManager.Instance.LoseMoney(20000);
                    //활성화
                    promotion.radio = true;
                    PromoUIObject.SetActive(false);
                }
                else if(target.gameObject.name == "PromoBtn_News")
                {
                    //돈차감
                    MoneyManager.Instance.LoseMoney(10000);
                    //활성화
                    promotion.news = true;
                    PromoUIObject.SetActive(false);
                }
                else if(target.gameObject.name == "PromoBtn_SNS")
                {
                    //돈차감
                    MoneyManager.Instance.LoseMoney(50000);
                    //활성화
                    promotion.sns = true;
                    PromoUIObject.SetActive(false);
                }
                
                //버튼 전체 비활성화
                foreach(GameObject item in btnlist)
                {
                    item.SetActive(false);
                }
            }
            #endregion
        }
    }

    public void OnActivePromoList()
    {
        foreach (GameObject item in btnlist)
        {
            item.SetActive(true);
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



    public int ReturnLevelPeople_Nomal()
    {
        int num = 0;
        foreach (GameObject CulturalHeritage in CulturalHeritageList)
        {
            if (CulturalHeritage.GetComponent<Tower>().level == 1)
            {
                num += CulturalHeritage.GetComponent<Tower>().endpeople /3; //5
            }
            else if (CulturalHeritage.GetComponent<Tower>().level == 2)
            {
                num += CulturalHeritage.GetComponent<Tower>().endpeople / 6;   //10
            }
            else if (CulturalHeritage.GetComponent<Tower>().level == 3)
            {
                num += CulturalHeritage.GetComponent<Tower>().endpeople /10;    //20
            }
        }
        return num;
    }
    public int ReturnLevelPeople_Tower()
    {
        int num = 0;
        foreach (GameObject CulturalHeritage in CulturalHeritageList)
        {
            if (CulturalHeritage.GetComponent<Tower>().level == 1)
            {
                num += CulturalHeritage.GetComponent<Tower>().endpeople /3;
            }
            else if (CulturalHeritage.GetComponent<Tower>().level == 2)
            {
                num += CulturalHeritage.GetComponent<Tower>().endpeople / 2;
            }
            else if (CulturalHeritage.GetComponent<Tower>().level == 3)
            {
                num += CulturalHeritage.GetComponent<Tower>().endpeople;
            }
        }
        return num;
    }
    public int ReturnLevelPeople_Promo(int value)
    {
        int num = 0;
        foreach (GameObject CulturalHeritage in CulturalHeritageList)
        {
            if (CulturalHeritage.GetComponent<Tower>().level == 1)
            {
                num += CulturalHeritage.GetComponent<Tower>().endpeople * value /3;
            }
            else if (CulturalHeritage.GetComponent<Tower>().level == 2)
            {
                num += CulturalHeritage.GetComponent<Tower>().endpeople * value / 2;
            }
            else if (CulturalHeritage.GetComponent<Tower>().level == 3)
            {
                num += CulturalHeritage.GetComponent<Tower>().endpeople * value;
            }
        }
        return num;
    }



    // 건물 레벨 받아오기
    List<int> TowerLevelList()
    {
        int level1 = 0;
        int level2 = 0;
        int level3 = 0;
        foreach (GameObject CulturalHeritage in CulturalHeritageList)
        {
            if(CulturalHeritage.GetComponent<Tower>().level == 1)
            {
                ++level1;
            }
            else if (CulturalHeritage.GetComponent<Tower>().level == 2)
            {
                ++level2;
            }
            else if (CulturalHeritage.GetComponent<Tower>().level == 3)
            {
                ++level3;
            }
        }
        List<int> list = new List<int>();
        list.Add(level1);
        list.Add(level2);
        list.Add(level3);
        return list;

    }
    
    //레벨비율에 맞춰서 돈벌기
    public int ReturnTowerMoney()
    {
        List<int> levellist = TowerLevelList();

        return (levellist[0] * 1) + (levellist[1] * 2) + (levellist[2] * 3);
    }
    
}
