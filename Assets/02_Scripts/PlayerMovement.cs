
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;


    public float speed = 10;
    public Rigidbody rb;
    float HorizontalInput;
    public float horizontalMultiplier = 2; // 수평 이동 (a,d) 설정 (더 빨라짐)

    // 이동 
    private void FixedUpdate()
    {
        if (!alive) return; // 죽으면 함수 실행 중지

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * HorizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");

        // 떨어진 경우도 죽음
        if (transform.position.y < -5)
        {
            Die();
        }
    }

    // 죽음
    public void Die()
    {
        alive = false;
        Invoke("Restart", 2);
        
        
    }

    // 재시작
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
