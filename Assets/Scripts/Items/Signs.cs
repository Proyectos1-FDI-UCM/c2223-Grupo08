using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Signs : MonoBehaviour
{
    [SerializeField] private TMP_Text SignText;
    [TextArea][SerializeField] private string text;

    // Start is called before the first frame update
    void Start()
    {
        SignText.text = text;
    }
}
