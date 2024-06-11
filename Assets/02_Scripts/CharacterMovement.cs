using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f; // 달리기 속도

    private Animator anim;
    private Rigidbody rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 키보드 입력을 받음
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // 입력값을 이용하여 이동 벡터 계산
        Vector3 velocity = new Vector3(inputX, 0f, inputY).normalized;
        velocity *= speed;
        rb.velocity = velocity;


        // 달리기 모션을 취하도록 설정
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
