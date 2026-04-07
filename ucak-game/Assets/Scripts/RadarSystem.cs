using TMPro;
using UnityEngine;
 
public class RadarSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text warningMyText;
    [SerializeField] private string enterMessage = "Entered dangerous zone!";
    [SerializeField] private string exitMessage = "";
    [SerializeField] private CanvasGroup canvas;
    [SerializeField] private Transform jet;
    [SerializeField] private GameObject tank;
 
    private bool isInside= false;
    private float timer = 0f;
 
void Update()
{
    if (isInside)
    {
        timer += Time.deltaTime;
        if (timer > 5.0f) 
        {
            MissileLauncher launcher = tank.GetComponent<MissileLauncher>();
            if (launcher != null)
            {
                launcher.Launch(jet); 
            }
            isInside = false; 
            timer = 0f;
        }
    }
}
    void OnTriggerEnter(Collider other)
    {
        // Sadece Player etiketi olan objeler tetiklesin
        if (!other.CompareTag("Player"))
            return;
 
        if (warningMyText != null)
        {
            SetCanvasOpacity(1.0f);
            warningMyText.text = enterMessage;
            isInside = true;
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
            isInside = false;
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