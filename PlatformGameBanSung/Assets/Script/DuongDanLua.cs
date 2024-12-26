using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuongDanLua : MonoBehaviour
{

    Rigidbody2D myRigidbody;
    public float TocDoBay;
    public float TocDoXoay;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.AddRelativeForce(Vector2.up * TocDoBay, ForceMode2D.Impulse);
        myRigidbody.angularVelocity = TocDoXoay;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
        if (transform.parent.gameObject != null) Destroy(transform.parent.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KeDich" || other.tag == "HopVatPham")
        {
            if (other.GetComponent<QuanLy_KD>() != null)
            {
                other.GetComponent<QuanLy_KD>().NhanST();
                Destroy(gameObject);
                if (transform.parent.gameObject != null) Destroy(transform.parent.gameObject);
            }
        }
    }
}
