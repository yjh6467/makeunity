using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint; //스폰 포인트의 위치를 저장
    public GameObject[] prefabs;

    float spawnTime = 0f;

    void Awake() 
    {
        spawnPoint = GetComponentsInChildren<Transform>(); //스포너가 자식으로 갖고있는 포인트들의 위치를 가져옴
    }
   
    void Update()
    {
        spawnTime += Time.deltaTime; //마지막 프레임이 완료된 후 시간을 계속 더해줌

        if (spawnTime > 1f) // 1초가 지난다면
        {
            spawnTime = 0f; //다시 0
            Spawn();//몬스터 스폰
        }
    }

    void Spawn()
    {
        GameObject monster = Instantiate(prefabs[Random.Range(0, 2)], transform); //몬스터 생성하기(프리팹에 있는 몬스터중 랜덤하게 0번째 인덱스의 몬스터부터 1번째 몬스터)
        monster.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;// 스폰 위치는 spawnPoint의 1번부터 마지막까지(0번은 스포너 위치(0,0))   
    }
}
