using UnityEngine;
using TMPro;
 
public class LandingDetect : MonoBehaviour
{
    [SerializeField] private TMP_Text SuccessfulText;
    [SerializeField] private string SuccessfulMessage = "Mission Successful!";
    [SerializeField] private RadarSystem manager;
 
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
 
        if (manager == null)
            return;
 
        if (manager.CanCompleteMission())
        {
            manager.StartSuccessProcess(SuccessfulText, SuccessfulMessage);
        }
    }
}