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
            DisplayManager.Instance.DisplayGameMessage("SELECT YOUR OPERATORS AND PLACE VALUES");
            equation = CalculationManager.Instance.SetEquation();
            DisplayManager.Instance.DisplayEquation(equation);
        }

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
