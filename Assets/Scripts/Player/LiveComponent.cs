using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveComponent : MonoBehaviour
{
    private void Muerte ()
    {
        GameManager.Instance.ResetRoom();
    }
}
