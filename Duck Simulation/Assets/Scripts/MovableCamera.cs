using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCamera : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;

    private Vector2 _prevMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        _prevMousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementVector = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 rotationVector = (Vector2)Input.mousePosition - _prevMousePosition;

        transform.position += ((transform.right * movementVector.x) + (transform.forward * movementVector.y)) * moveSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, rotationVector.x * rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.left, rotationVector.y * rotationSpeed * Time.deltaTime);

        _prevMousePosition = Input.mousePosition;
    }
}
