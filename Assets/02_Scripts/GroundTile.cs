
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
}
