using UnityEngine;
using System.Collections;

public class CardFlip : MonoBehaviour
{
    public float flipDuration = 0.5f; // Tiempo total del giro
    public GameObject frontContent;   // Lo que se ve al inicio (puede estar vacío)
    public GameObject backContent;    // Lo que se muestra al final (rol del jugador)

    private bool isFlipped = false;
    private bool isAnimating = false;

    public void FlipCard()
    {
        if (!isAnimating)
            StartCoroutine(FlipAnimation());
    }

    IEnumerator FlipAnimation()
    {
        isAnimating = true;

        float elapsed = 0f;
        Quaternion startRotation = transform.rotation;
        Quaternion midRotation = Quaternion.Euler(0, 90, 0); // Carta de canto
        Quaternion endRotation = Quaternion.Euler(0, 0, 0); // Carta completamente girada

        // Primera mitad del giro
        while (elapsed < flipDuration / 2f)
        {
            float t = elapsed / (flipDuration / 2f);
            transform.rotation = Quaternion.Slerp(startRotation, midRotation, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Forzar mitad exacta
        transform.rotation = midRotation;

        // Aquí cambiamos el contenido visible
        isFlipped = !isFlipped;
        frontContent.SetActive(!isFlipped);
        backContent.SetActive(isFlipped);

        // Segunda mitad del giro
        elapsed = 0f;
        while (elapsed < flipDuration / 2f)
        {
            float t = elapsed / (flipDuration / 2f);
            transform.rotation = Quaternion.Slerp(midRotation, endRotation, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;
        isAnimating = false;
    }
}
