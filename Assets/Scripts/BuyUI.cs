using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUI : MonoBehaviour
{
    GameObject targetobject = null;
    GameObject pretargetobject = null;

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
            pretargetobject = targetobject;
            transform.FindChild("Pictures").gameObject.GetComponent<SpriteRenderer>().sprite = targetobject.GetComponent<Tower>().image_UI;
            if (targetobject.GetComponent<Tower>().level == 3)
                transform.FindChild("UpgradeButton").gameObject.SetActive(false);
            pretargetobject = null; 
        }
    }
}
