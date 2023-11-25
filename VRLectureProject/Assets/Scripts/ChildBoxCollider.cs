using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBoxCollider : MonoBehaviour
{
    void Start()
    {
        foreach (Transform child in transform)
        {
            // BoxCollider 컴포넌트를 추가합니다.
            BoxCollider collider = child.gameObject.AddComponent<BoxCollider>();

            // 프리팹의 이름에 따라 BoxCollider의 Y축 크기를 조정합니다.
            if (child.gameObject.name == "Tile_Road_Edge_End_Solo"
                || child.gameObject.name == "Tile_Road_End"
                || child.gameObject.name == "Tile_Road_End_Edge"
                || child.gameObject.name == "Tile_Road_Inner_Corner_3_Edge"
                || child.gameObject.name == "Tile_Road_Solo"
                || child.gameObject.name == "Tile_Road_Solo_Corner") // 프리팹 이름을 적절히 수정하세요.
            {
                Vector3 size = collider.size;
                size.y = 1.76f; // Y축 크기를 1.76으로 설정합니다.
                collider.size = size;
            }
            // 그 외의 경우, BoxCollider의 기본 크기를 유지합니다.
        }
    }
}
