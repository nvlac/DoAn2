using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XoaGameObject : MonoBehaviour
{
    public float ThoiGianXoa;

    void Update()
    {
        if (ThoiGianXoa <= 0)
        {
            Destroy(gameObject);
        }
        else ThoiGianXoa -= Time.deltaTime;
    }
}
