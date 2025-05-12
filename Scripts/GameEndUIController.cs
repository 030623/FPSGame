using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEndUIController : MonoBehaviour
{
    public static GameEndUIController Instance;

    public Button mainMenuButton,QuitGameButton;

    public TextMeshProUGUI messageText;

    public void SetMessageText(string message)
    {
        messageText.text = message;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetMessageText(GameManager.Instance.isFailed ? "”Œœ∑ ß∞‹" : "”Œœ∑ §¿˚");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
