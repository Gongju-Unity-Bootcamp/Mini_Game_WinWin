using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaSpawner : MonoBehaviour
{
    public GameObject jengaPrefab;  // Jenga 블록의 프리팹을 할당하는 변수
    public int jengaLayers = 5;     // Jenga 블록을 쌓을 층 수를 지정하는 변수

    private void Start()
    {
        CreateJengaStack();  // 게임이 시작될 때 Jenga 블록을 생성하는 메서드 호출
    }

    void Update()
    {

    }

    // Jenga 블록을 생성하는 메서드
    void CreateJengaStack()
    {
        for (int index = 0; index < jengaLayers; ++index)
        {
            // Jenga 블록 프리팹을 이용하여 새로운 블록을 생성하고, 초기 위치 및 회전 설정
            GameObject jenga = Instantiate(jengaPrefab, new Vector3(0, index, 0), Quaternion.identity);

            // 새로 생성된 Jenga 블록을 이 스크립트를 적용한 오브젝트의 자식으로 설정
            jenga.transform.parent = transform;
        }
    }
}
