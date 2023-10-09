using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherrySpawner : MonoBehaviour
{
    public GameObject CherryPrefab; // Drag the Cherry prefab into this field in the Unity editor
    public float spawnInterval = 1f; // Interval at which to spawn new Cherry
    public float spawnHeight = 10f; // Height at which to spawn new Cherry
    float speed = 5f; // Speed at which the Cherry move
    public float spawnRadius = 2f;
    public Score score;

    void Start()
    {
            InvokeRepeating("SpawnCherry", 0f, spawnInterval); // Spawn a Cherry every "spawnInterval" seconds
    }

    void SpawnCherry()
    {
        if (score.TempJCount < 10) { speed = 5; }
        if (score.TempJCount > 10) { speed = 6; }
        if (score.TempJCount > 20) { speed = 7; }
        if (score.TempJCount > 25) { speed = 9; }
        if (score.TempJCount > 30) { speed = 11; }
        if (score.TempJCount > 40) { speed = 15; }

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRadius, spawnRadius), transform.position.y, 0f);
        GameObject bell = Instantiate(CherryPrefab, spawnPos, Quaternion.identity);
        bell.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -speed), ForceMode2D.Force);
    }
}
