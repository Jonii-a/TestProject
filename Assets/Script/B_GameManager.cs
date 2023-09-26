using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B_GameManager : MonoBehaviour
{

    GameObject CurSor;
    GameObject isP_Mon;
    GameObject isE_Mon;
    public bool P_Turn = true;
    GameObject HPBar;
    // Start is called before the first frame update
    void Start()
    {
        HPBar = GameObject.Find("HPBar");
        CurSor = GameObject.Find("KommandCanvas/WAR/Cursor");
        isP_Mon = GameObject.Find("P_Monster");
        isE_Mon = GameObject.Find("E_Monster");
        HPBar.transform.GetChild(1).transform.GetChild(1).GetComponent<Slider>().maxValue=
        isE_Mon.GetComponent<E_Monster>().E_Status[0];
        HPBar.transform.GetChild(1).transform.GetChild(1).gameObject.GetComponent<Slider>().value =
        isE_Mon.GetComponent<E_Monster>().E_Status[0];
        OnRectTransformRemovd();
    }

    private void OnRectTransformRemovd()
    {
        HPBar.transform.Find("P_HP_Canvas/Slider").GetComponent<Slider>().maxValue =
        isP_Mon.GetComponent<P_Monster>().P_Status[0];
        HPBar.transform.Find("P_HP_Canvas/Slider").GetComponent<Slider>().value =
        isP_Mon.GetComponent<P_Monster>().P_HP;
        Debug.Log("a");
    }

    void P_War()
    {
        isE_Mon.GetComponent<E_Monster>().E_HP -=
            isP_Mon.GetComponent<P_Monster>().P_Status[1] - isE_Mon.GetComponent<E_Monster>().E_Status[2];
        GameObject.Find("E_HP_Canvas/Slider").GetComponent<Slider>().value =
        isE_Mon.GetComponent<E_Monster>().E_HP;
        P_Turn = false;
        E_War();
    }

    void E_War()
    {
        //Debug.Log("てきのこうげき");
        isP_Mon.GetComponent<P_Monster>().P_HP -=
    isE_Mon.GetComponent<E_Monster>().E_Status[1];
        HPBar.transform.Find("P_HP_Canvas/Slider").GetComponent<Slider>().value =
        isP_Mon.GetComponent<P_Monster>().P_HP;
        P_Turn = true;
    }

    public void Item()
    {
        P_Turn = false;
    }

    public void Party()
    {

    }

    public void Escape()
    {

    }

    public void Kommand_Kol()
    {
        if (CurSor.GetComponent<Cursor>()._Sel == Cursor.Kommand_Sel.WAR)
        {
            Debug.Log("たたかう");
            P_War();
        }
        if (CurSor.GetComponent<Cursor>()._Sel == Cursor.Kommand_Sel.ITEM)
        {
            Debug.Log("アイテム");
        }
        if (CurSor.GetComponent<Cursor>()._Sel == Cursor.Kommand_Sel.PARTY)
        {
            Debug.Log("パーティー");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Kommand_Kol();
        //Debug.Log(isE_Mon.GetComponent<E_Monster>().E_HP);
        //Debug.Log(isE_Mon.GetComponent<E_Monster>().E_HP * isE_Mon.GetComponent<E_Monster>().E_Status[0] / 100);
        //Debug.Log(isP_Mon.GetComponent<P_Monster>().P_Status[0]);
        //Debug.Log(isP_Mon.GetComponent<P_Monster>().P_HP);
    }
}
 