using UnityEngine;
using System.Collections;

public class FPSManager : MonoBehaviour {

    public int TargeFrameRate;

    void Awake()
    {
        Application.targetFrameRate = TargeFrameRate;
    }
}
