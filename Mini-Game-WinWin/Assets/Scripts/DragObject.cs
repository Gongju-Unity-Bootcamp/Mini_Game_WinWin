using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;  // 마우스 클릭 지점과 오브젝트 중심 간의 오프셋을 저장하는 변수
    private float mZCoord;    // 카메라에서 오브젝트까지의 거리(z 좌표)를 저장하는 변수

    // 마우스 왼쪽 버튼이 클릭되었을 때 호출되는 메서드
    private void OnMouseDown()
    {
        // 오브젝트의 현재 위치를 화면 좌표로 변환하여 z 좌표를 가져옴
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // 마우스 클릭 지점과 오브젝트 중심 간의 오프셋 계산
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    // 현재 마우스 위치를 세계 좌표로 변환하여 반환하는 메서드
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        // 마우스 위치의 z 좌표를 mZCoord 값으로 설정
        mousePoint.z = mZCoord;

        // 변경된 마우스 위치를 세계 좌표로 변환하여 반환
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    // 마우스 드래그 중일 때 호출되는 메서드
    private void OnMouseDrag()
    {
        // 현재 마우스 위치에 오프셋을 더한 값을 이용하여 오브젝트의 위치를 설정
        transform.position = GetMouseWorldPos() + mOffset;
    }
}
