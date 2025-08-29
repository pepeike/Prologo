using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private float yPosition;
    [SerializeField] private float xDiff = 5f;
    private float xSpawnPosition;

    public GameObject dialArea;
    public GameObject hitAreaPrefab;

    private void Awake() {
        yPosition = dialArea.transform.position.y;
    }

    void SelectNewPosition() {
        xSpawnPosition = Random.Range(-xDiff, xDiff);
    }

    public void SpawnHitArea() {
        SelectNewPosition();
        Vector3 spawnPosition = new Vector3(xSpawnPosition, yPosition, 0f);
        Instantiate(hitAreaPrefab, spawnPosition, Quaternion.identity);
    }

    private bool isSpawning = false;
    IEnumerator SpawnHitAreaRoutine() {
        isSpawning = true;
        SpawnHitArea();
        yield return new WaitForSeconds(2f);
        isSpawning = false;
    }

    private void Start() {
        SpawnHitArea();
    }

}
