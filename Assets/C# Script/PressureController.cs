using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureController : MonoBehaviour
{
    float speed = 1f; // ������ �ӵ�
    public float maxHp = 30f; //������ �ִ� ü��
    private float currHp; //������ ���� hp

    GameObject player; //�÷��̾� ������Ʈ
    GameObject tower; //Ÿ�� ������Ʈ
    public GameObject hpbar; // ü�¹ٸ� ���̰ų� ������ �ʰ� �ϱ� ����
    public RectTransform hpfront; // ü�¹��� �������� ������ ����ϱ� ����

    void Start()
    {
        this.player = GameObject.Find("player"); //�÷��̾��� ã��
        this.tower = GameObject.Find("tower"); //Ÿ�� ã��

        currHp = maxHp; // ���� ���۽� �ִ�ü�¿� ���� ���� ü�� ����
        hpbar.SetActive(false); // ü�¹� �����
    }
    void Update()
    {
        if (currHp <= 0)
        { 
            Destroy(gameObject); 
            //ü���� 0�̵Ǹ� ���� ��Ȱ��ȭ(Ǯ�� ��� ����)
            //PoolManager.instance.ReturnMonster(gameObject);
        }
    }
    void FixedUpdate()
    {
        Vector3 monsterPosition = transform.position; // ������ ��ġ
        Vector3 playerPosition = player.GetComponent<Transform>().position; //�÷��̾��� ��ġ
        Vector3 towerPosition = tower.GetComponent<Transform>().position; //Ÿ���� ��ġ

        float towerToMonster = Vector3.Distance(monsterPosition, towerPosition); //���Ϳ� Ÿ������ �Ÿ�
        float playerToMonster = Vector3.Distance(monsterPosition, playerPosition); // ���Ϳ� �÷��̾�� �Ÿ�

        if (towerToMonster > playerToMonster) //�÷��̾��� �Ÿ��� �� �����ٸ�
        {
            transform.position = Vector3.MoveTowards(monsterPosition, playerPosition, speed * Time.deltaTime); // �÷��̾ ���󰡱�(Time.deltaTIme = ������ �ӵ��� ������� ������ �ӵ�)
        }
        else
        {
            transform.position = Vector3.MoveTowards(monsterPosition, towerPosition, speed * Time.deltaTime); //Ÿ���� ����    
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("gi")) //gi �±׸� ���� ������Ʈ�� �ε�����
        {
            hpbar.SetActive(true); //ü�¹� ���̱�
            if (currHp > 0)
            { //���� ü���� �����ִٸ�
                currHp -= 1.0f; //���� ü�� �A��
                hpfront.localScale = new Vector3(currHp / maxHp, 1.0f, 1.0f); // ���� ü���� �ִ� ü������ ����� hp����

                Destroy(collision.gameObject); //�浹�� ��� �ı�

            }
        }
    }
}
