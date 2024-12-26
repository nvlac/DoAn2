using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThapPhao : MonoBehaviour
{
    private XuLyHuongBan GocBan;

    public float TocDoBan = 1.5f;
    private float DoTreBan;

    public float TocDoXoay = 0.3f;
    private float DoTreXoay;

    private float GocBanHienTai;
    private float GocBanToiPlayer;

    public GameObject DuongDan;
    public GameObject ViTriDauNong;

    public float PhamVi = 20f; // Phạm vi hoạt động
    private Transform player;  // Tham chiếu tới Player

    void Start()
    {
        GocBan = GetComponent<XuLyHuongBan>();
        DoTreXoay = TocDoXoay;
        player = FindObjectOfType<DieuKhienNhanVat>().transform;
    }

    void Update()
    {
        if (PlayerTrongPhamVi())
        {
            if (DoTreXoay <= 0)
            {
                DoTreXoay = TocDoXoay;
                GocBanToiPlayer = GocBan.TinhHuongBan();
                if (GocBanToiPlayer < 0) GocBanToiPlayer += 360;
                GocBanHienTai = Mathf.Round(transform.rotation.eulerAngles.z);

                if (GocBanHienTai - GocBanToiPlayer > 0)
                {
                    if (GocBanHienTai - GocBanToiPlayer > 180)
                    {
                        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, GocBanHienTai + 30);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, GocBanHienTai - 30);
                    }
                }
                else if (GocBanHienTai - GocBanToiPlayer < 0)
                {
                    if (GocBanHienTai - GocBanToiPlayer < -180)
                    {
                        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, GocBanHienTai - 30);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, GocBanHienTai + 30);
                    }
                }
                else if (GocBanHienTai == GocBanToiPlayer)
                {
                    Shoot();
                }
            }
            else
            {
                DoTreXoay -= Time.deltaTime;
            }

            DoTreBan -= Time.deltaTime;
        }
    }

    bool PlayerTrongPhamVi()
    {
        if (player == null) return false;

        float khoangCach = Vector2.Distance(transform.position, player.position);
        return khoangCach <= PhamVi;
    }

    void Shoot()
    {
        if (DoTreBan <= 0)
        {
            Instantiate(DuongDan, ViTriDauNong.transform.position, transform.rotation);
            DoTreBan = TocDoBan;
        }
    }
}
