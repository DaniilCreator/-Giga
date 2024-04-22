using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public Slider loadingBar;
    public Image loadingImage; // Добавляем ссылку на изображение для анимации загрузки
    public string sceneNameToLoad;
    public float fakeLoadingSpeed = 0.1f;

    private bool loadScene = false;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneNameToLoad);
        asyncLoad.allowSceneActivation = false;

        float progress = 0f;

        while (!asyncLoad.isDone)
        {
            progress += fakeLoadingSpeed * Time.deltaTime;

            loadingBar.value = Mathf.Min(progress, asyncLoad.progress);

            if (loadingBar.value >= 0.9f && !loadScene)
            {
                loadScene = true;
            }

            if (loadScene)
            {
                loadingBar.value = 1f;
                asyncLoad.allowSceneActivation = true;
            }

            // Изменяем fill amount изображения для заполнения по часовой стрелке
            loadingImage.fillAmount = loadingBar.value;

            yield return null;
        }
    }
}
