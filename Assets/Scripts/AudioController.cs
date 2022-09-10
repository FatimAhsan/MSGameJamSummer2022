using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    private void OnEnable()
    {
        PersonMovement.OnFoodHit += playAudio;
    }
    void playAudio()
    {
        StartCoroutine(ExampleCoroutine());
       
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1); 
        gameObject.GetComponent<AudioSource>().Play();
    }
}
