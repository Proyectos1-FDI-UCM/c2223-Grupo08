using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementSizeBarra : MonoBehaviour
{
    private Vector2 _scale;
    // Start is called before the first frame update
    void Start()
    {
        _scale= transform.localScale;
    }

    public void ResizeBar(int size)
    {
        transform.localScale = new Vector3 ((_scale.x/5)*size , _scale.y,1);
        Debug.Log(_scale);
    }
}
