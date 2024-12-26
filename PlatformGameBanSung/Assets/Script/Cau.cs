using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cau : MonoBehaviour
{
    public EdgeCollider2D[] blocks;
    public float DoTre;
    float XuLyDoTre;
    public GameObject HieuUng;
    bool PhaNo;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        XuLyDoTre = 0;
        blocks = GetComponentsInChildren<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PhaNo) return;
        if (XuLyDoTre <= 0)
        {
            Destroy(blocks[i].gameObject);
            Instantiate(HieuUng, blocks[i].gameObject.transform.position, blocks[i].gameObject.transform.rotation);
            i++;
            XuLyDoTre = DoTre;
        }
        else
        {
            XuLyDoTre -= Time.deltaTime;
        }
        if (i == blocks.Length) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") PhaNo = true;
    }
}
