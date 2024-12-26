using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public GameObject PhaoTrai;
    public GameObject PhaoPhai;
    public GameObject CongVao;
    public GameObject DuongDan;

    public float TocDoBan;
    float BoDemTrai;
    float BoDemPhai;
    public bool KichHoat;

    // Start is called before the first frame update
    void Start()
    {
        BoDemTrai = TocDoBan;
        BoDemPhai = 0;
    }

    void OnBecameVisible()
    {
        KichHoat = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!KichHoat) return;

        // Kiểm tra nếu cổng vào bị phá hủy
        if (CongVao == null)
        {
            // Hủy pháo và boss
            if (PhaoTrai != null) PhaoTrai.GetComponent<QuanLy_KD>().Die();
            if (PhaoPhai != null) PhaoPhai.GetComponent<QuanLy_KD>().Die();

            Destroy(gameObject);

            SceneManager.LoadScene("WinMenu");
        }

        // Xử lý bắn từ pháo trái
        if (PhaoTrai != null)
        {
            if (BoDemTrai <= 0)
            {
                Instantiate(DuongDan, PhaoTrai.transform.position, PhaoTrai.transform.rotation);
                BoDemTrai = TocDoBan + Random.Range(-1, 0);
            }
            else
            {
                BoDemTrai -= Time.deltaTime;
            }
        }

        // Xử lý bắn từ pháo phải
        if (PhaoPhai != null)
        {
            if (BoDemPhai <= 0)
            {
                Instantiate(DuongDan, PhaoPhai.transform.position, PhaoPhai.transform.rotation);
                BoDemPhai = TocDoBan + Random.Range(-1, 0);
            }
            else
            {
                BoDemPhai -= Time.deltaTime;
            }
        }
    }
}
