using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoSingleton<ButtonManager>
{
    

    public void SetTrueFalse(string value)
    {
        CalculationManager.Instance.SetParamters(value);
        DisplayManager.Instance.DisplayParamters(value);
    }
  


}
