using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10f;
    public float jumpHeight = 3f;
    public float rotSpeed = 3f;

    private Animator anim;

    private Vector3 dir = Vector3.zero;

    private bool ground = false;
    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        dir.Normalize(); // 대각선 으로 갈때도 속도 동일하게 함

        CheckGround();

        // 점프기능
        if (Input.GetButtonDown("Jump") && ground)
        {
            Vector3 jumpPower = Vector3.up * jumpHeight;
            rb.AddForce(jumpPower, ForceMode.VelocityChange);
        }

    }

    private void FixedUpdate()
    {
        if (dir != Vector3.zero) 
        {
            anim.SetBool("Run", true);
            // 지금 바라보는 방향의 부호 != 나아갈 방향 부호 (정반대 방향볼때 버벅이는거 해결)
            if (Mathf.Sign(transform.forward.x) != Mathf.Sign(dir.x) || Mathf.Sign(transform.forward.z) != Mathf.Sign(dir.z))

                {
                    transform.Rotate(0, 1, 0);
            }
            transform.forward = Vector3.Lerp(transform.forward, dir, rotSpeed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        rb.MovePosition(this.gameObject.transform.position + dir * speed * Time.deltaTime);
    }

    // 점프할때 사용할 땅에 닿았는지 확인하는 함수
    void CheckGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + (Vector3.up * 0.2f), Vector3.down, out hit, 0.4f, layer))
        // 캐릭터 발끝보다 0.2만큼 위에서 아래로 0.4만큼길이의 레이저를 쏨. 이 길이 안에서 우리가 설정한 레이어ㅏ 검출되면 hit에 담아라
        {
            ground = true;
        } else
        {
            ground = false;
        }
    }
}
