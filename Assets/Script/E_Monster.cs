using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E_Monster : MonoBehaviour
{
    string E_Name;
    [HideInInspector] public int[] E_Status;
    GameObject EName_;
    [HideInInspector] public int E_HP;
    GameObject B_Manager;
    // Start is called before the first frame update
    void Start()
    {
        B_Manager = GameObject.Find("Gamemanager");
        E_HP = int.Parse(GameManager.Poke_Data[1, 1]);
        E_Status = new int[5];
        E_Name = GameManager.Poke_Data[1, 0];
        for (int i = 0; i < 5; i++)
        {
            E_Status[i] = int.Parse(GameManager.Poke_Data[1, i + 1]);
        }
        EName_ = GameObject.Find("E_HP_Canvas/E_M_Name");
        EName_.GetComponent<Text>().text = E_Name;
        Debug.Log("ÉrÅ[ÉhÉãÇÃñhå‰óÕ" + E_Status[2]);
    }
/*
    void E_War()
    {
        isP_Mon.GetComponent<E_Monster>().E_HP -=
    isP_Mon.GetComponent<P_Monster>().P_Status[1] - isE_Mon.GetComponent<E_Monster>().E_Status[2];
        GameObject.Find("E_HP_Canvas/Slider").GetComponent<Slider>().value =
        isE_Mon.GetComponent<E_Monster>().E_HP;
        P_Turn = false;
    }
*/
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(P_Status[0]);
    }
}
