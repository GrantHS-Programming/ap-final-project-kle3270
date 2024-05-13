using UnityEngine;

public class CameraTrack : MonoBehaviour
{   
    //Size --> 1/2radius for x, radius for y
    public Rigidbody2D golfBall;
    public Vector2 maxBoundsCam;
    public float cameraSpeed;
    private Vector3 cameraPanLocation;
   // public Camera camera; Will figure this out later to zoom in and out but for now its fine
   //Make camera move at same angle just ofr a little bit too, do cam position - ball position. then inverse tan of y/x 
    void Start()
    {
        cameraPanLocation = new(0, 0, -10);
    }

    Vector2 absValueVectorTwo(Vector2 desiredVector)
    {
        Vector2 absolutedVector = new Vector2(Mathf.Abs(desiredVector.x), Mathf.Abs(desiredVector.y));
        return absolutedVector;
    }

    Vector3 updateMoveToPosition(Vector2 ballPos, Vector2 bounds,Vector3 moveToPosition)
    {
        Vector2 ballDistance = ballPos - bounds;
        Vector2 absBallDistance = absValueVectorTwo(ballDistance); 
        //if in the third quadrant that means that the absPosition if between the bounds
        float ballAngle = Vector2.Angle(absBallDistance, new(0,1));
        Debug.Log("Moveto:" + moveToPosition + " Angle:" + ballAngle+"Distance: "+absBallDistance);
        if(ballAngle !>90 && ballAngle !< 180) //wtf is this?
        {
            float tanAngleFromBall = (ballDistance).y / (ballDistance).x;
            moveToPosition = new(golfBall.position.x+5, golfBall.position.y+5,-10);
        }
        return new(moveToPosition.x,moveToPosition.y,-10);
    }

    // Update is called once per frame
    void Update()
    {
        int randomMoveY = Random.Range(1, 5);
        // y/x = tan(angleFromBall) --> x = y/tan(angleFromBall0
        //This only applies when it is outside of the bounds. It doesnt go to the point, it moves in cameraspeed * deltatime intervals.
        //Try if to update the travel to location and the update just moves it
        
        transform.position = Vector3.MoveTowards(transform.position, cameraPanLocation, cameraSpeed * Time.deltaTime); 
        cameraPanLocation = updateMoveToPosition(golfBall.position, maxBoundsCam, cameraPanLocation);



    }
    
}
