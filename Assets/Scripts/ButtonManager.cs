using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoSingleton<ButtonManager>
{
    [SerializeField]
    private string selectedNumber;

    /// <summary>
    /// Set the value each button holds
    /// Add | Subtract | Multiply | Divide
    /// Ones | Tens | Hundreds | Thousands
    /// </summary>
    /// <param name="value"></param>
    public void SetButtonValue(string value)
    {
        CalculationManager.Instance.SetParameters(value);
        DisplayManager.Instance.DisplayParameterSelections(value);
    }

    public void GenerateEquation()
    {
        int operatorsList = CalculationManager.Instance.avaialableOperators.Count;
        int numbersList = CalculationManager.Instance.availableNumbers.Count;
        string equation;

        if (operatorsList == 0 || numbersList == 0)
        {
            DisplayManager.Instance.DisplayNoParametersWarning();
        }
        else
        {
            equation = CalculationManager.Instance.SetEquation();
            DisplayManager.Instance.DisplayEquation(equation);
        }

    }

    public void CheckAnswer()
    {
        string answerS = DisplayManager.Instance.UserInput();
        if (answerS != "")
        {
            int answer = int.Parse(answerS, System.Globalization.NumberStyles.Number);
            CalculationManager.Instance.CheckAnswer(answer);
            DisplayManager.Instance.ClearInputField();
        }
        else
        {
            return;
        }

    }

    public void StartGame(bool onOff)
    {
        int operatorsList = CalculationManager.Instance.avaialableOperators.Count;
        int numbersList = CalculationManager.Instance.availableNumbers.Count;
        GenerateEquation();

        if (operatorsList != 0 && numbersList != 0)
        {
            DisplayManager.Instance.StartStopGame(onOff);
        }
    }

    public void StopGame(bool onOff)
    {
        DisplayManager.Instance.StartStopGame(onOff);

    }



}
