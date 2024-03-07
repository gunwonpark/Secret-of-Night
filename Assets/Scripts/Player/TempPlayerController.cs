using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerController : MonoBehaviour
{
    private float xAxis;
    private float yAxis;
    [SerializeField] private float moveSpeed = 5.0f;    
    private void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(xAxis, 0, yAxis);

        if(direction != Vector3.zero)
        {
            transform.position += direction.normalized * Time.deltaTime * moveSpeed;
        }
    }
}
