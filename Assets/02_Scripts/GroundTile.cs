
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject coinPrefab; 
    public GroundSpawner groundSpawner;
    public GameObject tallObstaclePrefab;
    public float tallObstacleChance = 0.2f;

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit (Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }


    // 장애물 생성
    public void SpawnObstacle()
    {
        // 어떤 장애물을 생성할 것인지 결정
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f); // Random.Range 메서드 사용

        if (random < tallObstacleChance)
        {
            obstacleToSpawn = tallObstaclePrefab;
        }

        // 랜덤 포인트를 결정
        int obstacleSpawnIndex = Random.Range(2, 5); // 인덱스 2,3,4
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // 그 장소에 장애물 생성
        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }



    // 코인생성
    public void SpawnCoins()
    {
        int coinsToSpawn = 5; // 생성하려는 동전 수
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform); // 인스턴스화로 코인을 스폰
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }


    // 코인 랜덤 생성
    Vector3 GetRandomPointInCollider (Collider collider)
    {
        // 콜라이더 (ground Tile)의 x,y,z축의 최소/최대값을 지정해서 코인을 랜덤생성함
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1; // 코인의 y축은 1만큼 올라감
        return point;
    }
}
