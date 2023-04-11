using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculationManager : MonoSingleton<CalculationManager>
{
    #region GameSetupVariables
    [SerializeField]
    private bool _isAdd, _isSubtract, _isMultiply, _isDivide;
    [SerializeField]
    private bool _isOnes, _isTens, _isHundreds, _isThousands;
    #endregion

    #region ListsOfNumbers
    [SerializeField]
    private int[] _singleDigit = new int[9];
    [SerializeField]
    private int[] _doubleDigit = new int[90];
    [SerializeField]
    private int[] _tripleDigit = new int [900];
    [SerializeField]
    private int[] _quadDigit = new int [9000];
    #endregion

    #region CalculationVariables
    [SerializeField]
    public List<string> avaialableOperators;
    [SerializeField]
    public List<int> availableNumbers;

    [SerializeField]
    private int _num1, _num2, _correctAnswer;
    [SerializeField]
    private string _equation, _chosenOperator;
    #endregion

    public override void Init()
    {
        int v = 1;
        for(int i = 0 ; i < 9; i++)
        {
            _singleDigit[i] = v;
            v++;
        }

        for(int i = 0 ; i < 90; i++)
        {
            _doubleDigit[i] = v;
            v++;
        }

        for (int i = 0; i < 900; i++)
        {
            _tripleDigit[i] = v;
            v++;
        }

        for(int i = 0; i < 9000; i++)
        {
            _quadDigit[i] = v;
            v++;
        }
    }
    public void SetParameters(string value)
    {
        switch (value)
        {
            case "Add":
                if(_isAdd == true)
                {
                    avaialableOperators.Remove("+");
                    _isAdd = false;
                }
                else
                {
                    avaialableOperators.Add("+");
                    _isAdd = true;
                }
                break;

            case "Subtract":
                if (_isSubtract == true)
                {
                    avaialableOperators.Remove("-");
                    _isSubtract = false;
                }
                else
                {
                    avaialableOperators.Add("-");
                    _isSubtract = true;
                }
                break;
            
            case "Multiply":
                if (_isMultiply == true)
                {
                    avaialableOperators.Remove("*");
                    _isMultiply = false;
                }
                else
                {
                    avaialableOperators.Add("*");
                    _isMultiply = true;
                }
                break;
            
            case "Divide":
                if (_isDivide == true)
                {
                    avaialableOperators.Remove("/");
                    _isDivide = false;
                }
                else
                {
                    avaialableOperators.Add("/");
                    _isDivide = true;
                }
                break;

            case "Ones":
                if (_isOnes == true)
                {
                    foreach (int num in _singleDigit)
                    {
                        availableNumbers.Remove(num);
                    }
                    _isOnes = false;
                }
                else
                {
                    availableNumbers.AddRange(_singleDigit);
                    _isOnes = true;
                }
                break;

            case "Tens":
                if (_isTens == true)
                {
                    foreach (int num in _doubleDigit)
                    {
                        availableNumbers.Remove(num);
                    }
                    _isTens = false;
                }
                else
                {
                    availableNumbers.AddRange(_doubleDigit);
                    _isTens = true;
                }
                break;

            case "Hundreds":
                if (_isHundreds == true)
                {
                    foreach (int num in _tripleDigit)
                    {
                        availableNumbers.Remove(num);
                    }
                    _isHundreds = false;
                }
                else
                {
                    availableNumbers.AddRange(_tripleDigit);
                    _isHundreds = true;
                }
                break;

            case "Thousands":
                if (_isThousands == true)
                {
                    foreach (int num in _quadDigit)
                    {
                        availableNumbers.Remove(num);
                    }
                    _isThousands = false;
                }
                else
                {
                    availableNumbers.AddRange(_quadDigit);
                    _isThousands = true;
                }
                break;
        }
    }
    public string SetEquation()
    {
        _chosenOperator = avaialableOperators[Random.Range(0, avaialableOperators.Count)];


        switch (_chosenOperator)
        {
            case "+":
                _num1 = availableNumbers[Random.Range(0, availableNumbers.Count)];
                _num2 = availableNumbers[Random.Range(0, availableNumbers.Count)];

                _correctAnswer = _num1 + _num2;
                break;

            case "-":
                _num1 = availableNumbers[Random.Range(0, availableNumbers.Count)];
                _num2 = availableNumbers[Random.Range(0, availableNumbers.Count)];
                while (_num1 < _num2)
                {
                    _num2 = availableNumbers[Random.Range(0, availableNumbers.Count)];
                }

                _correctAnswer = _num1 - _num2;
                break;

            case "*":
                _num1 = availableNumbers[Random.Range(0, availableNumbers.Count)];
                _num2 = availableNumbers[Random.Range(0, availableNumbers.Count)];

                _correctAnswer = _num1 * _num2;
                break;

            case "/":
                _num1 = availableNumbers[Random.Range(0, availableNumbers.Count)];
                _num2 = availableNumbers[Random.Range(0, availableNumbers.Count)];
                while (_num1 % _num2 != 0)
                {
                    _num1 = availableNumbers[Random.Range(0, availableNumbers.Count)];
                }

                _correctAnswer = _num1 / _num2;
                break;
        }

        _equation = _num1.ToString() + _chosenOperator + _num2.ToString();

        return _equation;

    }


    public void CheckAnswer(int userAnswer)
    {
        if(userAnswer == _correctAnswer)
        {
            DisplayManager.Instance.DisplayCorrect();
        }
        else
        {
            DisplayManager.Instance.DisplayIncorrect();
        }

    }

}
