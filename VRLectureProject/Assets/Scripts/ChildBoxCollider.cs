using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBoxCollider : MonoBehaviour
{
    void Start()
    {
        foreach (Transform child in transform)
        {
            // BoxCollider ������Ʈ�� �߰��մϴ�.
            BoxCollider collider = child.gameObject.AddComponent<BoxCollider>();

            // �������� �̸��� ���� BoxCollider�� Y�� ũ�⸦ �����մϴ�.
            if (child.gameObject.name == "Tile_Road_Edge_End_Solo"
                || child.gameObject.name == "Tile_Road_End"
                || child.gameObject.name == "Tile_Road_End_Edge"
                || child.gameObject.name == "Tile_Road_Inner_Corner_3_Edge"
                || child.gameObject.name == "Tile_Road_Solo"
                || child.gameObject.name == "Tile_Road_Solo_Corner") // ������ �̸��� ������ �����ϼ���.
            {
                Vector3 size = collider.size;
                size.y = 1.76f; // Y�� ũ�⸦ 1.76���� �����մϴ�.
                collider.size = size;
            }
            // �� ���� ���, BoxCollider�� �⺻ ũ�⸦ �����մϴ�.
        }
    }
}
