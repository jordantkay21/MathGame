using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoSingleton<ButtonManager>
{

    public void SetTrue (string value)
    {
        CalculationManager.Instance.SetParamters(value, true);
    }

    public void SetFalse (string value)
    {
        CalculationManager.Instance.SetParamters(value, false);
    }


}
