using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HieuUngNhanVatDie : MonoBehaviour
{
    public float posiY;
    public float posiX;

    void Start()
    {
        Rigidbody2D myRigidbody = GetComponent<Rigidbody2D>();
        Transform playerTransform = FindObjectOfType<DieuKhienNhanVat>().transform;

        // Đặt vị trí của hiệu ứng phía sau nhân vật
        if (playerTransform.localScale.x > 0)
        {
            transform.position = new Vector3(playerTransform.position.x - posiX, playerTransform.position.y + posiY, playerTransform.position.z);
        }
        else
        {
            transform.position = new Vector3(playerTransform.position.x + posiX, playerTransform.position.y + posiY, playerTransform.position.z);
        }
    }
}
