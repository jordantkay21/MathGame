using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculationManager : MonoSingleton<CalculationManager>
{
    [SerializeField]
    private bool _isAdd, _isSubtract, _isMultiply, _isDivide;
    [SerializeField]
    private bool _isOnes, _isTens, _isHundreds, _isThousands;

    public void SetParamters(string value, bool onOff)
    {
        switch (value)
        {
            case "Add":
                _isAdd = onOff;
                break;

            case "Subtract":
                _isSubtract = onOff;
                break;
            
            case "Multiply":
                _isAdd = onOff;
                break;
            
            case "Divide":
                _isDivide = onOff;
                break;

            case "Ones":
                _isOnes = onOff;
                break;

            case "Tens":
                _isTens = onOff;
                break;

            case "Hundreds":
                _isHundreds = onOff;
                break;

            case "Thousands":
                _isThousands = onOff;
                break;
        }
    }
}
