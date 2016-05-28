using UnityEngine;
using System.Collections;

public class UsedObjectsManager : MonoBehaviour {
    /*
    public int colliderType = 0;
    public int transitionType = 0;

    public float testscale;
    
    // FIX  LERP
    GameObject[] F_gos = new GameObject[121];

    Transform[] F_startMarker = new Transform[121];
    Vector3[] F_endMarker = new Vector3[121];
    
    private float[] F_startTime= new float[121];
    private float[] F_journeyLength = new float[121];
    float[] F_distCovered = new float[121];

    bool[] F_runOnce = new bool[121];
    bool[] F_boolean = new bool[121];

    float[] F_speed =  new float[121];
    float[] F_fracJourney = new float[121];

    int[] F_indexes = new int[121];
    // END FIX LERP
    
        
    void Start()
    {
        Debug.Log("Still Enabled?");
        // set F_runOnce all to true
        for (int i = 0; i <= F_runOnce.Length-1; i++)// 1- 60
        {
            F_runOnce[i] =true;
            F_speed[i] = 80.0f;
            F_boolean[i] = false;
            

            if (i < 10)
            {
                F_gos[i] = GameObject.Find("PlaneRoadSmall0" + i);
            }
            else if (i >= 10)
            {
                F_gos[i] = GameObject.Find("PlaneRoadSmall" + i);
            }
        }
    }

    void Fix_Morph(bool[] MrphBool, Transform[] startMrkr, Vector3[] endMrkr, int index)
    {
        if (MrphBool[index]) // if is called
        {
            if (F_runOnce[index]) // Initialize the values of a new Tween
            {
               // F_height[index] = startMrkr[index].position.y - 50.0f; //SET HEIGHT           
                F_startTime[index] = Time.time;
              
                F_journeyLength[index] = Vector3.Distance(new Vector3(startMrkr[index].position.x, endMrkr[index].y, startMrkr[index].position.z), startMrkr[index].position);
                F_runOnce[index] = false;
            }

            F_distCovered[index] = (Time.time - F_startTime[index]) * F_speed[index];
            F_fracJourney[index] = F_distCovered[index] / F_journeyLength[index];

            F_gos[index].transform.position = Vector3.Lerp(startMrkr[index].position, new Vector3(startMrkr[index].position.x,endMrkr[index].y, startMrkr[index].position.z), F_fracJourney[index]);
     
            //Arrived to Target
            if (F_distCovered[index] >= F_journeyLength[index])
            {
                F_boolean[index] = false;
            }
        }
    }
    
    void Update()
    {
       //Time.timeScale = testscale; // SCALE

        for (int i = 1 ; i < 121; i++)  // 1 - 120
        {
             Fix_Morph(F_boolean, F_startMarker, F_endMarker, i);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (colliderType == 0) // Move if collides with OriginCollider
        {
            if (other.name.Contains("PlaneRoadSmall")) { // if is a PlaneRoadSmall then TELEPORT  by (-7.5 x Rows) =  (-7.5 x 24)  = - 180
                other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 180.0f);// move 30 unit down when dissapears
            }
        }

        if (colliderType == 1) // Move if collides with EndColliderDown
        {
            if (other.name.Contains("PlaneRoadSmall"))
            {
                if (transitionType == 0) // MOVE DOWN TRANSITION
                {
                // scaleDown(other.gameObject, 6.276f, 1.0f, 7.5f); // Scale back to normal
                int myindex = int.Parse(other.transform.name.Replace("PlaneRoadSmall", ""));

                F_startMarker[myindex] = other.transform;
                F_endMarker[myindex] = new Vector3(other.transform.position.x, other.transform.position.y - 50.0f, other.transform.position.z);

                F_runOnce[myindex] = true;
                F_boolean[myindex] = true;
                }
            }
        }

        if (colliderType == 2)  // Move if collides with EndColliderUp
        {
            if (other.name.Contains("PlaneRoadSmall"))
            { 
                if (transitionType == 0) // MOVE UP TRANSITION
                {
                // scaleDown(other.gameObject, 6.276f, 1.0f, 7.5f); // Scale back to normal
                int myindex = int.Parse(other.transform.name.Replace("PlaneRoadSmall", ""));

                F_startMarker[myindex] = other.transform;
                F_endMarker[myindex] = new Vector3(other.transform.position.x, other.transform.position.y + 50f, other.transform.position.z);

                F_runOnce[myindex] = true;
                F_boolean[myindex] = true;
                }
            }
        }
    }

    void scaleDown(GameObject go, float ScaleFactorX, float ScaleFactorY, float ScaleFactorZ)
    {
        go.transform.localScale = new Vector3(ScaleFactorX, ScaleFactorY, ScaleFactorZ);
    }
*/
}
