using UnityEngine;
using UnityEngine.EventSystems;

public class DieuKhienCamUng : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public string action; 
    private DieuKhienNhanVat controller; 

    void Start()
    {
        // Tìm script điều khiển nhân vật trong scene
        controller = FindObjectOfType<DieuKhienNhanVat>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnButtonPointerDown(); 
    }

    // Phương thức không tham số để gọi trong EventTrigger
    public void OnButtonPointerDown()
    {
        switch (action)
        {
            case "Left": controller.KeyLeft = true; break;
            case "Right": controller.KeyRight = true; break;
            case "Up": controller.KeyUp = true; break;
            case "Down": controller.KeyDown = true; break;
            case "LeftUp": controller.KeyLeftUp = true; break;
            case "LeftDown": controller.KeyLeftDown = true; break;
            case "RightUp": controller.KeyRightUp = true; break;
            case "RightDown": controller.KeyRightDown = true; break;
            case "Jump": controller.KeyJump = true; break;
            case "Action": controller.KeyAction = true; break;
            case "Exit": controller.KeyExit = true; break;

        }
    }

    // Khi thả nút
    public void OnPointerUp(PointerEventData eventData)
    {
        switch (action)
        {
            case "Left": controller.KeyLeft = false; break;
            case "Right": controller.KeyRight = false; break;
            case "Up": controller.KeyUp = false; break;
            case "Down": controller.KeyDown = false; break;
            case "LeftUp": controller.KeyLeftUp = false; break;
            case "LeftDown": controller.KeyLeftDown = false; break;
            case "RightUp": controller.KeyRightUp = false; break;
            case "RightDown": controller.KeyRightDown = false; break;
            case "Jump": controller.KeyJump = false; break;
            case "Action": controller.KeyAction = false; break;
            case "Exit": controller.KeyExit = false; break;
        }
    }
}
