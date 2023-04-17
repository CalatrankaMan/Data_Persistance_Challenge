using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class MainUIManaer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI errorText;

    public void LoadGame()
    {
        StartCoroutine(WaitForInput(Input.GetKeyDown(KeyCode.Return)));

        if (!string.IsNullOrEmpty(MainManager.Instance.m_Name))
        {
            MainManager.Instance.m_BestScore = 0;
            SceneManager.LoadScene("main");
        }else
        {
            errorText.text = "Provide a Name";
            errorText.gameObject.SetActive(true);
        }
    }

    private IEnumerator WaitForInput(bool inputSubmitted)
    {
        bool done = false;
        while (!done)
        {
            if (inputSubmitted)
            {
                done = true;
            }
            yield return null;
        }

    }
}
