using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint; //���� ����Ʈ�� ��ġ�� ����
    public GameObject[] prefabs;

    float spawnTime = 0f;

    void Awake() 
    {
        spawnPoint = GetComponentsInChildren<Transform>(); //�����ʰ� �ڽ����� �����ִ� ����Ʈ���� ��ġ�� ������
    }
   
    void Update()
    {
        spawnTime += Time.deltaTime; //������ �������� �Ϸ�� �� �ð��� ��� ������

        if (spawnTime > 1f) // 1�ʰ� �����ٸ�
        {
            spawnTime = 0f; //�ٽ� 0
            Spawn();//���� ����
        }
    }

    void Spawn()
    {
        GameObject monster = Instantiate(prefabs[Random.Range(0, 2)], transform); //���� �����ϱ�(�����տ� �ִ� ������ �����ϰ� 0��° �ε����� ���ͺ��� 1��° ����)
        monster.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;// ���� ��ġ�� spawnPoint�� 1������ ����������(0���� ������ ��ġ(0,0))   
    }
}
