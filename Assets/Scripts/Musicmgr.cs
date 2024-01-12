using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicmgr : MonoBehaviour
{
    public AudioSource src;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMusic()
    {
        src.Play();
    }

    public void Pause()
    {
        src.Pause();
    }

    public void Stop() 
    { 
        src.Stop(); 
    }


}
