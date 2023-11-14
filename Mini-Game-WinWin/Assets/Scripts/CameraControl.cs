using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // ī�޶� ������ ���� �߽������� ���� JengaSpawner ������Ʈ
    public GameObject JengaSpawner;

    // ���콺 �Է¿� ���� ȸ���� ���� �����ϴ� ������
    private float xRotateMove, yRotateMove;

    // ī�޶��� ȸ�� �ӵ�
    public float rotateSpeed = 500.0f;

    // ī�޶��� ��ũ�� �ӵ�
    public float scrollSpeed = 2000.0f;

    void Update()
    {
        // ���콺 ������ ��ư�� ������ �� ����
        if (Input.GetMouseButton(1))
        {
            // ���콺�� X �� Y �̵� ���� �ð��� ȸ�� �ӵ��� ���Ͽ� ȸ������ ���
            xRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;
            yRotateMove = Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;

            // JengaSpawner�� ���� ��ġ�� ����
            Vector3 JengaPosition = JengaSpawner.transform.position;

            // ī�޶� �־��� �߽���(JengaPosition)�� �������� ȸ����Ŵ
            // ���콺�� Y �̵� ���� ���� x �� ������, X �̵� ���� ���� y �� ������ ȸ��
            transform.RotateAround(JengaPosition, Vector3.right, -yRotateMove);
            transform.RotateAround(JengaPosition, Vector3.up, xRotateMove);

            // ī�޶� �׻� �߽����� �ٶ󺸵��� ��
            transform.LookAt(JengaPosition);
        }
        // ���콺 ������ ��ư�� ������ �ʾ��� �� ���� (��ũ�� ����)
        else
        {
            // ���콺 ��ũ�� �� ���� ������
            float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

            // ī�޶� �ٶ󺸴� ������ �������� �̵��� ���͸� ���
            Vector3 cameraDirection = this.transform.localRotation * Vector3.forward;

            // ī�޶� ��ũ�� ���� ���� �̵���Ŵ
            this.transform.position += cameraDirection * Time.deltaTime * scrollWheel * scrollSpeed;
        }
    }
}
