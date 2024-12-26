using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuongDanKD : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    public float TocDoBay;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.AddRelativeForce(Vector2.right * TocDoBay, ForceMode2D.Impulse);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<DieuKhienNhanVat>() != null)
            {
                other.GetComponent<DieuKhienNhanVat>().NhanST();
                Destroy(gameObject);
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
        if (transform.parent != null) Destroy(transform.parent.gameObject);
    }
}
