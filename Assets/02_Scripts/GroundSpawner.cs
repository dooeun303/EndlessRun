
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    public GameObject groundTile;
    public Vector3 nextSpawnPoint;

    // 타일 생성 함수
    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        
        // SpawnItems가 True이면 장애물과 코인을 생성
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
                SpawnTile(false); // 3개의 타일이 생성될때 까지 spawnItems 를 false -> 장애물/코인생성 x
            }
            else
            {
                SpawnTile(true);
            }
        }
    }

}
