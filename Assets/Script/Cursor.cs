using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    GameObject cursor;
    RectTransform c_Rect;
    Vector2 c_Pos;
    bool isRight = false;
    GameObject gameManager;
    bool Limit = true;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Gamemanager");
        c_Rect = GetComponent<RectTransform>();

        c_Pos = new Vector2(-206, 26);

    }

    public enum Kommand_Sel
    {
        WAR,
        ITEM,
        PARTY,
        ESCAPE
    }
    public Kommand_Sel _Sel = Kommand_Sel.WAR;

    void Kommand()
    {
        /*        if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.SetParent(GameObject.Find("KommandCanvas/ITEM").transform);
                    _Sel = Kommand_Sel.ITEM;
                    c_Rect.anchoredPosition = c_Pos;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.SetParent(GameObject.Find("KommandCanvas/PARTY").transform);
                    _Sel = Kommand_Sel.PARTY;
                    c_Rect.anchoredPosition = c_Pos;
                }
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow))
                {
                    transform.SetParent(GameObject.Find("KommandCanvas/WAR").transform);
                    _Sel = Kommand_Sel.WAR;
                    c_Rect.anchoredPosition = c_Pos;
                }
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    gameManager.GetComponent<B_GameManager>().Kommand_Kol();
                }*/
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            for(int i = 0; i < 70; i++)
            {
                
                transform.position += new Vector3(1f,0,0);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            for (int i = 0; i < 70; i++)
            {
                transform.position += new Vector3(0, -1f, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            for (int i = 0; i < 70; i++)
            {
                transform.position += new Vector3(-1f, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            for (int i = 0; i < 70; i++)
            {
                transform.position += new Vector3(0, 1f, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameManager.GetComponent<B_GameManager>().Kommand_Kol();
        }
    }

    void CurSor_Move()
    {

        if (Limit)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                GetComponent<Rigidbody2D>().velocity += new Vector2(10, 0);
                //transform.position += new Vector3(2f, 0, 0);
                //yield return null;

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                transform.position += new Vector3(0, -1, 0);

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                transform.position += new Vector3(-2f, 0, 0);

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                transform.position += new Vector3(0, 1f, 0);


            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameManager.GetComponent<B_GameManager>().Kommand_Kol();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag == "Item")
            Debug.Log("Item");*/
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        transform.SetParent(collision.gameObject.transform);
        c_Rect.anchoredPosition = c_Pos;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Kursor_Max")
        {
            Limit = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Kursor_Max")
        {
            Limit = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        CurSor_Move();
        //Kommand();
    }
}
