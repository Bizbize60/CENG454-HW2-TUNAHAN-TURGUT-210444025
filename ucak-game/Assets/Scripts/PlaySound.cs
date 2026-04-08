using UnityEngine;
 
public class PlaySound : MonoBehaviour
{
    AudioSource source;
 
    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
    }
    void OnTriggerEnter(Collider other)
    {  
        if (!other.CompareTag("Player"))
            return;
       
        Vector3 position = transform.InverseTransformPoint(other.transform.position);
        if (position.z > 0)
        {
            source.Play();
        }
 
    } 

    void OnTriggerExit(Collider other)
    {
        source.Stop();
    }

}
