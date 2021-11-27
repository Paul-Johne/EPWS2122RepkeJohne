using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFirework : MonoBehaviour
{
    public GameObject fireworkObject;
    public AudioSource fireworkSound;
    

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject firework = Instantiate(fireworkObject, transform.position, transform.rotation);
            fireworkSound.Play();
            Destroy(firework, 5.0f);
        }
    }
}
