using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggedLight : MonoBehaviour {

    public Light light;
    public Renderer emissiveMaterial;
    public float flickerRate;
    public float crashSoundDelay = 0.3f;
    public AudioClip bangSound;
    public AudioClip crashSound;

    // Use this for initialization
    void Start () {
        StartCoroutine(Flicker());
	}
	
	// Update is called once per frame
	void Update () {
	}

    

    private IEnumerator Flicker()
    {
        while (true) {
            yield return new WaitForSeconds(Random.Range(1,5));

            int flickers = Random.Range(1, 4);
            for (int i = 0; i < flickers; i++) {
                TurnOff();
                yield return new WaitForSeconds(flickerRate/100);
                TurnOn();
                yield return new WaitForSeconds(flickerRate/100);
            }
        }
    }

    public void TurnOn() {
        emissiveMaterial.material.SetColor("_EmissionColor", new Color(1,1,1,0));
        light.intensity = 1;
    }

    public void TurnOff()
    {
        emissiveMaterial.material.SetColor("_EmissionColor", new Color(0, 0, 0, 0));
        light.intensity = 0;
    }

    public void fall() {
        StopAllCoroutines();
        TurnOff();
        GetComponent<AudioSource>().Stop();
        GetComponent<Rigidbody>().useGravity = true;
        StartCoroutine(PlayCrashSound());

    }

    private IEnumerator PlayCrashSound()
    {
        AudioSource.PlayClipAtPoint(bangSound, transform.position);
        yield return new WaitForSeconds(crashSoundDelay);
        AudioSource.PlayClipAtPoint(crashSound, transform.position);
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            fall();
        }
        
    }
}


