using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Header : MonoBehaviour
{
    private void Awake()
    {
        TextMeshProUGUI textTMP = GetComponent<TextMeshProUGUI>();
        MenuHeaderData.Get(out string text);
        textTMP.text = text;
    }
}
