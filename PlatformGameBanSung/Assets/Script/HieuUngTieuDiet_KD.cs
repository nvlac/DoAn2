using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HieuUngTieuDiet_KD : MonoBehaviour
{
    public float height;
    private int scale;

    // Use this for initialization
    void Start()
    {
        scale = Mathf.Clamp((int)(FindObjectOfType<DieuKhienNhanVat>().transform.position.x * 10000 - transform.position.x * 10000), -1, 1);
        transform.localScale = new Vector3(scale, 1, 1);
        if (GetComponent<Rigidbody2D>()!= null)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-scale * 2, height);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

}
