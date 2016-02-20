using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour
{
    public float movementSpeed = 1;
    Ray click;
    RaycastHit clickTarget;
    GameObject mainCamera;

    // Update is called once per frame

    void Start()
    {
        mainCamera = GameObject.Find("MainCamera");
        movementSpeed = gameObject.GetComponent<AIAttributes>().movementSpeed;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        { // if player left clicked
            click = (mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition)); // ray from camera to click
        }
        if (Physics.Raycast(click, out clickTarget)) // if raycast is hit
        {

            if (clickTarget.transform.tag == "ClickableLocation") // if player clicked a "Clickable" object
            {
                Vector3 currentPosition = transform.position;
                Vector3 targetPosition = clickTarget.point;
                Debug.Log("drawing line");
                Debug.DrawLine(mainCamera.transform.position, clickTarget.point);
                Debug.Log("moving object");
                transform.position = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * movementSpeed);

            }
        }
    }
}
