using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float horizontalInput;
    private float verticalInput;
    private float XRange = 22.0f;
    private float ZRange = 14.0f;
    public int life = 3;

    public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBound();
        PlayerMove();
        if (life == 0)
        {
            isGameOver = true;
        }
    }

    void PlayerMove()
    {
        if (!isGameOver)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(horizontalInput * Vector3.right * Time.deltaTime * speed);
            transform.Translate(verticalInput * Vector3.forward * Time.deltaTime * speed);
        }
    }

    void MoveBound()
    {
        if(transform.position.x < -XRange)
        {
            transform.position = new Vector3(-XRange, transform.position.y, transform.position.z);
        }else if(transform.position.x > XRange)
        {
            transform.position = new Vector3(XRange, transform.position.y, transform.position.z);
        } else if(transform.position.z > ZRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, ZRange);
        } else if(transform.position.z < -ZRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -ZRange);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(life != 0)
        {
            life -= 1;
        }        
        Destroy(other.gameObject);
    }
}
