using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;  // ���콺 Ŭ�� ������ ������Ʈ �߽� ���� �������� �����ϴ� ����
    private float mZCoord;    // ī�޶󿡼� ������Ʈ������ �Ÿ��� �����ϴ� ����

    // ���콺 Ŭ�� �� ȣ��Ǵ� �޼���
    void OnMouseDown()
    {
        // ī�޶󿡼� ������Ʈ������ �Ÿ��� ����Ͽ� mZCoord�� ����
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // ������Ʈ�� ���� ��ġ�� ���콺 Ŭ�� ���� ���� �������� ����Ͽ� mOffset�� ����
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    // ���� ���콺 ��ġ�� ���� ��ǥ�� ��ȯ�Ͽ� ��ȯ�ϴ� �޼���
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        // ���콺 Ŭ�� ������ z ��ǥ�� mZCoord ������ ����
        mousePoint.z = mZCoord;

        // ����� ���콺 ��ġ�� ���� ��ǥ�� ��ȯ�Ͽ� ��ȯ
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    // ���콺 �巡�� ���� �� ȣ��Ǵ� �޼���
    void OnMouseDrag()
    {
        // ���� ���콺 ��ġ�� �������� ���� ���� �̿��Ͽ� ������Ʈ�� ��ġ�� ����
        Vector3 newPosition = GetMouseWorldPos() + mOffset;

        // x�� z ���� ���콺 Ŭ���� ��ġ�� ���� �̵��ϵ��� ����
        // y ���� ���� ������Ʈ�� y ��ǥ�� �����Ͽ� y �� �̵��� ����
        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
    }
}