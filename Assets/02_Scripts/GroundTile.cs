
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


    // ��ֹ� ����
    public void SpawnObstacle()
    {
        // � ��ֹ��� ������ ������ ����
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f); // Random.Range �޼��� ���

        if (random < tallObstacleChance)
        {
            obstacleToSpawn = tallObstaclePrefab;
        }

        // ���� ����Ʈ�� ����
        int obstacleSpawnIndex = Random.Range(2, 5); // �ε��� 2,3,4
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // �� ��ҿ� ��ֹ� ����
        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }



    // ���λ���
    public void SpawnCoins()
    {
        int coinsToSpawn = 5; // �����Ϸ��� ���� ��
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform); // �ν��Ͻ�ȭ�� ������ ����
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }


    // ���� ���� ����
    Vector3 GetRandomPointInCollider (Collider collider)
    {
        // �ݶ��̴� (ground Tile)�� x,y,z���� �ּ�/�ִ밪�� �����ؼ� ������ ����������
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1; // ������ y���� 1��ŭ �ö�
        return point;
    }
}
