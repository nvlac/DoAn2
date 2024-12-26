using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KD_BanTia : MonoBehaviour
{
    private XuLyHuongBan GocBan;
    public Animator anim;

    private Transform player; // Lưu trữ tham chiếu đến nhân vật
    private bool playerExists; // Kiểm tra xem nhân vật có tồn tại không

    void Start()
    {
        GocBan = GetComponent<XuLyHuongBan>();
        anim = GetComponent<Animator>();

        var playerObject = FindObjectOfType<DieuKhienNhanVat>();
        if (playerObject != null)
        {
            player = playerObject.transform;
            playerExists = true;
        }
        else
        {
            playerExists = false;
        }
    }

    void Update()
    {
        if (playerExists && player != null)
        {
            // Nếu nhân vật tồn tại, thay đổi hướng dựa vào vị trí của nhân vật
            if (player.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        // Dù nhân vật chết hay sống, hoạt động bình thường
        anim.SetInteger("GocBan", (int)GocBan.TinhHuongBan());
    }
}
