using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIManager : MonoBehaviour
{   
    [SerializeField] string playerName;
    [SerializeField] TMP_InputField enterPlayerName;
    [SerializeField] TextMeshProUGUI bestScoreText;


    private void Awake()
    {
        if (SaveGameManager.Instance != null)
        {              
                bestScoreText.text = "Best Score : " + SaveGameManager.Instance.savePlayerName + " " + SaveGameManager.Instance.savePlayerScore;           
        }
    }

    public void EnterPlayerName()
    {
        playerName = enterPlayerName.text;       
    }


    public void StartGame()
    {
        SaveGameManager.Instance.dontShowPlayerName = playerName;      
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
