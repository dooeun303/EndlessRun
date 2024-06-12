
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
    }

    private void OnTriggerExit (Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 장애물 생성
    public GameObject obstaclePrefab;

    void SpawnObstacle()
    {
        // 랜덤 포인트를 생성
        int obstacleSpawnIndex = Random.Range(2, 5); // 인덱스 2,3,4
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // 그 장소에 장애물 생성
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}
