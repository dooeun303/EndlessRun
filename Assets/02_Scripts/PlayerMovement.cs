
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    public PauseMenu pauseMenu;


    public float speed = 8;
    public Rigidbody rb;
    
    float HorizontalInput;
    public float horizontalMultiplier = 2; // 수평 이동 (a,d) 설정 (더 빨라짐)

    public float speedIncreasePerPoint = 0.1f; // 점수에 따라 속도가 조금씩 증가함

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

    // 이동 
    private void FixedUpdate()
    {
        if (!alive) return; // 죽으면 함수 실행 중지

        anim.SetBool("Run", true);
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * HorizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");

        // 스페이스 눌렀다면 점프-
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // 떨어진 경우도 죽음
        if (transform.position.y < -5)
        {
            Die();
        }
    }


    // 죽음
    public void Die()
    {
        if (alive)
        {
            audioManager.PlaySFX(audioManager.die);
            alive = false;
            gameOverPanel.ShowGameOverPanel(); // GameOverPanel의 ShowGameOverPanel 메서드 호출
        }
    }


    // 점프
    void Jump()
    {
        audioManager.PlaySFX(audioManager.jump);

        // 캐릭터 콜라이더의 높이를 가져옴
        float height = GetComponent<Collider>().bounds.size.y;

        // 캐릭터 콜라이더 하단에서 발사되는 레이
        Ray ray = new Ray(transform.position, Vector3.down);

        // 레이캐스트를 수행하여 땅에 닿았는지 확인
        bool isGrounded = Physics.Raycast(ray, height / 2 + 0.1f, groundMask);

        // 땅에 닿았으면 점프
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

}
