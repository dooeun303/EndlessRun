using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90f; // ����ȸ��ȿ��. ���ʿ� 90�� ȸ��

    private void OnTriggerEnter (Collider other)
    {
        // ��ֹ� �ȿ� ������ ���� ���� �ı�
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        // �÷��̾�� �浹�ߴ��� Ȯ�� (������Ʈ�� �÷��̾ �ƴϸ� �Լ� ����X)
        if (other.gameObject.name != "Player")
        {
            return;
        }

        // �÷��̾��� ������ �߰�
        GameManager.inst.IncrementScore();

        // ���� ������Ʈ �ı�
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime); // ���ʿ� ���� 90�� ȸ��
    }
}
