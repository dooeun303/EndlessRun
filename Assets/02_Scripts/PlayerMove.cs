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
        dir.Normalize(); // �밢�� ���� ������ �ӵ� �����ϰ� ��

        CheckGround();

        // �������
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
            // ���� �ٶ󺸴� ������ ��ȣ != ���ư� ���� ��ȣ (���ݴ� ���⺼�� �����̴°� �ذ�)
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

    // �����Ҷ� ����� ���� ��Ҵ��� Ȯ���ϴ� �Լ�
    void CheckGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + (Vector3.up * 0.2f), Vector3.down, out hit, 0.4f, layer))
        // ĳ���� �߳����� 0.2��ŭ ������ �Ʒ��� 0.4��ŭ������ �������� ��. �� ���� �ȿ��� �츮�� ������ ���̾ ����Ǹ� hit�� ��ƶ�
        {
            ground = true;
        } else
        {
            ground = false;
        }
    }
}
