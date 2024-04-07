using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private int maxValue = 100;
    private int minValue = 1;
    private int middleValue;
    private int attemptsNumber = 0;


    [SerializeField] private GameObject _startUI;
    [SerializeField] private GameObject _prePlayUI;
    [SerializeField] private GameObject _playUI;
    [SerializeField] private GameObject _afterPlayUI;
    [SerializeField] private GameObject _settingsUI;
    [Space]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitAppButton;
    [Space]
    [SerializeField] private Button _confirmSelectionButton;
    [Space]
    [SerializeField] private Button _openSettingsButton;
    [SerializeField] private TextMeshProUGUI _attemptsNumberLabel;
    [SerializeField] private TextMeshProUGUI _guessingLabel;
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;
    [Space]
    [SerializeField] private TextMeshProUGUI _endGuessLabel;
    [SerializeField] private Button _againButton2;
    [SerializeField] private Button _quitGameButton2;
    [Space]
    [SerializeField] private Button _againButton;
    [SerializeField] private Button _quitGameButton;
    [SerializeField] private Button _quitSettingsButton;



    private void Start()
    {
        _startUI.SetActive(true);
        _prePlayUI.SetActive(false);
        _playUI.SetActive(false);
        _afterPlayUI.SetActive(false);
        _settingsUI.SetActive(false);


        _playButton.onClick.AddListener(OnPlayButtonClick);
        _quitAppButton.onClick.AddListener(OnQuitAppButtonClick);

        _confirmSelectionButton.onClick.AddListener(OnConfirmSelectionButtonClick);

        _openSettingsButton.onClick.AddListener(OnOpenSettingsButtonClick);
        _yesButton.onClick.AddListener(OnYesButtonClick);
        _noButton.onClick.AddListener(OnNoButtonClick);

        _againButton2.onClick.AddListener(OnPlayButtonClick);
        _quitGameButton2.onClick.AddListener(OnQuitGameButtonClick);

        _quitGameButton.onClick.AddListener(OnQuitGameButtonClick);
        _againButton.onClick.AddListener(OnQuitSettingsButtonClick);
        _quitSettingsButton.onClick.AddListener(OnQuitSettingsButtonClick);
    }


    private void OnPlayButtonClick()
    {
        maxValue = 100;
        minValue = 1;
        attemptsNumber = 0;

        middleValue = (maxValue + minValue) / 2;
        _guessingLabel.text = $"IS YOUR NUMBER GREATER THAN {middleValue}?";
        _attemptsNumberLabel.text = $"PEPPA'S ATTEMPT: {attemptsNumber}";

        _startUI.SetActive(false);
        _afterPlayUI.SetActive(false);
        _prePlayUI.SetActive(true);
    }
    
    
    private void OnQuitAppButtonClick()
    {
        Application.Quit();
    }

    private void OnConfirmSelectionButtonClick()
    {
        _prePlayUI.SetActive(false);
        _playUI.SetActive(true);
    }

    private void OnOpenSettingsButtonClick()
    {
        _settingsUI.SetActive(true);
    }
    
    
    private void OnQuitSettingsButtonClick()
    {
        _settingsUI.SetActive(false);
    }


    private void OnQuitGameButtonClick()
    {
        _startUI.SetActive(true);
        _playUI.SetActive(false);
        _settingsUI.SetActive(false);
        _afterPlayUI.SetActive(false);
    }


    private void OnYesButtonClick()
    {
        attemptsNumber++;
        minValue = middleValue;
        middleValue = (maxValue + minValue) / 2;

        _attemptsNumberLabel.text = $"PEPPA'S ATTEMPT: {attemptsNumber}";
        _guessingLabel.text = $"IS YOUR NUMBER GREATER THAN {middleValue}?";

        Debug.Log($"YES\nMinVal:{minValue} MiddleValue:{middleValue} MaxValue:{maxValue}");

        if (attemptsNumber == 7)
        {
            _playUI.SetActive(false);
            _afterPlayUI.SetActive(true);

            _endGuessLabel.text = $"MY SISTER THINKS YOUR NUMBER IS {maxValue}!";
        }

    }
    
    private void OnNoButtonClick()
    {
        attemptsNumber++;
        maxValue = middleValue;
        middleValue = (maxValue + minValue) / 2;

        _attemptsNumberLabel.text = $"PEPPA'S ATTEMPT: {attemptsNumber}";
        _guessingLabel.text = $"IS YOUR NUMBER GREATER THAN {middleValue}?";

        Debug.Log($"NO\nMinVal:{minValue} MiddleValue:{middleValue} MaxValue:{maxValue}");

        if (attemptsNumber == 7)
        {
            _playUI.SetActive(false);
            _afterPlayUI.SetActive(true);

            _endGuessLabel.text = $"MY SISTER THINKS YOUR NUMBER IS {maxValue}!";
        }
    }
}
