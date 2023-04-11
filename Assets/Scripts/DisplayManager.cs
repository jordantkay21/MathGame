using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayManager : MonoSingleton<DisplayManager>
{
    #region GameSetupVariables
    [SerializeField]
    private GameObject[] _operatorButtons = new GameObject[4]; // 0=+ | 1=- | 2=* | 3=/
    [SerializeField]
    private GameObject[] _operatorChosen = new GameObject[4]; // 0=+ | 1=- | 2=* | 3=/

    [SerializeField]
    private GameObject[] _placeValueButtons = new GameObject[4]; // 0=Ones | 1=Tens | 2=Hundreds | 3=Thousands 
    [SerializeField]
    private GameObject[] _placeValueChosen = new GameObject[4];  // 0=Ones | 1=Tens | 2=Hundreds | 3=Thousands 

    [SerializeField]
    private TextMeshProUGUI _equationText, _gameMessageText, _scoreText;

    [SerializeField]
    private bool _isAdd, _isSubtract, _isMultiply, _isDivide;
    [SerializeField]
    private bool _isOnes, _isTens, _isHundreds, _isThousands;
    [SerializeField]
    private GameObject _gameMessageObj, _startButton;
    #endregion

    #region UserInput
    [SerializeField]
    private GameObject _userInputField, _generateButton;

    [SerializeField]
    private GameObject _equationTextObj;
    #endregion

    #region GameSetup
    public void DisplayParameterSelections(string value)
    {
        switch (value)
        {
            case "Add":
                if (_isAdd == true)
                {
                    _operatorChosen[0].SetActive(false);
                    _isAdd = false;
                }
                else
                {
                    _operatorChosen[0].SetActive(true);
                    _isAdd = true;
                }
                break;

            case "Subtract":
                if (_isSubtract == true)
                {
                    _operatorChosen[1].SetActive(false);
                    _isSubtract = false;
                }
                else
                {
                    _operatorChosen[1].SetActive(true);
                    _isSubtract = true;
                }
                break;

            case "Multiply":
                if (_isMultiply == true)
                {
                    _operatorChosen[2].SetActive(false);
                    _isMultiply = false;
                }
                else
                {
                    _operatorChosen[2].SetActive(true);
                    _isMultiply = true;
                }
                break;

            case "Divide":
                if (_isDivide == true)
                {
                    _operatorChosen[3].SetActive(false);
                    _isDivide = false;
                }
                else
                {
                    _operatorChosen[3].SetActive(true);
                    _isDivide = true;
                }
                break;

            case "Ones":
                if (_isOnes == true)
                {
                    _placeValueChosen[0].SetActive(false);
                    _isOnes = false;
                }
                else
                {
                    _placeValueChosen[0].SetActive(true);
                    _isOnes = true;
                }
                break;

            case "Tens":
                if (_isTens == true)
                {
                    _placeValueChosen[1].SetActive(false);
                    _isTens = false;
                }
                else
                {
                    _placeValueChosen[1].SetActive(true);
                    _isTens = true;
                }
                break;

            case "Hundreds":
                if (_isHundreds == true)
                {
                    _placeValueChosen[2].SetActive(false);
                    _isHundreds = false;
                }
                else
                {
                    _placeValueChosen[2].SetActive(true);
                    _isHundreds = true;
                }
                break;

            case "Thousands":
                if (_isThousands == true)
                {
                    _placeValueChosen[3].SetActive(false);
                    _isThousands = false;
                }
                else
                {
                    _placeValueChosen[3].SetActive(true);
                    _isThousands = true;
                }
                break;
        }
    }

    public void DisplayEquation(string equation)
    {
        _equationText.SetText(equation);
    }

    public void DisplayNoParametersWarning()
    {
        _gameMessageText.SetText("MUST SELECT AT LEAST ONE PLACE VALUE AND ONE OPERATOR TO START!");
    }

    public void DisplayGameMessage(string message)
    {
        _gameMessageText.SetText(message);
    }
    #endregion

    #region Start/StopGame
    private void DisableEnableButtons(bool onOff)
    {
        if (onOff == true) //Start
        {
            foreach (GameObject button in _placeValueButtons)
            {
                button.GetComponent<Button>().interactable = false;
            }

            foreach (GameObject button in _operatorButtons)
            {
                button.GetComponent<Button>().interactable = false;
            }

            _startButton.GetComponent<Button>().interactable = false;
        }
        else //Stop
        {
            foreach (GameObject button in _placeValueButtons)
            {
                button.GetComponent<Button>().interactable = true;
            }

            foreach (GameObject button in _operatorButtons)
            {
                button.GetComponent<Button>().interactable = true;
            }

            _startButton.GetComponent<Button>().interactable = false;
        }
    }

    private void DisableEnableUserInputFields(bool onOff)
    {
        if(onOff == true) //Start
        {
            _userInputField.SetActive(true);
            _generateButton.SetActive(false);
            _gameMessageText.SetText("");
        }
        else //Stop
        {
            _userInputField.SetActive(false);
            _generateButton.SetActive(true);
            _gameMessageText.SetText("SELECT YOUR OPERATORS AND PLACE VALUES");
        }
    }

    public void StartStopGame(bool onOff)
    {
        DisableEnableUserInputFields(onOff);
        DisableEnableButtons(onOff);
    }
    #endregion

    #region GameMechanics
    public string UserInput()
    {
        string answer = _userInputField.GetComponent<TMP_InputField>().text;
        return answer;

    }

    public void ClearInputField()
    {
        _userInputField.GetComponent<TMP_InputField>().text = "";
    }

    public void DisplayCorrect()
    {
        StartCoroutine(CorrectRoutine());
        ButtonManager.Instance.GenerateEquation();
    }

    public void DisplayIncorrect()
    {
        StartCoroutine(IncorrectRoutine());
    }

    private IEnumerator CorrectRoutine()
    {
        _gameMessageText.SetText("CORRECT!");

        yield return new WaitForSeconds(1);

        _gameMessageText.SetText("");
    }

    private IEnumerator IncorrectRoutine()
    {
        _gameMessageText.SetText("INCORRECT");

        yield return new WaitForSeconds(1);

        _gameMessageText.SetText("");
    }

    public void DisplayScore(int score)
    {
        _scoreText.SetText("Score: " + score.ToString());
    }


    #endregion
}
