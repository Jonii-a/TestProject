//https://takaharasatoshi.com/archives/3636
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P_Monster : MonoBehaviour
{
    string P_Name;
    [HideInInspector] public int[] P_Status;
    [HideInInspector] public int P_HP;
    GameObject PName_;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        P_HP = int.Parse(GameManager.Poke_Data[0, 1]);
        P_Status = new int[5];
        P_Name = GameManager.Poke_Data[0, 0];
        for (int i = 0; i < 5; i++)
        {
            P_Status[i] = int.Parse(GameManager.Poke_Data[0, i + 1]);
        }
        PName_ = GameObject.Find("P_HP_Canvas/P_M_Name");
        PName_.GetComponent<Text>().text = P_Name;
        Debug.Log("ÉqÉgÉJÉQÇÃçUåÇóÕ" + P_Status[1]);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(P_Status[0]);
    }
}
