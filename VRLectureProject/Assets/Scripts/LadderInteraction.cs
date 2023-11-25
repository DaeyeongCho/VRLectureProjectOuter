using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private Rigidbody characterRigidbody;
    private bool isOnLadder = false;

    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            characterRigidbody.useGravity = false;
            isOnLadder = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            characterRigidbody.useGravity = true;
            isOnLadder = false;
        }
    }

    void Update()
    {
        if (isOnLadder)
        {
            // 여기에 사다리를 타는 로직을 구현합니다.
            // 예: 캐릭터를 위로 이동시키는 입력을 처리합니다.
        }
    }
}
