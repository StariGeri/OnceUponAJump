using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveButton : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject button;
    public GameObject character;
    void Start()
    {
        
    }

    void Update()
    {
        if(character.transform.position.x < button.transform.position.x)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime,0);
        }
        
    }
}
