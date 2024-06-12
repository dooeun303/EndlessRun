
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    public GameObject groundTile;
    public Vector3 nextSpawnPoint;

    // Ÿ�� ���� �Լ�
    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        
        // SpawnItems�� True�̸� ��ֹ��� ������ ����
        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();
        }
    
    }


    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 3)
            {
                SpawnTile(false); // 3���� Ÿ���� �����ɶ� ���� spawnItems �� false -> ��ֹ�/���λ��� x
            }
            else
            {
                SpawnTile(true);
            }
        }
    }

}
