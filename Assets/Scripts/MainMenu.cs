using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public TMP_InputField nameInput;
    public TextMeshProUGUI bestScore;
    private void Start()
    {
        SavingName.Instance.LoadBestPlayer();
        bestScore.text = $"Best Score : {SavingName.Instance.bestPlayerName} {SavingName.Instance.bestScore}";
    }


    private void Update()
    {

        SavingName.Instance.name = nameInput.text.ToString();
        
    }

    public void StartNewGame()
    {
        
        if (SavingName.Instance.name != string.Empty)
        {

            if (SavingName.Instance.bestPlayerName == string.Empty)
            {
                SavingName.Instance.bestPlayerName = SavingName.Instance.name;
            }
            SceneManager.LoadScene(1);
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }
}
