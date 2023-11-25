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
            // ���⿡ ��ٸ��� Ÿ�� ������ �����մϴ�.
            // ��: ĳ���͸� ���� �̵���Ű�� �Է��� ó���մϴ�.
        }
    }
}
