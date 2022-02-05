using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalBound = 10;

    [SerializeField] float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Input.GetAxis("Horizontal"));
        if (transform.position.x < -horizontalBound)
        {
            gameObject.transform.position = new Vector3(-horizontalBound, transform.position.y, 0);
        }
        else if (transform.position.x > horizontalBound)
        {
            gameObject.transform.position = new Vector3(horizontalBound, transform.position.y, 0);
        }
    }
}
