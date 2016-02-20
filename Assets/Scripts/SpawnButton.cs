using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnButton : MonoBehaviour
{

    GameObject selectedBase;
    Spawner baseSpawner;

    // Use this for initialization
    void Start()
    {
        selectedBase = gameObject.transform.parent.parent.parent.gameObject;
        baseSpawner = selectedBase.gameObject.GetComponent<Spawner>();
    }

    // Update is called once per frame
    public void SpawnLevel1Pressed()
    {
        Debug.Log("button pressed");
        baseSpawner.SpawnLevel1Pressed();
    }
    // Update is called once per frame
    public void SpawnLevel2Pressed()
    {
        Debug.Log("button pressed");
        baseSpawner.SpawnLevel2Pressed();
    }
    // Update is called once per frame
    public void SpawnLevel3Pressed()
    {
        Debug.Log("button pressed");
        baseSpawner.SpawnLevel3Pressed();
    }

    // Update is called once per frame
    public void PauseSpawningPressed()
    {
        Debug.Log("button pressed");
        baseSpawner.PauseSpawningPressed();
    }

    // Update is called once per frame
    public void DestroyBasePressed()
    {
        Debug.Log("button pressed");
        baseSpawner.DestroyBasePressed();
    }
}
