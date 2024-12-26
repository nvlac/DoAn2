using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuanLy_KD : MonoBehaviour
{
    public int HP;
    private int HPHienTai;
    public bool MiemST;
    public GameObject HieuUng1;
    public GameObject HieuUng2;
    private bool isDead = false;

    void Start()
    {
        MiemST = false;
        HPHienTai = HP;
    }

    public void NhanST()
    {
        if (MiemST) return;

        HPHienTai--;
        if (HPHienTai <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        if (HieuUng1 != null)
        {
            Instantiate(HieuUng1, transform.position, transform.rotation);
        }
        if (HieuUng2 != null)
        {
            Instantiate(HieuUng2, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

    // Kiểm tra va chạm với tag GioiHan
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu đối tượng va chạm có tag "GioiHan"
        if (collision.gameObject.CompareTag("GioiHan"))
        {
            // Xóa đối tượng này
            Destroy(gameObject);
        }
    }
}
