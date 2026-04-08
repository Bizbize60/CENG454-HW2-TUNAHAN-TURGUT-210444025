using UnityEngine;
using TMPro;
 
public class LandingDetect : MonoBehaviour
{
   
    [SerializeField] private TMP_Text SuccessfulText;
    [SerializeField] private string SuccessfulMessage = "Mission Successful!";
    [SerializeField] private RadarSystem manager;
    private AudioSource successound;

    void Start()
    {
        
        successound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
 
        if (manager == null)
            return;
 
        if (manager.CompleteMission())
        {
            manager.StartSuccessProcess(SuccessfulText, SuccessfulMessage);
            successound.Play();
        }
    }
}