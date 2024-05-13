using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCursor : MonoBehaviour

{
    // Start is called before the first frame update
    //Can scale the cursor based on mass of object equipped but that is for later
    [SerializeField] Rigidbody2D cursorObject;
    [SerializeField] Rigidbody2D clubObject;
    public float scaleSpeed;
    float moveX;
    float moveY;
    public float defaultMouseSpeed;
    Vector2 pos;
    double elapsedTime = 0;

    void Start()
    {
        pos = new (0,0);
        Cursor.lockState = CursorLockMode.Locked;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 1)
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            float mouseY = Input.GetAxisRaw("Mouse Y");
            moveX = Time.deltaTime * scaleSpeed * mouseX * defaultMouseSpeed;
            moveY = Time.deltaTime * scaleSpeed * mouseY * defaultMouseSpeed;
            pos = new(moveX + cursorObject.position.x, moveY + cursorObject.position.y);
            Vector2 moveVector = new(moveX, moveY);
            cursorObject.transform.Translate(moveVector);

        }
    }
}
