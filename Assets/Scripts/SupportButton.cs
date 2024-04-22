using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
 
public class SupportButton : MonoBehaviour, IPointerClickHandler
{
    // URL веб-сайта, который вы хотите открыть
    public string websiteURL = "https://boosty.to/alaskaserver";

    // Этот метод будет вызван, когда кнопка будет нажата
    public void OnPointerClick(PointerEventData eventData)
    {
        // Открываем веб-сайт в браузере по умолчанию
        Application.OpenURL(websiteURL);
    }
}
