using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KichHoatThapSung : MonoBehaviour
{
    public Animator anim;
    bool KichHoat;
    bool HoanThanh;
    public GameObject ThapSung;

    public float PhamVi = 12f; // Phạm vi kích hoạt
    private Transform player; // Tham chiếu tới Player

    // Use this for initialization
    void Start()
    {
        KichHoat = false;
        HoanThanh = false;
        anim = GetComponent<Animator>();
        player = FindObjectOfType<DieuKhienNhanVat>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        KichHoat = PlayerTrongPhamVi();
        anim.SetBool("KichHoat", KichHoat);
    }

    public void ChuyenDoi()
    {
        HoanThanh = true;
        if (HoanThanh)
        {
            Instantiate(ThapSung, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

    bool PlayerTrongPhamVi()
    {
        if (player == null) return false;

        float khoangCach = Vector2.Distance(transform.position, player.position);
        return khoangCach <= PhamVi;
    }
}
