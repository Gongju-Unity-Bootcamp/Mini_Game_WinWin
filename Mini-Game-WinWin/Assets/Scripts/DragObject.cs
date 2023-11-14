using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;  // 마우스 클릭 지점과 오브젝트 중심 간의 오프셋을 저장하는 변수
    private float mZCoord;    // 카메라에서 오브젝트까지의 거리를 저장하는 변수

    // 마우스 클릭 시 호출되는 메서드
    void OnMouseDown()
    {
        // 카메라에서 오브젝트까지의 거리를 계산하여 mZCoord에 저장
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // 오브젝트의 현재 위치와 마우스 클릭 지점 간의 오프셋을 계산하여 mOffset에 저장
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    // 현재 마우스 위치를 세계 좌표로 변환하여 반환하는 메서드
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        // 마우스 클릭 지점의 z 좌표를 mZCoord 값으로 설정
        mousePoint.z = mZCoord;

        // 변경된 마우스 위치를 세계 좌표로 변환하여 반환
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    // 마우스 드래그 중일 때 호출되는 메서드
    void OnMouseDrag()
    {
        // 현재 마우스 위치에 오프셋을 더한 값을 이용하여 오브젝트의 위치를 설정
        Vector3 newPosition = GetMouseWorldPos() + mOffset;

        // x와 z 값을 마우스 클릭한 위치를 따라 이동하도록 설정
        // y 값을 현재 오브젝트의 y 좌표로 설정하여 y 축 이동을 막음
        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
    }
}