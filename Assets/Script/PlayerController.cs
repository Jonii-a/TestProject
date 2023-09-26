
//https://qiita.com/_tybt/items/bc9c3be75c04ab547c35
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    Animator GetAnimator;
    bool MO = true;
    float Hori;
    float Val;
    float Speed = 0.1f;
    float RB_Speed = 2f;
    [SerializeField] Sprite[] dir_Sprite;
    RaycastHit2D Val_ray;
    RaycastHit2D Hori_ray;
    Sprite GetSprite;
    Rigidbody2D rb2d;
    Physics2D Val_Line;
    public LayerMask Wall;
    Vector2[] Line_Vec_val;
    public BoxCollider2D Main_BC;
    public BoxCollider2D Sub_BC;
    // Start is called before the first frame update
    void Start()
    {
        Line_Vec_val = new Vector2[2];
        Line_Vec_val[0] = new Vector2(transform.position.x, transform.position.y - 0.9f);
        Line_Vec_val[1] = new Vector2(transform.position.x, transform.position.y + 0.5f);
        rb2d = GetComponent<Rigidbody2D>();
        GetSprite = GetComponent<SpriteRenderer>().sprite;
        GetAnimator = GetComponent<Animator>();
        StartCoroutine(IsMove());
    }

    enum P_Mode
    {
        F_IDOL,
        S_IDOL,
        F_WALK,
        S_WALK
    }
    P_Mode P_MODE = P_Mode.F_IDOL;

    IEnumerator IsMove()
    {
        while (true)
        {
            if (MO == true)
            {
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
                {
                    //P_MODE = P_Mode.WALK;
                    if (Hori == 0 || Val == 0)
                    {
                        if (Hori > 0)
                        {
                            transform.localScale = new Vector3(1, 1, 1);
                            P_MODE = P_Mode.S_WALK;
                            rb2d.velocity = new Vector2(RB_Speed,0);
                            yield return new WaitForSeconds(0.5f);
                            rb2d.velocity = new Vector2(0, 0);
                            P_MODE = P_Mode.S_IDOL;

                        }
                        if (Hori < 0)
                        {
                            transform.localScale = new Vector3(-1, 1, 1);
                            P_MODE = P_Mode.S_WALK;
                            rb2d.velocity = new Vector2(-RB_Speed, 0);
                            yield return new WaitForSeconds(0.5f);
                            rb2d.velocity = new Vector2(0, 0);
                            P_MODE = P_Mode.S_IDOL;
                        }

                        if (Val > 0)
                        {
                            P_MODE = P_Mode.F_WALK;
                            rb2d.velocity = new Vector2(0, RB_Speed);
                            yield return new WaitForSeconds(0.5f);
                            rb2d.velocity = new Vector2(0, 0);
                            P_MODE = P_Mode.F_IDOL;
                        }

                        if (Val < 0)
                        {
                            P_MODE = P_Mode.F_WALK;
                            rb2d.velocity = new Vector2(0, -RB_Speed);
                            yield return new WaitForSeconds(0.5f);
                            rb2d.velocity = new Vector2(0, 0);
                            P_MODE = P_Mode.F_IDOL;
                        }

                    }
                    else
                    {
                        //MO = false;
                    }
                }
            }
            yield return null;
        }

    }

    void I_R_Anime()
    {
        if(P_MODE == P_Mode.F_IDOL)
        {
            GetAnimator.SetBool("isFront", false);
            GetAnimator.SetBool("isSide", false);
            GetSprite = dir_Sprite[0];
        }
        if (P_MODE == P_Mode.F_WALK)
        {
            GetAnimator.SetBool("isFront", true);
        }
        if (P_MODE == P_Mode.S_WALK)
        {
            GetAnimator.SetBool("isSide", true);
        }
        if(P_MODE == P_Mode.S_IDOL)
        {
            GetAnimator.SetBool("isFront", false);
            GetAnimator.SetBool("isSide", false);
            GetSprite = dir_Sprite[1];
        }
    }

    void Running()
    {
        if(Input.GetKey(KeyCode.X))
        {
            RB_Speed = 4;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Buttle")
        {
            SceneManager.LoadScene("ButtleScene");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
/*        if (Sub_BC.gameObject.tag == "Wall")
            Debug.Log("aa");*/
    }

    // Update is called once per frame
    void Update()
    {
        /*        RaycastHit2D Underhit = Physics2D.Linecast(
                    isRight, isLeft,// 終点
                    groundLayer);

                Righthit = Physics2D.Linecast(
                isRight, isTop,// 終点
                groundLayer);
                Lefthit = Physics2D.Linecast(
                isLeft, isTop,// 終点
                groundLayer);
                if (Righthit.collider || Lefthit.collider)
                {
                    Debug.Log("a");
                    GetAudio.volume = 1f;
                    GetAudio.PlayOneShot(EnemyDmage);
                    //Destroy(hit);
                    //  処理を書く。
                }*/
        Val_ray = Physics2D.Linecast(
            new Vector3(transform.position.x, transform.position.y - 0.9f, transform.position.z),
            new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z)
            , Wall
        ) ;
        Hori_ray = Physics2D.Linecast(
            new Vector3(transform.position.x - 0.7f, transform.position.y - 0.25f, transform.position.z),
            new Vector3(transform.position.x + 0.7f, transform.position.y - 0.25f, transform.position.z),
            Wall
            );
        if(Val_ray.collider || Hori_ray.collider)
        {
            Debug.Log("c");
        }
        // Physics.Linecast()
       /* Val_Line = Physics2D.Linecast
            (Line_Vec_val[0],
            Line_Vec_val[1], Wall
            )
       */
       
        Debug.DrawLine(new Vector3(transform.position.x, transform.position.y - 0.9f, transform.position.z),
            new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z),color:Color.white);
        Debug.DrawLine(new Vector3(transform.position.x-0.7f, transform.position.y-0.25f, transform.position.z),
            new Vector3(transform.position.x+0.7f, transform.position.y-0.25f, transform.position.z), color: Color.white);
        //Running();
        transform.localScale = new Vector3(transform.localScale.x, 0.7777f, transform.localScale.z);
        Hori = Input.GetAxis("Horizontal");
        Val = Input.GetAxis("Vertical");
       /* if (Hori <= 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }*/
        I_R_Anime();
    }
}
