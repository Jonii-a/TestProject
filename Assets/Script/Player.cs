//https://qiita.com/engr_murao/items/bf377ffd53ee936f1557
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isMoving;
    public float moveSpeed;

    BoxCollider2D boxCollider;
    Rigidbody2D rb2D;
    int blockingLayer;
    public LayerMask Wall;
    Animator GetAnimator;
    bool MO = true;
    float Hori;
    float Val;
    float Speed = 0.1f;
    float RB_Speed = 2f;
    [SerializeField] Sprite[] dir_Sprite;
    Sprite GetSprite;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        GetSprite = GetComponent<SpriteRenderer>().sprite;
        GetAnimator = GetComponent<Animator>();
        // blockingLayer = LayerMask.GetMask("Wall");
    }
    enum P_Mode
    {
        F_IDOL,
        S_IDOL,
        F_WALK,
        S_WALK
    }
    P_Mode P_MODE = P_Mode.F_IDOL;

    void I_R_Anime()
    {
        if (P_MODE == P_Mode.F_IDOL)
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
        if (P_MODE == P_Mode.S_IDOL)
        {
            GetAnimator.SetBool("isFront", false);
            GetAnimator.SetBool("isSide", false);
            GetSprite = dir_Sprite[1];
        }
    }

    void RunDirection()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            P_MODE = P_Mode.F_WALK;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            P_MODE = P_Mode.S_WALK;
        }
        else
        {

        }
    }
    void IdleDirection()
    {

    }



    void Update()
    {
        if (isMoving)
            RunDirection();
        I_R_Anime();
        // 移動中は処理しない
        if (isMoving) return;

        // 縦横の入力を受け取る
        int horizontal = (int)Input.GetAxisRaw("Horizontal");
        int vertical = (int)Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
            vertical = 0;
        if (horizontal != 0 || vertical != 0)
        {
            // 移動を開始する
            Move(horizontal, vertical, out RaycastHit2D hit);
        }
    }

    protected bool Move(int xDir, int yDir, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);

        // デバッグ用にRayを描画
        Debug.DrawRay(start, new Vector2(xDir, yDir), Color.white, 5);

        //boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, Wall);
        //hit = Physics2D.Linecast(start, end, blockingLayer);
        boxCollider.enabled = true;

        // 衝突しておらず、移動中でなく
        if (hit.collider == null && !isMoving)
        {
            // 滑らかな移動を開始
            StartCoroutine(SmootMovement(end));
            return true;
        }
        return false;
    }

    protected IEnumerator SmootMovement(Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        isMoving = true;

        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, moveSpeed * Time.deltaTime);
            rb2D.MovePosition(newPosition);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }
        isMoving = false;
    }
}
