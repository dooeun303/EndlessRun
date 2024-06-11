using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f; // �޸��� �ӵ�

    private Animator anim;
    private Rigidbody rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Ű���� �Է��� ����
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // �Է°��� �̿��Ͽ� �̵� ���� ���
        Vector3 velocity = new Vector3(inputX, 0f, inputY).normalized;
        velocity *= speed;
        rb.velocity = velocity;


        // �޸��� ����� ���ϵ��� ����
        if (velocity != Vector3.zero)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
}
