using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClub : Clubs
{
    private float baseClubMass = 20;
    public BaseClub()
    {
        base.setMass(baseClubMass);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.moveBall();
        base.RotateToBall();

    }
}
