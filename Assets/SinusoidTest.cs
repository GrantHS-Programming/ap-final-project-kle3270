using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
             for(int x = 0; x < 360; x++){
            double angle = x*57.2957795;
            float tan = Mathf.Tan((float) angle);
            float invTan = Mathf.Atan(tan);
            Debug.Log(invTan + " :"+tan);
        
    }

    // Update is called once per frame
    void Update()
    {
        
  } 
    }
}
