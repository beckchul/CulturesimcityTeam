using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyUI : MonoBehaviour
{
    GameObject targetobject = null;
    GameObject pretargetobject = null;
    public GameObject canvas;

    void Start()
    {
    }


    public void setTarget(GameObject target)
    {
        targetobject = target;
    }

    void Update()
    {
        if (!gameObject.active)
            return;
        if (pretargetobject != targetobject)
        {
            transform.FindChild("UpgradeButton").gameObject.SetActive(true);
            transform.FindChild("Pictures").gameObject.GetComponent<SpriteRenderer>().sprite = targetobject.GetComponent<Tower>().image_UI;
            if (targetobject.GetComponent<Tower>().level == 3)
                transform.FindChild("UpgradeButton").gameObject.SetActive(false);

            canvas.transform.FindChild("Text").gameObject.GetComponent<Text>().text = targetobject.GetComponent<Tower>().subText;
            canvas.transform.FindChild("Title").gameObject.GetComponent<Text>().text = targetobject.GetComponent<Tower>().TitleText;
            pretargetobject = null;
        }
    }
}
