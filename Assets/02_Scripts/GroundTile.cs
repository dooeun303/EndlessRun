
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        SpawnCoins();
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

    // ��ֹ� ����
    public GameObject obstaclePrefab;

    void SpawnObstacle()
    {
        // ���� ����Ʈ�� ����
        int obstacleSpawnIndex = Random.Range(2, 5); // �ε��� 2,3,4
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // �� ��ҿ� ��ֹ� ����
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }



    // ���λ���
    public GameObject coinPrefab;
    void SpawnCoins()
    {
        int coinsToSpawn = 10; // �����Ϸ��� ���� ��
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
