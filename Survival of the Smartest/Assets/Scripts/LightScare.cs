using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScare : MonoBehaviour {

    public GameObject[] lights;
    public GameObject riggedLightPrefab;

    private GameObject riggedLight = null;
    private bool triggered = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Trigger()
    {
        if (!triggered) {
            GameObject light = lights[Random.Range(0, lights.Length)];
            Vector3 lightPosition = light.transform.position;
            Quaternion lightRotation = light.transform.rotation;
            Destroy(light);
            GameObject riggedLight = Instantiate(riggedLightPrefab, lightPosition, lightRotation, this.transform);
            triggered = true;
        }

        
    }

}
