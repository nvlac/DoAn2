using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DieuKhienNhanVat : MonoBehaviour
{
    // Phím điều khiển
    public bool KeyLeft;
    public bool KeyRight;
    public bool KeyUp;
    public bool KeyDown;
    public bool KeyLeftUp;
    public bool KeyLeftDown;
    public bool KeyRightUp;
    public bool KeyRightDown;
    public bool KeyJump;
    public bool KeyAction;
    public bool KeyExit;

    // LayerMask cho từng loại đất
    public LayerMask MatDatA; 
    public LayerMask MatDatB;
    public LayerMask VucTham;
    public LayerMask MatNuoc; 

    // Trạng thái nhân vật
    public Transform KTDiaHinh;
    private bool TrenMatDat;
    private bool DuoiNuoc;
    private bool DangNhay;
    private bool DangChay;
    private bool DangBan;
    public int HP;
    private int HPHienTai;
    private bool isDie = false;
    public GameObject HieuUng;

    // Animation
    private Animator[] animators;

    // Thông số nhân vật
    public float TocDoChay;
    public float LucNhay;
    private float HitboxSize;
    private float HitboxOffset;
    public float DuoiNuocSize;
    public float DuoiNuocOffset;
    public float DangNamSize;
    public float DangNamOffset;
    private Rigidbody2D Rb2D;
    private Collider2D playerCollider;
    private BoxCollider2D playerHitbox;

    // Vũ khí
    private GameObject SungHienTai;
    public GameObject SungThuong;
    public GameObject SungMay;
    public GameObject SungDanChum;
    public GameObject SungLua;
    public GameObject SungLaser;

    // Chức năng bắn
    public float TocDoBan;
    private float TocDoBanCounter;
    public int PhuongHuong;
    public float[] GocBan;
    public GameObject ViTriDauNong;
    private Quaternion rot;
    private bool BanTuDong;// bắn tự động

    void Start()
    {
        animators = GetComponentsInChildren<Animator>();

        Rb2D = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerHitbox = GetComponent<BoxCollider2D>();
  
        HitboxSize = playerHitbox.size.y;
        HitboxOffset = playerHitbox.offset.y;
        HPHienTai = HP;

        SungHienTai = SungThuong;
        rot = new Quaternion(0, 0, 0, 0);
        TocDoBanCounter = 0;
        BanTuDong = false;
    }
    void Update()
    {
        if (HP <= 0 && isDie)
        {
            isDie = false;
        }
        Animation();
        DiChuyen();
        ChucNangBan();
        Thoat();
    }
    void Thoat()
    {
        if (KeyExit)
        {
            Application.Quit();
        }
    }
    //-----------------------------------------Animation-----------------------------------------------
    private void Animation()
    {
        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].SetBool("TrenMatDat", TrenMatDat);
            animators[i].SetBool("DuoiNuoc", DuoiNuoc);
            animators[i].SetBool("DangNhay", DangNhay);
            animators[i].SetBool("DangChay", DangChay);
            animators[i].SetBool("KeyDown", KeyDown);
            animators[i].SetBool("DangBan", KeyAction || BanTuDong);
            animators[i].SetInteger("PhuongHuong", PhuongHuong);
        }
    }

    //-----------------------------------------Xử lý khi nhận ST----------------------------------------------
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("VucTham"))
        {
            Die();
        }
    }
    public void NhanST()
    {
        if (KeyDown && DuoiNuoc) return;

        HPHienTai--;

        GameObject[] hpObjects = GameObject.FindGameObjectsWithTag("HP");
        if (hpObjects.Length > 0)
        {
            Destroy(hpObjects[0]);
        }

        if (HPHienTai <= 0 && !isDie)
        {
            Die();
        }
    }
    public void Die()
    {
        isDie = true;
        if (HieuUng != null)
        {
            Instantiate(HieuUng, transform.position, transform.rotation);
        }

        Destroy(gameObject);
        SceneManager.LoadScene("LoseMenu");
    }

    //-----------------------------------------Di Chuyển-----------------------------------------------
    void DiChuyen()
    {
        // Kiểm tra nếu nhân vật đang dưới nước
        DuoiNuoc = Physics2D.OverlapCircle(KTDiaHinh.position, 0.3f, MatNuoc);

        // Kiểm tra nếu nhân vật đang trên mặt đất
        TrenMatDat = !DuoiNuoc && Physics2D.OverlapCircle(KTDiaHinh.position, 0.3f, MatDatA | MatDatB);

        DangNhay = !TrenMatDat && !DuoiNuoc;

        // Cập nhật Hitbox
        if (DuoiNuoc)
        {
            // Hitbox dưới nước
            playerHitbox.size = new Vector2(playerHitbox.size.x, DuoiNuocSize);
            playerHitbox.offset = new Vector2(playerHitbox.offset.x, DuoiNuocOffset);
        }
        else if (TrenMatDat && KeyDown && !KeyLeft && !KeyRight)
        {
            // Hitbox khi nằm
            playerHitbox.size = new Vector2(playerHitbox.size.x, DangNamSize);
            playerHitbox.offset = new Vector2(playerHitbox.offset.x, DangNamOffset);
        }
        else
        {
            // Hitbox bình thường
            playerHitbox.size = new Vector2(playerHitbox.size.x, HitboxSize);
            playerHitbox.offset = new Vector2(playerHitbox.offset.x, HitboxOffset);
        }

        // Xử lý di chuyển
        float moveInput = 0;

        if (KeyLeft || KeyLeftDown || KeyLeftUp) moveInput = -1;
        else if (KeyRight || KeyRightDown || KeyRightUp) moveInput = 1;

        Rb2D.velocity = new Vector2(moveInput * TocDoChay, Rb2D.velocity.y);

        if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);

        DangChay = (moveInput != 0 && TrenMatDat);

        // Xử lý nhảy
        if (KeyJump && TrenMatDat)
        {
            Rb2D.velocity = new Vector2(Rb2D.velocity.x, LucNhay);
            DangNhay = true;
            
        }
    }
    //-----------------------------------------Chức năng bắn-----------------------------------------------
    public void DoiDangSung(int type)
    {
        switch (type)
        {
            case 0:
                BanTuDong = false;
                break;
            case 1: 
                SungHienTai = SungMay;
                BanTuDong = true;
                break;
            case 2:
                SungHienTai = SungLua;
                BanTuDong = false;
                break;
            case 3:
                SungHienTai = SungDanChum;
                BanTuDong = false;
                break;
            case 4:
                SungHienTai = SungLaser;
                BanTuDong = false;
                break;
        }
    }
    private void ChucNangBan()
    {
        if (DuoiNuoc && KeyDown)
            return;

        // Xác định hướng bắn
        if (KeyUp && !KeyRight && !KeyLeft && !KeyDown) PhuongHuong = 0; 
        else if (DangNhay && KeyDown && !KeyRight && !KeyLeft && !KeyRightUp && !KeyLeftUp && !KeyRightDown && !KeyLeftDown) PhuongHuong = 4; 
        else if (transform.localScale.x > 0)
        {
            if (KeyRightUp) PhuongHuong = 1; 
            else if (KeyRightDown) PhuongHuong = 3; 
            else PhuongHuong = 2; 
        }
        else if (transform.localScale.x < 0)
        {
            if (KeyLeftUp) PhuongHuong = 7; 
            else if (KeyLeftDown) PhuongHuong = 5; 
            else PhuongHuong = 6;
        }

        // Xác định góc bắn dựa trên hướng bắn
        if (PhuongHuong == 0) rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, GocBan[0]); 
        if (PhuongHuong == 1) rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -GocBan[1]); 
        if (PhuongHuong == 2) rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -GocBan[2]); 
        if (PhuongHuong == 3) rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -GocBan[3]); 
        if (PhuongHuong == 4) rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, GocBan[4]); 
        if (PhuongHuong == 5) rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, GocBan[3]); 
        if (PhuongHuong == 6) rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, GocBan[2]);
        if (PhuongHuong == 7) rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, GocBan[1]); 

        // Thực hiện bắn
        if ((KeyAction || BanTuDong) && TocDoBanCounter <= 0)
        {
            if ((SungHienTai == SungThuong || SungHienTai == SungLua || SungHienTai == SungMay)
                && FindObjectsOfType<DuongDan>().Length < 10)
            {
                Instantiate(SungHienTai, ViTriDauNong.transform.position, rot);
                TocDoBanCounter = TocDoBan;
            }
            else if (SungHienTai == SungDanChum && FindObjectsOfType<DuongDan>().Length < 50)
            {
                Instantiate(SungHienTai, ViTriDauNong.transform.position, rot);
                TocDoBanCounter = TocDoBan;
            }
            else if (SungHienTai == SungLaser)
            {
                foreach (DuongDan p in FindObjectsOfType<DuongDan>()) Destroy(p.gameObject);
                foreach (DuongDanLaser s in FindObjectsOfType<DuongDanLaser>()) Destroy(s.gameObject);
                Instantiate(SungHienTai, ViTriDauNong.transform.position, rot);
                TocDoBanCounter = TocDoBan;
            }
        }
        TocDoBanCounter -= Time.deltaTime;
    }
}
