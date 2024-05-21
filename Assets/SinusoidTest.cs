using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
             for(int x = 0; x < 360; x++){
            double angle = x*1/57.2957795;
            float tan = Mathf.Tan((float) angle);
            float invTan = 2/(float)57.2957795*Mathf.Atan(tan);
            Debug.Log(x+":"+invTan + " :"+tan);
             }
            
    }

    // Update is called once per frame
    void Update()
    {
        int x = 2;
  } 
    
}
