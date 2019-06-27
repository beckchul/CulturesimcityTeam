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
            pretargetobject = targetobject;
            transform.FindChild("Image").gameObject.GetComponent<SpriteRenderer>().sprite = targetobject.GetComponent<Tower>().image_UI;
            if (targetobject.GetComponent<Tower>().level == 3)
                transform.FindChild("UpgradeButtorn").gameObject.SetActive(false);
        }
    }
}
