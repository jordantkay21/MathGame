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

    #region CalculationVariables
    [SerializeField]
    private List<string> _avaialableOperators;

    [SerializeField]
    private string chosenOperator;
    [SerializeField]
    private int randomOperator;
    #endregion
    public void SetParamters(string value)
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

    public string SetOperator()
    {
        chosenOperator = _avaialableOperators[Random.Range(0, _avaialableOperators.Count)];

        return chosenOperator;
    }
}
