using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clubs : MonoBehaviour
{
    [SerializeField] Rigidbody2D club;
    [SerializeField] Rigidbody2D cursor;
    [SerializeField] Rigidbody2D golfBall;
    private Vector2 velocity = new (0,0);
    private float mass;
    //If the putter is equipped than do this otherwise it doesn't really matter 
    //If i want it to feel right i need to be able to control mouse speed with respective to the mass of the club, probably maybe all clubs feel the same but lighter clubs you have more control 
    //Since collision is not detected every single instant so it can pass through if you are going too fast 
    // Start is called before the first frame update
    
    //Basic things that all clubs need to do
    
    public void RotateToBall()
    {
        Vector2 distance = golfBall.position-club.position;
        /*float angleRotate = 57.3f*Mathf.Atan2(distance.x, distance.y);
        club.transform.Rotate(0, 0,  (degreeFromNormal-angleRotate));
        degreeFromNormal =57.3f*Mathf.Atan2(distance.x, distance.y) ;
        Debug.Log("AAHAHHA"+(degreeFromNormal-angleRotate));
       */
       club.MoveRotation(57.3f *- Mathf.Atan2(distance.x, distance.y));
    }
    
    //Club types
    public Clubs()
    {
        club.mass = mass;


    }

    public void setMass(float mass)
    {
        club.mass = mass;
    }

    public void moveBall()
    {
        //all my work for nothing! you can just rotateto and movepoistion bruh!!!
        club.MovePosition(cursor.position);
        club.velocity = (cursor.velocity);
        RotateToBall();
    }
    
    void Start()
    {
 
    }


    // Update is called once per frame
    void Update()
    {

    }
}
