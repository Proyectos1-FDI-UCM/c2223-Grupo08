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

    #region properties
    private Dictionary<string, Buttons> buttons = new Dictionary<string, Buttons>() {
        { "Left", Buttons.Left},
        { "Right", Buttons.Right },
        { "Jump", Buttons.Jump },
        { "Drop", Buttons.Drop},
        { "Reset", Buttons.Reset }
    };
    #endregion

    void Start()
    {
        string auxText = "";
        string[] messages = text.Split("'");
        for (int i = 0; i < messages.Length; i++)
        {
            if(i % 2 == 0)
            {
                auxText += messages[i];
            }
            else
            {
                auxText += ConfigScript.ButtonsCodes[buttons[messages[i]]].ToString();
            }
        }
        SignText.text = auxText;
    }
}
