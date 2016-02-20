using UnityEngine;
using System.Collections;

public class AIAttributes : MonoBehaviour {

    public string unitName;
    [Range(1, 3)]
    public int unitLevel;

    [Range(0.1f,2f)]
    public float movementSpeed;

    [Range(0f, 250f)]
    public float health;

    [Range(5f, 25f)]
    public float unitVision;

    [Range(5f, 25f)]
    public float attackRange;

    [Range(5f, 25f)]
    public float attackDamage;

    [Range(1f, 5f)]
    public float attackRate;

    [Range(0.1f, 1f)]
    public float critRate;

    [Range(0.1f, 1f)]
    public float defenseDamageReductionMultiplyer;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
