using UnityEngine;

public class CameraTrack : MonoBehaviour
{   
    //Size --> 1/2radius for x, radius for y
    public Rigidbody2D golfBall;
    public float maxX;
    public float maxY;
    public float cameraSpeed;
    public Vector3 cameraPanLocation;
    public Camera camera;

 
   // public Camera camera; Will figure this out later to zoom in and out but for now its fine
   //Make camera move at same angle just ofr a little bit too, do cam position - ball position. then inverse tan of y/x 
    void Start()
    {
        cameraPanLocation = new(0, 0, -10);
        camera.orthographic=true;
    }

    Vector2 absValueVectorTwo(Vector2 desiredVector)
    {
        Vector2 absolutedVector = new Vector2(Mathf.Abs(desiredVector.x), Mathf.Abs(desiredVector.y));
        return absolutedVector;
    }


    // Update is called once per frame
    void Update() 
    {   
        if(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel"))> 0){
             camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel");
             
        }
        Vector2 maxBoundsCam = new Vector2(maxX,maxY) * camera.orthographicSize/5;
        
        
        int randomMoveY = Random.Range(1, 5);
        Vector2 camPos = new Vector2(transform.position.x,transform.position.y);
        
        Vector2 ballDisplacement = golfBall.position-camPos;
    
        Vector2 ballDistance = absValueVectorTwo(golfBall.position)-(maxBoundsCam+absValueVectorTwo(camPos));

        Vector2 notAbsDist = golfBall.position - maxBoundsCam;
        Debug.Log("displacemet"+ballDisplacement +"Dista"+ballDistance+ "CAm" + camPos+"thing"+(maxBoundsCam+camPos));
        // y/x = tan(angleFromBall) --> x = y/tan(angleFromBall0
        //This only applies when it is outside of the bounds. It doesnt go to the point, it moves in cameraspeed * deltatime intervals.
        //Try if to update the travel to location and the update just moves it
        //transform.position = Vector3.MoveTowards(transform.position, cameraPanLocation, cameraSpeed * Time.deltaTime); 
        //cameraPanLocation = updateMoveToPosition(golfBall.position, maxBoundsCam, cameraPanLocation); 
        if(ballDistance.x > 0 || ballDistance.y > 0){
            //float angle = notAbsDist.y/notAbsDist.x;
            transform.position += cameraSpeed*Time.deltaTime * new Vector3(ballDisplacement.x,ballDisplacement.y,0);
            cameraSpeed++;
            //cameraPanLocation = golfBall.position;
          //  transform.position = Vector3.MoveTowards(transform.position,cameraPanLocation,cameraSpeed * Time.deltaTime);
            
        } 
        else{
            cameraSpeed = 1;
        }
    }
}


