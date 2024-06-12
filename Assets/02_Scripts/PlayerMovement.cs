
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;


    public float speed = 10;
    public Rigidbody rb;
    float HorizontalInput;
    public float horizontalMultiplier = 2; // ���� �̵� (a,d) ���� (�� ������)

    // �̵� 
    private void FixedUpdate()
    {
        if (!alive) return; // ������ �Լ� ���� ����

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * HorizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");

        // ������ ��쵵 ����
        if (transform.position.y < -5)
        {
            Die();
        }
    }

    // ����
    public void Die()
    {
        alive = false;
        Invoke("Restart", 2);
        
        
    }

    // �����
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
