using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fakeStart;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void FakeStartGame()
    {
        fakeStart.text = "No escape";
        fakeStart.color = Color.red;
        fakeStart.fontStyle = FontStyles.Strikethrough;
    }
}
