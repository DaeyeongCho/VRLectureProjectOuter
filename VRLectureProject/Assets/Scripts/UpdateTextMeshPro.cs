using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateTextMeshPro : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    public void ChangeText(string newText)
    {
        textMesh.text = newText;
    }
}
