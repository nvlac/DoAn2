using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuongDanChum : MonoBehaviour
{
    public GameObject projectile;
    public float range;
    private Vector3 rot;

    // Use this for initialization
    void Start()
    {
        rot = transform.localEulerAngles;

        if (FindObjectsOfType<DuongDan>().Length < 50)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(rot.x, rot.y, rot.z));
        }
        if (FindObjectsOfType<DuongDan>().Length < 50)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(rot.x, rot.y, rot.z -range));
        }
        if (FindObjectsOfType<DuongDan>().Length < 50)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(rot.x, rot.y, rot.z +range));
        }
        if (FindObjectsOfType<DuongDan>().Length < 50)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(rot.x, rot.y, rot.z -range*2));
        }
        if (FindObjectsOfType<DuongDan>().Length < 50)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(rot.x, rot.y, rot.z -range*2));
        }

        Destroy(gameObject);
    }

}
