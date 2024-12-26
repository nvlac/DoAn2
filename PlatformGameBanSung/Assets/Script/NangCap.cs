using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NangCap : MonoBehaviour
{
    public int type;
    public float DoCao;
    private void Start()
    {
        GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * DoCao, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<DieuKhienNhanVat>().DoiDangSung(type);
            Destroy(gameObject);
        }
    }
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
