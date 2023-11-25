using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject platformExtraPrefab;
    [SerializeField] private int countPlatforms = 100;
    [SerializeField] private int countExtraPlatforms = 50;

    [SerializeField] private float minY = .1f;
    [SerializeField] private float maxY = 1f;
    [SerializeField] private float levelWidth = 3f;

    [SerializeField] private float extraMinY = .5f;
    [SerializeField] private float extraMaxY = 5f;

    [SerializeField] private float minVerticalDistance = 2.0f;

    void Start()
    {
        GeneratePlatforms(platformPrefab, countPlatforms, minY, maxY, levelWidth);
        GeneratePlatforms(platformExtraPrefab, countExtraPlatforms, extraMinY, extraMaxY, levelWidth);
    }

    void GeneratePlatforms(GameObject prefab, int count, float minY, float maxY, float levelWidth)
    {
        Vector3 spawnPosition = new Vector3();
        float lastPlatformY = 0f;

        for (int i = 0; i < count; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);

            if (Mathf.Abs(spawnPosition.y - lastPlatformY) < minVerticalDistance)
            {
                spawnPosition.y += minVerticalDistance;
            }
            lastPlatformY = spawnPosition.y;
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }
}
