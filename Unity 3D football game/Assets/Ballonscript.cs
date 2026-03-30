using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballonscript : MonoBehaviour
{
    public AudioSource collectSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "RigidBodyFPSController")
        {
            collectSound.Play();
            other.GetComponent<PlayerScript>().points++;
            Destroy(gameObject);
        }
    }
}
