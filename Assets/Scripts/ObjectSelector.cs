using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ObjectSelector : MonoBehaviour
{
    // Link to HUD for interactivity
    GameObject HUD;
    GameObject menuRight;

    //Mouse Clicks
    Ray click;
    RaycastHit clickTarget;
    GameObject mainCamera;

    // Units
    GameObject unitHighlight;
    GameObject unitStats;
    ClickToMove unitClickToMove;

    // Bases
    GameObject baseHighlight;
    GameObject baseStats;
    GameObject baseSpawnSlider;
    public GameObject baseActions;
    GameObject selectedBaseActions;
    Spawner baseSpawner;

    void Start()
    {
        HUD = GameObject.Find("HUD");
        menuRight = GameObject.Find("MenuRight");
        mainCamera = GameObject.Find("MainCamera");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){ // if player left clicked
            PlayerClick();
        }
    }

    public void PlayerClick() {
        if (!EventSystem.current.IsPointerOverGameObject()) { 
        click = (mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition)); // ray from camera to click
        if (Physics.Raycast(click, out clickTarget)) // if raycast hits an object
        {
            if (clickTarget.transform.tag == "ClickableUnit")
            {
                unitHighlight = clickTarget.transform.FindChild("UnitHighlight").gameObject;
                unitStats = clickTarget.transform.FindChild("UnitStats").gameObject;
                unitClickToMove = clickTarget.transform.gameObject.GetComponent<ClickToMove>();

                if (unitClickToMove.enabled == false)
                {
                    unitClickToMove.enabled = true;
                    unitHighlight.SetActive(true);
                    unitStats.SetActive(true);

                }
                else if (unitClickToMove.enabled == true)
                {
                    unitClickToMove.enabled = false;
                    unitHighlight.SetActive(false);
                    unitStats.SetActive(false);
                }
            }
        }

        if (Physics.Raycast(click, out clickTarget)) // if raycast hits an object
        {
            if (clickTarget.transform.tag == "ClickableBase")
            {
                baseHighlight = clickTarget.transform.FindChild("BaseHighlight").gameObject;
                baseStats = clickTarget.transform.FindChild("BaseStats").gameObject;
                baseSpawnSlider = clickTarget.transform.FindChild("BaseSpawnSlider").gameObject;
                baseSpawner = clickTarget.transform.gameObject.GetComponent<Spawner>();
                selectedBaseActions = Instantiate(baseActions, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                selectedBaseActions.transform.SetParent(clickTarget.transform, false);
                selectedBaseActions.transform.position = new Vector3(15.41045f, -11.55425f, 0.510464f);
                    selectedBaseActions.transform.eulerAngles = new Vector3 (0, 0, 0);
                    selectedBaseActions.transform.localScale = new Vector3(0.333f, 0.333f, 0.333f);
                baseHighlight.SetActive(true);
                baseSpawnSlider.SetActive(true);
                baseStats.SetActive(true);
            }

           else if (clickTarget.transform.tag == "ClickableLocation")
            {
                GameObject.Destroy(selectedBaseActions);
                baseHighlight.SetActive(false);
                baseSpawnSlider.SetActive(false);
                baseStats.SetActive(false);
            }
        }
        }

    }
}