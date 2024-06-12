
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    public PauseMenu pauseMenu;


    public float speed = 8;
    public Rigidbody rb;
    
    float HorizontalInput;
    public float horizontalMultiplier = 2; // ���� �̵� (a,d) ���� (�� ������)

    public float speedIncreasePerPoint = 0.1f; // ������ ���� �ӵ��� ���ݾ� ������

    public float jumpForce = 400f;
    public LayerMask groundMask;

    AudioManager audioManager;
    public GameOverPanel gameOverPanel;

    private Animator anim;



    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // �̵� 
    private void FixedUpdate()
    {
        if (!alive) return; // ������ �Լ� ���� ����

        anim.SetBool("Run", true);
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * HorizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");

        // �����̽� �����ٸ� ����-
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // ������ ��쵵 ����
        if (transform.position.y < -5)
        {
            Die();
        }
    }


    // ����
    public void Die()
    {
        if (alive)
        {
            audioManager.PlaySFX(audioManager.die);
            alive = false;
            gameOverPanel.ShowGameOverPanel(); // GameOverPanel�� ShowGameOverPanel �޼��� ȣ��
        }
    }


    // ����
    void Jump()
    {
        audioManager.PlaySFX(audioManager.jump);

        // ĳ���� �ݶ��̴��� ���̸� ������
        float height = GetComponent<Collider>().bounds.size.y;

        // ĳ���� �ݶ��̴� �ϴܿ��� �߻�Ǵ� ����
        Ray ray = new Ray(transform.position, Vector3.down);

        // ����ĳ��Ʈ�� �����Ͽ� ���� ��Ҵ��� Ȯ��
        bool isGrounded = Physics.Raycast(ray, height / 2 + 0.1f, groundMask);

        // ���� ������� ����
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

}
