using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KichHoatHopVatPhamBay : MonoBehaviour
{
    public GameObject HopVatPham;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            HopVatPham.GetComponent<DuongBayHopVatPham>().y = transform.position.y;
            HopVatPham.GetComponent<DuongBayHopVatPham>().KichHoat();
        }
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
