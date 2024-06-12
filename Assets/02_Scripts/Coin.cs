using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90f; // 동전회전효과. 매초에 90도 회전

    private void OnTriggerEnter (Collider other)
    {
        // 장애물 안에 코인이 들어가면 코인 파괴
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        // 플레이어와 충돌했는지 확인 (오브젝트가 플레이어가 아니면 함수 실행X)
        if (other.gameObject.name != "Player")
        {
            return;
        }

        // 플레이어의 점수에 추가
        GameManager.inst.IncrementScore();

        // 코인 오브젝트 파괴
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime); // 매초에 축을 90씩 회전
    }
}
