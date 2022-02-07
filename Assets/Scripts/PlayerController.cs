using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalBound = 7;
    private ParticleSystem particleSmoke;

    [SerializeField] float speed = 30f;
    
    // Start is called before the first frame update
    void Start()
    {
        particleSmoke = GameObject.Find("Smoke Particle").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Input.GetAxis("Horizontal") * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            particleSmoke.Play();
        }

        if (transform.position.x < -horizontalBound)
        {
            gameObject.transform.position = new Vector3(-horizontalBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > horizontalBound)
        {
            gameObject.transform.position = new Vector3(horizontalBound, transform.position.y, transform.position.z);
        }
    }
}
