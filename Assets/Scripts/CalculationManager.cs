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
    private List<string> _avaialableOperators;
    [SerializeField]
    private List<int> _availableNumbers;

    [SerializeField]
    private int _num1, _num2;
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
                    _avaialableOperators.Remove("+");
                    _isAdd = false;
                }
                else
                {
                    _avaialableOperators.Add("+");
                    _isAdd = true;
                }
                break;

            case "Subtract":
                if (_isSubtract == true)
                {
                    _avaialableOperators.Remove("-");
                    _isSubtract = false;
                }
                else
                {
                    _avaialableOperators.Add("-");
                    _isSubtract = true;
                }
                break;
            
            case "Multiply":
                if (_isMultiply == true)
                {
                    _avaialableOperators.Remove("*");
                    _isMultiply = false;
                }
                else
                {
                    _avaialableOperators.Add("*");
                    _isMultiply = true;
                }
                break;
            
            case "Divide":
                if (_isDivide == true)
                {
                    _avaialableOperators.Remove("/");
                    _isDivide = false;
                }
                else
                {
                    _avaialableOperators.Add("/");
                    _isDivide = true;
                }
                break;

            case "Ones":
                if (_isOnes == true)
                {
                    foreach (int num in _singleDigit)
                    {
                        _availableNumbers.Remove(num);
                    }
                    _isOnes = false;
                }
                else
                {
                    _availableNumbers.AddRange(_singleDigit);
                    _isOnes = true;
                }
                break;

            case "Tens":
                if (_isTens == true)
                {
                    foreach (int num in _doubleDigit)
                    {
                        _availableNumbers.Remove(num);
                    }
                    _isTens = false;
                }
                else
                {
                    _availableNumbers.AddRange(_doubleDigit);
                    _isTens = true;
                }
                break;

            case "Hundreds":
                if (_isHundreds == true)
                {
                    foreach (int num in _tripleDigit)
                    {
                        _availableNumbers.Remove(num);
                    }
                    _isHundreds = false;
                }
                else
                {
                    _availableNumbers.AddRange(_tripleDigit);
                    _isHundreds = true;
                }
                break;

            case "Thousands":
                if (_isThousands == true)
                {
                    foreach (int num in _quadDigit)
                    {
                        _availableNumbers.Remove(num);
                    }
                    _isThousands = false;
                }
                else
                {
                    _availableNumbers.AddRange(_quadDigit);
                    _isThousands = true;
                }
                break;
        }
    }

    #region SetEquation
    public void SetEquation()
    {
        _chosenOperator = _avaialableOperators[Random.Range(0, _avaialableOperators.Count)];
        _num1 = _availableNumbers[Random.Range(0, _availableNumbers.Count)];
        _num2 = _availableNumbers[Random.Range(0, _availableNumbers.Count)];

        _equation = _num1.ToString() + _chosenOperator + _num2.ToString();

        Debug.Log(_equation);

    }
    #endregion

}
