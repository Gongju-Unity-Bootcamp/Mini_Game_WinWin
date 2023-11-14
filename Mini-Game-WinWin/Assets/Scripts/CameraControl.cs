using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // 카메라가 주위를 도는 중심점으로 사용될 JengaSpawner 오브젝트
    public GameObject JengaSpawner;

    // 마우스 입력에 따라 회전할 양을 저장하는 변수들
    private float xRotateMove, yRotateMove;

    // 카메라의 회전 속도
    public float rotateSpeed = 500.0f;

    // 카메라의 스크롤 속도
    public float scrollSpeed = 2000.0f;

    void Update()
    {
        // 마우스 오른쪽 버튼이 눌렸을 때 실행
        if (Input.GetMouseButton(1))
        {
            // 마우스의 X 및 Y 이동 값에 시간과 회전 속도를 곱하여 회전량을 계산
            xRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;
            yRotateMove = Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;

            // JengaSpawner의 현재 위치를 저장
            Vector3 JengaPosition = JengaSpawner.transform.position;

            // 카메라를 주어진 중심점(JengaPosition)을 기준으로 회전시킴
            // 마우스의 Y 이동 값에 따라 x 축 주위로, X 이동 값에 따라 y 축 주위로 회전
            transform.RotateAround(JengaPosition, Vector3.right, -yRotateMove);
            transform.RotateAround(JengaPosition, Vector3.up, xRotateMove);

            // 카메라가 항상 중심점을 바라보도록 함
            transform.LookAt(JengaPosition);
        }
        // 마우스 오른쪽 버튼이 눌리지 않았을 때 실행 (스크롤 동작)
        else
        {
            // 마우스 스크롤 휠 값을 가져옴
            float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

            // 카메라가 바라보는 방향을 기준으로 이동할 벡터를 계산
            Vector3 cameraDirection = this.transform.localRotation * Vector3.forward;

            // 카메라를 스크롤 값에 따라 이동시킴
            this.transform.position += cameraDirection * Time.deltaTime * scrollWheel * scrollSpeed;
        }
    }
}
