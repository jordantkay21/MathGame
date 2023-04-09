using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayManager : MonoSingleton<DisplayManager>
{
    #region GameSetupVariables
    [SerializeField]
    private GameObject _addSelect, _subtractSelect, _multiplySelect, _divideSelect;

    [SerializeField]
    private GameObject _onesSelect, _tensSelect, _hundredsSelect, _thousandsSelect;

    [SerializeField]
    private TextMeshProUGUI _equationText;

    [SerializeField]
    private bool _isAdd, _isSubtract, _isMultiply, _isDivide;
    [SerializeField]
    private bool _isOnes, _isTens, _isHundreds, _isThousands;
    #endregion

    #region
    [SerializeField]
    private TextMeshProUGUI _userAnswer;
    #endregion

    public void DisplayParamters(string value)
    {
        switch (value)
        {
            case "Add":
                if (_isAdd == true)
                {
                    _addSelect.SetActive(false);
                    _isAdd = false;
                }
                else
                {
                    _addSelect.SetActive(true);
                    _isAdd = true;
                }
                break;

            case "Subtract":
                if (_isSubtract == true)
                {
                    _subtractSelect.SetActive(false);
                    _isSubtract = false;
                }
                else
                {
                    _subtractSelect.SetActive(true);
                    _isSubtract = true;
                }
                break;

            case "Multiply":
                if (_isMultiply == true)
                {
                    _multiplySelect.SetActive(false);
                    _isMultiply = false;
                }
                else
                {
                    _multiplySelect.SetActive(true);
                    _isMultiply = true;
                }
                break;

            case "Divide":
                if (_isDivide == true)
                {
                    _divideSelect.SetActive(false);
                    _isDivide = false;
                }
                else
                {
                    _divideSelect.SetActive(true);
                    _isDivide = true;
                }
                break;

            case "Ones":
                if (_isOnes == true)
                {
                    _onesSelect.SetActive(false);
                    _isOnes = false;
                }
                else
                {
                    _onesSelect.SetActive(true);
                    _isOnes = true;
                }
                break;

            case "Tens":
                if (_isTens == true)
                {
                    _tensSelect.SetActive(false);
                    _isTens = false;
                }
                else
                {
                    _tensSelect.SetActive(true);
                    _isTens = true;
                }
                break;

            case "Hundreds":
                if (_isHundreds == true)
                {
                    _hundredsSelect.SetActive(false);
                    _isHundreds = false;
                }
                else
                {
                    _hundredsSelect.SetActive(true);
                    _isHundreds = true;
                }
                break;

            case "Thousands":
                if (_isThousands == true)
                {
                    _thousandsSelect.SetActive(false);
                    _isThousands = false;
                }
                else
                {
                    _thousandsSelect.SetActive(true);
                    _isThousands = true;
                }
                break;
        }
    }

    public void DisplayEquation(string equation)
    {
        _equationText.SetText(equation);
    }

    public string UserInput()
    {
        string answer = _userAnswer.text;
        return answer;
    }
}
