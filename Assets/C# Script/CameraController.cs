using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player; // �÷��̾��� ��ġ�� �������� ����
    float cameraMoveSpeed = 1f; // ī�޶� �̵� �ӵ� ����
    Vector3 cameraPosition = new Vector3(0, 0, -5); // ī�޶��� z��ǥ�� �̵����� �ε巴�� ī�޶� �����̱� ����
    Vector2 mapSize_half = new Vector2(57, 32); // �� ũ�� ũ�� ����
    Vector2 cameraSize = new Vector2(21.5f, 9.5f); // ī�޶� ũ��� �÷��̾ ����� ũ��

    void Start()
    {
        this.player = GameObject.Find("player");
    }

    
    void Update()
    {
        //����Ƽ���� ��ü������ �����ϴ� Lerp�Լ��� �̿��� ī�޶��� �ε巯�� �������� ǥ��
        transform.position = Vector3.Lerp(transform.position, this.player.transform.position + cameraPosition, Time.deltaTime * cameraMoveSpeed);

        //ī�޶� ���� ȭ�� ������ ������ �ʵ��� �ϴ� �ڵ�
        float clampX = Mathf.Clamp(transform.position.x, -mapSize_half.x + cameraSize.x, mapSize_half.x - cameraSize.x);
        float clampY = Mathf.Clamp(transform.position.y, -mapSize_half.y + cameraSize.y, mapSize_half.y - cameraSize.y);

        transform.position = new Vector3(clampX, clampY, -10f);

    }
}
