using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class GameUIManager : MonoBehaviour
{

    [SerializeField] Text scoreName;

    void Awake()
    {
        if (SaveGameManager.Instance != null)
        {
            scoreName.text = "Best Score: " + SaveGameManager.Instance.savePlayerName + " " + SaveGameManager.Instance.savePlayerScore;
        }

    }

}
