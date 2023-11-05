using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    [SerializeField] private ParticleSystem boxParticle;

    private void Start()
    {
        Vector3 normalScale = transform.localScale;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("sizeUp"))
        {

            transform.localScale = new Vector3(0.5f, 0.7f, 0.5f);
            PlayerMovement.xRange = 3.5f;
            Instantiate(boxParticle, transform.position, Quaternion.identity);

        }
        if (other.gameObject.CompareTag("sizeUpNumber1"))
        {
            transform.localScale = new Vector3(0.7f,0.9f, 0.5f);
            
            Instantiate(boxParticle, transform.position, Quaternion.identity);

        }
        
    }
   
}
