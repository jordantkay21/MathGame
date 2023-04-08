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

    [SerializeField]
    private List<int> _availableNumbers;
    #endregion

    #region CalculationVariables
    [SerializeField]
    private List<string> _avaialableOperators;
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
                    _isOnes = false;
                }
                else
                {

                    _isOnes = true;
                }
                break;

            case "Tens":
                if (_isTens == true)
                {
                    _isTens = false;
                }
                else
                {
                    _isTens = true;
                }
                break;

            case "Hundreds":
                if (_isHundreds == true)
                {
                    _isHundreds = false;
                }
                else
                {
                    _isHundreds = true;
                }
                break;

            case "Thousands":
                if (_isThousands == true)
                {
                    _isThousands = false;
                }
                else
                {
                    _isThousands = true;
                }
                break;
        }
    }

    #region SetEquation
    public string SetOperator()
    {
        string chosenOperator; 

        chosenOperator = _avaialableOperators[Random.Range(0, _avaialableOperators.Count)];

        return chosenOperator;
    }

    public void GenerateNumbersList()
    {
        if(_isOnes == true)
        {
            _availableNumbers.AddRange(_singleDigit);
        }
        if(_isTens == true)
        {
            _availableNumbers.AddRange(_doubleDigit);
        }
        if(_isHundreds == true)
        {
            _availableNumbers.AddRange(_tripleDigit);
        }
        if(_isThousands == true)
        {
            _availableNumbers.AddRange(_quadDigit);
        }
    }

    #endregion

}
