using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(Rigidbody))]
public class Car : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    [SerializeField] private float m_Speed;

    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        m_Speed = 25.0f;
    }

    private void Update()
    {
       
        transform.Translate(Vector3.right * Time.deltaTime * m_Speed );

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = transform.forward * m_Speed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = -transform.forward * m_Speed;
        }

        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     //Rotate the sprite about the Y axis in the positive direction
        //     transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * m_Speed, Space.World);
        // }

        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     //Rotate the sprite about the Y axis in the negative direction
        //     transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * m_Speed, Space.World);
        // }
    }
}
