using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KD_CanChien : MonoBehaviour
{
    private bool TrenMatDat;
    public Transform MatDatSensor;

    private bool cliffAhead;
    public Transform cliffSensor;

    public LayerMask MatDat;

    private Rigidbody2D Rb2D;
    private Animator myAnimator;

    public float TocDoChay;
    public float LucNhay;

    private bool reacted;

    public float PhamVi = 15f; // Phạm vi hoạt động
    private Transform player; // Tham chiếu tới Player


    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        player = FindObjectOfType<DieuKhienNhanVat>().transform;
    }

    void Update()
    {
        if (PlayerTrongPhamVi())
        {
            // Kiểm tra nếu kẻ địch trên mặt đất và trước mặt không có vực thẳm
            TrenMatDat = Physics2D.OverlapCircle(MatDatSensor.position, 0.1f, MatDat);
            cliffAhead = !Physics2D.OverlapCircle(cliffSensor.position, 0.1f, MatDat);

            if (TrenMatDat && cliffAhead && !reacted)
            {
                ReactToCliff(Random.Range(0, 3));
            }

            if (TrenMatDat && !cliffAhead && reacted)
            {
                reacted = false;
            }

            // Di chuyển trái/phải
            Rb2D.velocity = new Vector2(TocDoChay * transform.localScale.x, Rb2D.velocity.y);
            myAnimator.SetBool("TrenMatDat", TrenMatDat);
        }
        else
        {
            // Không di chuyển nếu Player không trong phạm vi
            Rb2D.velocity = new Vector2(0, Rb2D.velocity.y);
            myAnimator.SetBool("TrenMatDat", false);
        }
    }

    bool PlayerTrongPhamVi()
    {
        if (player == null) return false;

        float khoangCach = Vector2.Distance(transform.position, player.position);
        return khoangCach <= PhamVi;
    }

    void ReactToCliff(float r)
    {
        if (r == 0)
        {
            Rb2D.velocity = new Vector2(Rb2D.velocity.x, LucNhay);
        }
        if (r == 1)
        {
            Rb2D.velocity = new Vector2(Rb2D.velocity.x, LucNhay / 3);
        }
        if (r > 1)
        {
            Rb2D.velocity = new Vector2(0, Rb2D.velocity.y);
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        }
        reacted = true;
    }
}
