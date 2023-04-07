using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOn : MonoBehaviour
{
    [SerializeField]
    private string _value;

    private void OnMouseDown()
    {
        ButtonManager.Instance.SetTrue(_value);
    }
}
