using UnityEngine;
using TMPro;
using System.Collections;

public class UIPlayerText : MonoBehaviour
{
    private TextMeshProUGUI tmText;

    private void Awake()
    {
        tmText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(ClearTextAfterDelay());

    }

    private IEnumerator ClearTextAfterDelay()
    {
        yield return new WaitForSeconds(2);
        tmText.text = string.Empty;
    }
}
