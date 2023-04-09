using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoSingleton<ButtonManager>
{
    [SerializeField]
    private string selectedNumber;

    public void SetTrueFalse(string value)
    {
        CalculationManager.Instance.SetParameters(value);
        DisplayManager.Instance.DisplayParamters(value);
    }

    public void GenerateEquation()
    {
        string equation;
        equation = CalculationManager.Instance.SetEquation();
        DisplayManager.Instance.DisplayEquation(equation);
    }
  


}
