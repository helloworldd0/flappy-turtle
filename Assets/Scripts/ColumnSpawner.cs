using System.Collections;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    [SerializeField] private GameObject column;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float spawnX = 20f;
    [SerializeField] private float firstColumnX = 2f;
    [SerializeField] private float spacing = 6.5f; 
    [SerializeField] private int initialColumnsCount = 3;
    [SerializeField] private float heightRange = 3f;

    void Start()
    {
        for (int i = 0; i < initialColumnsCount; i++)
        {
            SpawnColumn(firstColumnX + i * spacing);
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true) {
            yield return new WaitForSeconds(spawnInterval);
            SpawnColumn(spawnX);
        }
    }

    private void SpawnColumn(float x)
    {
        float y = Random.Range(-heightRange, heightRange);
        Instantiate(column, new Vector3(x, y, 0), Quaternion.identity, transform);
    }

    public void ResetSpawner()
    {
        StopAllCoroutines();

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Start(); 
    }
}
