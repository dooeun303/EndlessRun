using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject player;
    private Vector3 pos = new Vector3(0, 10, -10); 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ī�޶� -> 0, 10, -10
        // ��, �÷��̾��� ��ǥ���� 0, 10, -10 �����ָ�
        this.gameObject.transform.position = player.transform.position + pos;
    }
}
