using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieuKhienCamera : MonoBehaviour
{
    public BoxCollider2D GioiHanCamera;
    public bool TheoDoi;
    public GameObject GioiHanDiChuyen;

    private Transform player;
    private DieuKhienNhanVat playerController;
    private Vector2 min;
    private Vector2 max;

    // Use this for initialization
    void Start()
    {
        var playerObject = FindObjectOfType<DieuKhienNhanVat>();
        if (playerObject != null)
        {
            player = playerObject.transform;
            playerController = playerObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController == null || playerController.HP <= 0)
        {

            TheoDoi = false;
            return;
        }

        min = GioiHanCamera.bounds.min;
        max = GioiHanCamera.bounds.max;

        var x = transform.position.x;

        if (TheoDoi)
        {
            if (player.position.x > x)
            {
                x = player.position.x;
            }
        }

        var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);
        x = Mathf.Clamp(x, min.x + cameraHalfWidth, max.x - cameraHalfWidth);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
        GioiHanDiChuyen.transform.position = new Vector2(x - cameraHalfWidth, transform.position.y);
    }
}
