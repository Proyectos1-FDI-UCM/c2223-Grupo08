using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Signs : MonoBehaviour
{
    #region references
    /// <summary>
    /// Referencia al text del cartel
    /// </summary>
    [SerializeField] private TMP_Text SignText;

    /// <summary>
    /// Mensaje a mostrar en el cartel
    /// </summary>
    [TextArea][SerializeField] private string text;
    #endregion

    void Start()
    {
        SignText.text = text;
    }
}
