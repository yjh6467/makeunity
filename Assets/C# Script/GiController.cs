using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiController : MonoBehaviour
{
    private float lifetime = 3f; //�Ⱑ �����ִ� �ð�
    private float spawnTime; //�����ð��� �����ϱ� ���� ����

    void Start()
    {
        spawnTime = Time.time; // �����Ǿ��� �� ���� �ð��� ����
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTime > lifetime)
        { //���� �ð��� ������ �ڵ� �Ҹ� 
            Destroy(this.gameObject);
        }
    }
}
