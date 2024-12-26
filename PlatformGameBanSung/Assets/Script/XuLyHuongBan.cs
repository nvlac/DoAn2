using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XuLyHuongBan : MonoBehaviour
{
    private DieuKhienNhanVat player;
    private float HuongBan;
    private Vector2 A, B, C;

    void Start()
    {
        player = FindObjectOfType<DieuKhienNhanVat>();
    }

    public float TinhHuongBan()
    {
        // Kiểm tra nếu player null
        if (player == null)
        {
            return 0;
        }

        A = new Vector2(transform.position.x, transform.position.y);
        B = new Vector2(player.transform.position.x, player.transform.position.y);
        C = B - A;

        HuongBan = Mathf.Atan2(C.y, C.x) * Mathf.Rad2Deg;
        HuongBan = Mathf.Round(HuongBan / 30) * 30;

        return HuongBan;
    }
}
