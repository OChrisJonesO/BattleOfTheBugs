using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject level1UnitToSpawn;
    public GameObject level2UnitToSpawn;
    public GameObject level3UnitToSpawn;

    public float spawnLevel1Delay;
    public float spawnLevel2Delay;
    public float spawnLevel3Delay;

    bool isSpawningLevel1;
    bool isSpawningLevel2;
    bool isSpawningLevel3;

    GameObject spawnSlider;
    Slider spawnSliderValue;

    Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = new Vector3(0, 0, 2);
        spawnSlider = gameObject.transform.FindChild("BaseSpawnSlider/Slider").gameObject;
        spawnSliderValue = spawnSlider.GetComponent<Slider>();
        isSpawningLevel1 = false;
        isSpawningLevel2 = false;
        isSpawningLevel3 = false;
    }

    public void SpawnLevel1Pressed() {
        CancelInvoke("SpawnLevel1");
        CancelInvoke("SpawnLevel2");
        CancelInvoke("SpawnLevel3");
        spawnSliderValue.value = 0;
        InvokeRepeating("SpawnLevel1", 0, 1);
        isSpawningLevel1 = true;
    }

    public void SpawnLevel1() {
        spawnSliderValue.maxValue = spawnLevel1Delay;
        if (spawnSliderValue.value < spawnLevel1Delay)
        {
            spawnSliderValue.value = spawnSliderValue.value + 1;
        }
        else if (spawnSliderValue.value >= spawnLevel1Delay)
        {
            Instantiate(level1UnitToSpawn, (transform.position + offset), Quaternion.identity);
            spawnSliderValue.value = 0;
        }
    }

    public void SpawnLevel2Pressed()
    {
        CancelInvoke("SpawnLevel1");
        CancelInvoke("SpawnLevel2");
        CancelInvoke("SpawnLevel3");
        spawnSliderValue.value = 0;
        InvokeRepeating("SpawnLevel2", 0, 1);
        isSpawningLevel2 = true;
    }

    public void SpawnLevel2()
    {
        spawnSliderValue.maxValue = spawnLevel2Delay;

        if (spawnSliderValue.value < spawnLevel2Delay)
        {
            spawnSliderValue.value = spawnSliderValue.value + 1;
        }
        else if (spawnSliderValue.value >= spawnLevel2Delay)
        {
            Instantiate(level2UnitToSpawn, (transform.position + offset), Quaternion.identity);
            spawnSliderValue.value = 0;
        }
    }

    public void SpawnLevel3Pressed()
    {
            CancelInvoke("SpawnLevel1");
            CancelInvoke("SpawnLevel2");
            CancelInvoke("SpawnLevel3");
            spawnSliderValue.value = 0;
            InvokeRepeating("SpawnLevel3", 0, 1);
            isSpawningLevel3 = true;
    }


    public void SpawnLevel3()
    {
        spawnSliderValue.maxValue = spawnLevel3Delay;

        if (spawnSliderValue.value < spawnLevel3Delay)
        {
            spawnSliderValue.value = spawnSliderValue.value + 1;
        }
        else if (spawnSliderValue.value >= spawnLevel3Delay)
        {
            Instantiate(level3UnitToSpawn, (transform.position + offset), Quaternion.identity);
            spawnSliderValue.value = 0;
        }
    }

    public void PauseSpawningPressed()
    {
        PauseSpawning();
    }

    public void PauseSpawning()
    {
        spawnSliderValue.maxValue = 0;
        CancelInvoke("SpawnLevel1");
        CancelInvoke("SpawnLevel2");
        CancelInvoke("SpawnLevel3");
    }

    public void DestroyBasePressed()
    {
        DestroyBase();
    }

    public void DestroyBase()
    {
        Destroy(gameObject);
    }
}
