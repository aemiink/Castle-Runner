using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class UIHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Numeric Factors")]
    private Vector3 originalScale;
    public float scaleFactor = 1.2f; // Büyütme oranı
    public float animationDuration = 0.2f; // Animasyon süresi

    [Header("Animations Object")]
    [SerializeField] Image charcter;

    private void Start()
    {
        if (charcter != null)
        {
            originalScale = charcter.transform.localScale;
        }
        else
        {
            Debug.LogError("charcter nesnesi atanmadı! Inspector'dan atamayı kontrol edin.");
        }
    }

    // Pointer butona geldiğinde büyütme Coroutine başlar
    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines(); // Diğer animasyonları durdurur
        StartCoroutine(ScaleOverTime(originalScale * scaleFactor));
    }

    // Pointer butondan ayrıldığında eski boyuta dönme Coroutine başlar
    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(ScaleOverTime(originalScale));
    }

    // Yumuşak geçişli büyütme/küçültme Coroutine'i
    private IEnumerator ScaleOverTime(Vector3 targetScale)
    {
        Vector3 initialScale = charcter.transform.localScale;
        float time = 0;

        while (time < animationDuration)
        {
            charcter.transform.localScale = Vector3.Lerp(initialScale, targetScale, time / animationDuration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale; // Hedef boyuta ulaş
    }
}
