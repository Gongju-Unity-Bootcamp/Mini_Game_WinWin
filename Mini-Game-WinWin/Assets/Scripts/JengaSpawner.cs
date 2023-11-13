using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaSpawner : MonoBehaviour
{
    public GameObject jengaPrefab;  // Jenga ����� �������� �Ҵ��ϴ� ����
    public int jengaLayers = 5;     // Jenga ����� ���� �� ���� �����ϴ� ����

    private void Start()
    {
        CreateJengaStack();  // ������ ���۵� �� Jenga ����� �����ϴ� �޼��� ȣ��
    }

    void Update()
    {

    }

    // Jenga ����� �����ϴ� �޼���
    void CreateJengaStack()
    {
        for (int index = 0; index < jengaLayers; ++index)
        {
            // Jenga ��� �������� �̿��Ͽ� ���ο� ����� �����ϰ�, �ʱ� ��ġ �� ȸ�� ����
            GameObject jenga = Instantiate(jengaPrefab, new Vector3(0, index, 0), Quaternion.identity);

            // ���� ������ Jenga ����� �� ��ũ��Ʈ�� ������ ������Ʈ�� �ڽ����� ����
            jenga.transform.parent = transform;
        }
    }
}
