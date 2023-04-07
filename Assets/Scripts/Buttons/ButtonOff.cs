using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOff : MonoBehaviour
{
    [SerializeField]
    private string _value;

    private void OnMouseDown()
    {
        ButtonManager.Instance.SetFalse(_value);
    }
}
