using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DuongBayHopVatPham : MonoBehaviour
{
    public float TocDoBay;
    public float y;
    public float BienDo = 1;
    public float KhoanCach = 1;
    void Start()
    {
        y = transform.position.y;

    }

    public void KichHoat()
    {
        GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * TocDoBay, ForceMode2D.Impulse);
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, y + BienDo * Mathf.Sin(transform.position.x * KhoanCach));
    }
}
