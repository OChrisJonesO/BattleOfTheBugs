using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
    // Changes mouse cursor 
    public Texture2D cursorTexture; // Custom mouse Cursor texture. 
    CursorMode cursorMode = CursorMode.Auto; 
    Vector2 hotSpot = Vector2.zero;

    // Moves mouse cursor 
    public float normalCamSpeed; // normal speed camera moves when hovering cursor at edge
    public float fastCamSpeed; // faster speed camera moves when hovering cursor at far edge
    public int normalPaddingSize; // rectangle drawn on all 4 sides to detect mouse hover for movement. this is the "normal" size / speed
    public int fastPaddingSize; // rectangle drawn on all 4 sides to detect mouse hover for movement. this is the "fast" size / speed

    // Zooms camera view on scroll wheel
    public float minFOV = 15f;
    public float maxFOV = 90f;
    public float sensitivity = 10f;

    void Start() {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode); // Hide default mouse cursor and replace it
    }

    void Update() {
        // Move Cursor normal speed
        var moveUp = new Rect(0, Screen.height - normalPaddingSize, Screen.width, normalPaddingSize);
        var moveDown = new Rect(0, 0, Screen.width, normalPaddingSize);
        var moveLeft = new Rect(0, 0, normalPaddingSize, Screen.height);
        var moveRight = new Rect(Screen.width - normalPaddingSize, 0, normalPaddingSize, Screen.height);

        if (moveDown.Contains(Input.mousePosition)){
            transform.Translate(0, 0, -normalCamSpeed, Space.World);
        }
        if (moveUp.Contains(Input.mousePosition)){
            transform.Translate(0, 0, normalCamSpeed, Space.World);
        }
        if (moveLeft.Contains(Input.mousePosition)){       
            transform.Translate(-normalCamSpeed, 0, 0, Space.World);
        }
        if (moveRight.Contains(Input.mousePosition)){
            transform.Translate(normalCamSpeed, 0, 0, Space.World);
        }

        // Move Cursor fast speed
        var moveUpFast = new Rect(0, Screen.height - fastPaddingSize, Screen.width, fastPaddingSize);
        var moveDownFast = new Rect(0, 0, Screen.width, fastPaddingSize);
        var moveLeftFast = new Rect(0, 0, fastPaddingSize, Screen.height);
        var moveRightFast = new Rect(Screen.width - fastPaddingSize, 0, fastPaddingSize, Screen.height);

        
        if (moveDownFast.Contains(Input.mousePosition)){
            transform.Translate(0, 0, -fastCamSpeed, Space.World);
        }
        if (moveUpFast.Contains(Input.mousePosition)){
            transform.Translate(0, 0, fastCamSpeed, Space.World);
        }
        if (moveLeftFast.Contains(Input.mousePosition)){
            transform.Translate(-fastCamSpeed, 0, 0, Space.World);
        }
        if (moveRightFast.Contains(Input.mousePosition)){
            transform.Translate(fastCamSpeed, 0, 0, Space.World);
        }

        // Zooms camera view on scroll wheel
        float currentFOV = Camera.main.fieldOfView;
        currentFOV += Input.GetAxis("Mouse ScrollWheel") * -sensitivity;
        currentFOV = Mathf.Clamp(currentFOV, minFOV, maxFOV);
        Camera.main.fieldOfView = currentFOV;
    }
}