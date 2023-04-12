using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fakeStart;
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void fakeStartGame()
    {
        fakeStart.text = "No escape";
        fakeStart.color = Color.red;
        fakeStart.fontStyle = FontStyles.Strikethrough;
    }
}
