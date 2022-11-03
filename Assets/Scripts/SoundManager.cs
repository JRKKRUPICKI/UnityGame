using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour{

    public AudioClip point;
    public AudioClip death;
    public AudioClip unlock;

    public enum Sound{
        point, death, unlock
    }

    void Awake(){
        if (GameObject.FindGameObjectsWithTag("SoundManager").Length > 1){
            Destroy(this.gameObject);
        }
    }

    void Start(){
        DontDestroyOnLoad(this.gameObject);
    }

    void Update(){}

    public void PlaySound(Sound sound, Vector3 position){
        switch (sound){
            case Sound.point:
                AudioSource.PlayClipAtPoint(point, position);
                break;
            case Sound.death:
                AudioSource.PlayClipAtPoint(death, position);
                break;
            case Sound.unlock:
                AudioSource.PlayClipAtPoint(unlock, position);
                break;
        }
    }
}
