using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private TMP_Text warningMyText;
    [SerializeField] private string enterMessage = "Entered dangerous zone!";
    [SerializeField] private string exitMessage = "";
    [SerializeField] private CanvasGroup canvas;

    void OnTriggerEnter(Collider other)
    {
        // Sadece Player etiketi olan objeler tetiklesin
        if (!other.CompareTag("Player"))
            return;

        if (warningMyText != null)
        {
            SetCanvasOpacity(1.0f);
            warningMyText.text = enterMessage;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (warningMyText != null)
        {
            SetCanvasOpacity(0.0f);
            warningMyText.text = exitMessage;
        }
    }

    private void SetCanvasOpacity(float alphaValue)
    {
        if (canvas != null)
        {
            canvas.alpha = alphaValue;
        }
        
    }
}