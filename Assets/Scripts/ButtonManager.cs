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

    public void CheckAnswer()
    {
        string answerS = DisplayManager.Instance.UserInput();
        int answer = int.Parse(answerS, System.Globalization.NumberStyles.Number);
        CalculationManager.Instance.CheckAnswer(answer);
        DisplayManager.Instance.ClearInputField();
    }

    public void StartGame(bool onOff)
    {
        DisplayManager.Instance.StartStopGame(onOff);
        GenerateEquation();
    }

    public void StopGame(bool onOff)
    {
        DisplayManager.Instance.StartStopGame(onOff);

    }



}
