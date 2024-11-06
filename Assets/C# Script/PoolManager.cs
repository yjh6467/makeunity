using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�۵��� �ȵǿ� �ФФ�

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs; //prefabs�� ������ �迭
    private List<GameObject>[] pools; //Ǯ���� ����ϴ� ����Ʈ ����
    public static PoolManager instance; //�̱��� ���� �������� �� ��ũ��Ʈ�� �ٸ� ��ũ��Ʈ������ ���� �����ϰ� ��

    void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        pools = new List<GameObject>[prefabs.Length]; //prefab�� ���� ��ŭ ����Ʈ �迭 ����

        for (int i = 0; i < prefabs.Length; i++) //����Ʈ �ʱ�ȭ
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject GetMonster(int Index) //���� ������Ʈ�� ��ȯ�ϴ� �Լ�
    {
        GameObject select = null; //���� ������Ʈ�� ��ȯ�ϱ� ���� ��������

        foreach (GameObject item in pools[Index]) //pool�� �ε��� ����Ʈ�� �����Ϳ� ����
        {
            if (!item.activeSelf)
            { //���빰 ������Ʈ�� ��Ȱ��ȭ �Ǿ��ִ°� �ִٸ� 
                select = item;// ��Ȱ��ȭ �Ǿ��ִ� ������Ʈ �Ҵ�
                select.SetActive(true); //Ȱ��ȭ ��Ű��
                break;
            }
        }
        if (!select) 
        {
            select = Instantiate(prefabs[Index], transform); //���Ӱ� ������Ʈ�� �����ϰ� �Ҵ�
            pools[Index].Add(select); //������ ������Ʈ�� Ǯ ����Ʈ�� �߰�
        }
        return select; //���� ������Ʈ ��ȯ
    }

    public void ReturnMonster(GameObject monster) //���� ������Ʈ�� ��ȯ�ϴ� �Լ�
    {
        monster.SetActive(false);
    }
}
