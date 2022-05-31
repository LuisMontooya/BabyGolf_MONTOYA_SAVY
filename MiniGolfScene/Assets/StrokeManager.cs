using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindPlayerBall();
        StrokeCount = 0 ;
    }

    public float StrokeAngle {get; protected set; }

    public float StrokeForce {get; protected set; }
    public float StrokeForcePerc { get { return StrokeForce / MaxShotForce;} }

    public int StrokeCount {get; protected set;}

    float shotForceFillSpeed = 1200f;
    int filling = 1;
    float MaxShotForce = 2000f;

    public enum StrokeModeEnum { 
        AIMING,
        FILLING,
        READY_TO_HIT,
        BALL_ROLLING
    };

    public StrokeModeEnum StrokeMode {get; protected set;}

    public Rigidbody playerBallRB ;

    private void FindPlayerBall() 
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        if(go == null)
        {
            Debug.LogError("No ball found.");
        }

        playerBallRB = go.GetComponent<Rigidbody>();

        if(playerBallRB == null)
        {
            Debug.LogError("No rigidBody for ball found.");
            Debug.LogError(playerBallRB);
        }
    }

    void checkStatus()
    {
        if(playerBallRB.IsSleeping())
        {
            StrokeMode = StrokeModeEnum.AIMING;
        }
    }

    private void Update() 
    {
        if(StrokeMode == StrokeModeEnum.AIMING)
        {
            StrokeAngle += Input.GetAxis("Horizontal") * 150f * Time.deltaTime;
        
            if(Input.GetButtonUp("Fire"))
            {
                StrokeMode = StrokeModeEnum.FILLING;
                return;
            }
        }    

        if(StrokeMode == StrokeModeEnum.FILLING)
        {
            StrokeForce += (shotForceFillSpeed * filling) * Time.deltaTime;

            if(StrokeForce > MaxShotForce)
            {
                StrokeForce = MaxShotForce;
                filling = -1;
            }
            else if(StrokeForce < 0) 
            {
                StrokeForce = 0;
                filling = 1 ;
            }

            if(Input.GetButtonUp("Fire"))
            {
                StrokeMode = StrokeModeEnum.READY_TO_HIT;
            }

        }       
        
    }

    void FixedUpdate()
    {
        if(playerBallRB == null)
        {
            return;
        }

        if(StrokeMode == StrokeModeEnum.BALL_ROLLING)
        {
            checkStatus();
            return;
        }
        
        if(StrokeMode != StrokeModeEnum.READY_TO_HIT)
        {
            return;
        }
        
        Vector3 forceVec = new Vector3(0, 0, StrokeForce);

        playerBallRB.AddForce(Quaternion.Euler(0, StrokeAngle, 0) * forceVec, ForceMode.Impulse);

        StrokeForce = 0;
        filling = 1 ;
        StrokeCount++;

        StrokeMode = StrokeModeEnum.BALL_ROLLING; 
    
    }
}
