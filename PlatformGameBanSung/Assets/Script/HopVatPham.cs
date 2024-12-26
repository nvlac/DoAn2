using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopVatPham : MonoBehaviour
{
    public Animator anim;
    private bool DaDong;
    private float KhoangCach;
    public float PhamVi;

    private DieuKhienNhanVat player; // Tham chiếu đến nhân vật
    private QuanLy_KD quanLyKD;      // Tham chiếu đến script QuanLy_KD

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<DieuKhienNhanVat>();
        quanLyKD = GetComponent<QuanLy_KD>();

    }
    void Update()
    {
        if (anim == null || player == null )
        {
            return; 
        }

        anim.SetBool("DaDong", DaDong);
        KhoangCach = transform.position.x - player.transform.position.x;
        DaDong = KhoangCach > PhamVi || KhoangCach < -PhamVi;
        quanLyKD.MiemST = DaDong;
    }
}
