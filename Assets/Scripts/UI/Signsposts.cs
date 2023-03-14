using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signsposts : MonoBehaviour
{
    [SerializeField] private GameObject Info;
    [SerializeField] private GameObject ShowInfo;

    [SerializeField] private LayerMask Character;

    public bool InfoEnabled;
    public bool ShowInfoEnabled;

    // Start is called before the first frame update
    void Start()
    {
        Info.SetActive(false);
        ShowInfo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        InfoEnabled = Physics2D.OverlapCircle(this.transform.position, 7f, Character);

        if (InfoEnabled == true)
        {
            Info.SetActive(true);
        }
        if (InfoEnabled == false)
        {
            Info.SetActive(false);
        }

        ShowInfoEnabled = Physics2D.OverlapCircle(this.transform.position, 7f, Character);

        if (ShowInfoEnabled == true && Input.GetKeyDown(KeyCode.Return))
        {
            ShowInfo.SetActive(true);
        }
        if (ShowInfoEnabled == false)
        {
            ShowInfo.SetActive(false);
        }
    }
}
