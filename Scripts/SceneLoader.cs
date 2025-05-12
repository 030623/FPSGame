using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI loadingText,tipText;
    public string sceneName;

    public bool isActiveLoadScene = false;

    private void Start()
    {
        if (isActiveLoadScene)
        {
            LoadSceneAsync(sceneName);
            slider.value = 0;
            loadingText.text = "";
            tipText.text = "";

        }
    }
    //�첽���س���
    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }
    //�첽���س���Э��
    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        while (operation.progress < 0.9f)
        {
            slider.value = operation.progress;
            loadingText.text = "������ ..." +  " " + (int)(operation.progress * 100) + "%";
            yield return 1;
        }
        slider.value = 1;
        loadingText.text = "�������";
        tipText.text = "�������������...";
        ///�ȴ��û�����
        while (!Input.anyKey)
        {
            yield return 1;
        }
        tipText.text = "";
        operation.allowSceneActivation = true;
    }
    public void LoadScene(string sceneName) => UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
