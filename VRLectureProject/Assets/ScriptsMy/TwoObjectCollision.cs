using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoObjectCollision : MonoBehaviour
{
    public GameObject object1; // 첫 번째 오브젝트
    public GameObject object2; // 두 번째 오브젝트

    public GameObject otherObject; // 다른 오브젝트
    public string functionName; // 실행 할 함수 이름

    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject == object1 || other.gameObject == object2) && (gameObject == object1 || gameObject == object2))
        {
            OnObjectsTouch(); // 두 오브젝트가 닿았을 때 실행할 함수
        }
    }

    private void OnObjectsTouch()
    {
        if (otherObject != null && !string.IsNullOrEmpty(functionName))
            otherObject.SendMessage(functionName, SendMessageOptions.DontRequireReceiver);
    }
}
