using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public TMP_InputField nameField;
    public TextMeshProUGUI hiScoreText;

    private void Awake()
    {
        if (DataMan.Instance.hiScore == 0)
        {
            hiScoreText.text = "No HiScore yet!";
        }
        else
        {
            Debug.Log("setting hiscore text...");
            nameField.text = DataMan.Instance.playerName;
            hiScoreText.text = $"HiScore: {DataMan.Instance.hiScore,5} by {DataMan.Instance.hiScoreName}";
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetName()
    {
        Debug.Log("setting name...");
        DataMan.Instance.playerName = nameField.text;
    }
}
