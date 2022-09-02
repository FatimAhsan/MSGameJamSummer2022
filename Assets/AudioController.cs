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
        FoodCollision.OnFoodHit += playAudio;
    }
    void playAudio()
    {
        GetComponent<AudioSource>().Play();
    }
}
