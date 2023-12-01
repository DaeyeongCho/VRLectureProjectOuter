using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoObjectCollision : MonoBehaviour
{
    public GameObject object1; // ù ��° ������Ʈ
    public GameObject object2; // �� ��° ������Ʈ

    public GameObject otherObject; // �ٸ� ������Ʈ
    public string functionName; // ���� �� �Լ� �̸�

    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject == object1 || other.gameObject == object2) && (gameObject == object1 || gameObject == object2))
        {
            OnObjectsTouch(); // �� ������Ʈ�� ����� �� ������ �Լ�
        }
    }

    private void OnObjectsTouch()
    {
        if (otherObject != null && !string.IsNullOrEmpty(functionName))
            otherObject.SendMessage(functionName, SendMessageOptions.DontRequireReceiver);
    }
}
