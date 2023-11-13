using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;  // ���콺 Ŭ�� ������ ������Ʈ �߽� ���� �������� �����ϴ� ����
    private float mZCoord;    // ī�޶󿡼� ������Ʈ������ �Ÿ�(z ��ǥ)�� �����ϴ� ����

    // ���콺 ���� ��ư�� Ŭ���Ǿ��� �� ȣ��Ǵ� �޼���
    private void OnMouseDown()
    {
        // ������Ʈ�� ���� ��ġ�� ȭ�� ��ǥ�� ��ȯ�Ͽ� z ��ǥ�� ������
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // ���콺 Ŭ�� ������ ������Ʈ �߽� ���� ������ ���
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    // ���� ���콺 ��ġ�� ���� ��ǥ�� ��ȯ�Ͽ� ��ȯ�ϴ� �޼���
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        // ���콺 ��ġ�� z ��ǥ�� mZCoord ������ ����
        mousePoint.z = mZCoord;

        // ����� ���콺 ��ġ�� ���� ��ǥ�� ��ȯ�Ͽ� ��ȯ
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    // ���콺 �巡�� ���� �� ȣ��Ǵ� �޼���
    private void OnMouseDrag()
    {
        // ���� ���콺 ��ġ�� �������� ���� ���� �̿��Ͽ� ������Ʈ�� ��ġ�� ����
        transform.position = GetMouseWorldPos() + mOffset;
    }
}
