using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnObstacles : MonoBehaviour {
    string strmin = "0";
    string strsegs = "0";
    string strmilisegs = "0";

    string strminTemp = "";
    string strsegsTemp = "";
    string strmilisegsTemp = "";

    float passedTime;

    public Text tiempoText;
    
    public GameObject myCube;
    public GameObject[] ArrayColliders = new GameObject[7];
    
    private bool[] created = new bool[100];

    private float[] coordinatesY = new float[100];
    private float[] coordinatesX = new float[100];

    private int[] obstacleCreated = new int[100];

    public float separation;
    public float myOffset; 
    
    public int counter;


    public float gameDurationSegs;

    public Material Global;
    private Color lerpedColor;
    float frac = 0.0f;
    bool callCoroutine = true;

    public void Start()
    {
        // set values to empty
        for (int i = 0; i < created.Length; i++) {
            created[i] = false;
            coordinatesY[i] = 0.0f;
            coordinatesX[i] = 0.0f;

            obstacleCreated[i] = 100;
        }

        //call function to assign cordinates 
        AssignCoordinates();

        //Start Coroutines
        StartCoroutine(DoCheck());
        StartCoroutine(UpdateSlider());

       
        //StartCoroutine(ColorChange(true, new Color32(255, 255, 225, 255)));
        
        

        //Set Default Color      
        Global.color = new Color32(109, 182, 254, 255);//Global.color = new Color32(0, 76, 255, 255);
    }


    public void Update()
    {
        var Crono = Time.timeSinceLevelLoad;
        float mins = Crono / 60;
        float segs = Crono % 60;
        float milisegs = (Crono * 100) % 100;

        if (mins < 10) strminTemp = "0" + mins;
        else strminTemp = "" + mins;

        if (segs < 10) strsegsTemp = "0" + segs;
        else strsegsTemp = "" + segs;

        if (milisegs < 10) strmilisegsTemp = "0" + milisegs;
        else strmilisegsTemp = "" + milisegs;

        // Avoid Bad Roundind 
        strmin = strminTemp.ToString().Substring(0, 2);
        strsegs = strsegsTemp.ToString().Substring(0, 2);
        strmilisegs = strmilisegsTemp.ToString().Substring(0, 2);

        tiempoText.text = strmin + ":" + strsegs + ":" + strmilisegs;


        if (passedTime >= 11.30f && passedTime <= 15f && callCoroutine == true)
        {
            StartCoroutine(ColorChange(true, new Color32(255, 43, 43, 255)));// new Color32(140, 87, 240, 255)
            callCoroutine = false;
       
        }

        if (passedTime >= 16f && passedTime <= 18f)
        {
            callCoroutine = true;
        }


            if (passedTime >= 21.00f && passedTime <= 25f && callCoroutine == true)
        {

            StartCoroutine(ColorChange(true, new Color32(140, 87, 240, 255)));// new Color32(140, 87, 240, 255)
            callCoroutine = false;
 
        }
        //Debug.Log( passedTime);

    }


    IEnumerator ColorChange(bool MrphBool, Color endColor)
    {
 
        
          for (float i = 0.0f; i <= 1.0f; i += 0.1f)
          {
                        
              Global.color = Color.Lerp(Global.color, endColor, i);

             yield return new WaitForSeconds(0.05f);

          }
           

    }








    IEnumerator UpdateSlider()
    {
        for (;;) {
            UpdateSliderBar();
            yield return new WaitForSeconds(.1f);
        }
    }

    public void UpdateSliderBar()//function called once per second
    {
        float convertMin = float.Parse(strmin) * 60f;
        float convertSegs = float.Parse(strsegs);
        float convertMili = float.Parse(strmilisegs) / 100f;

        passedTime = convertMin + convertSegs;
        passedTime = passedTime + convertMili;

        float fracTemp = 100.0f / gameDurationSegs;
        
        Slider Sld = GameObject.Find("Slider").GetComponent(typeof(Slider)) as Slider;

        Sld.value = fracTemp * passedTime;
        

    }



    IEnumerator DoCheck()
    {
        for (;;)
        {
          //  Debug.Log("ProximityCheck");

            counter++;
            CreateBySecond();
            yield return new WaitForSeconds(5f);
        }
    }



    void CreateBySecond()
    {
        for (int i = 0; i < coordinatesY.Length; i++)
        {
            if (coordinatesY[i] != 0.0f)
            {
                //IF TIME CLOSER THAN CREATIIN TIME THEN CREATE and if is not created

                if (coordinatesY[i] <= (10.0f * counter)    && created[i] == false)
                {
                    float sourcePoint =  GameObject.Find("Source_EmptyGo").transform.position.z ;//-201.5f;/

                    GameObject ObstacleSpawn = (GameObject)Instantiate(ArrayColliders[obstacleCreated[i]],

                        new Vector3(
                            coordinatesX[i],
                            10.46f,
                            (sourcePoint - myOffset) +((coordinatesY[i] * separation)) //  Backup  (myOffset + 7.4f) +((coordinates[i] * separation))
                            ),

                        Quaternion.identity);

                    ObstacleSpawn.transform.parent = GameObject.Find("Source_EmptyGo").GetComponent(typeof(Transform)) as Transform;

                    created[i] = true;
                }


            }


            

        }
    }


    public void AssignCoordinates()
    {

        float pos1 = GameObject.Find("position1").transform.position.x;
        float pos2 = GameObject.Find("position2").transform.position.x;
        //6.25
        float pos3 = 2.26f;//-3.724f
        float pos4 = GameObject.Find("position4").transform.position.x;
        float pos5 = GameObject.Find("position5").transform.position.x;





        // float offset;


        //fakers

        coordinatesY[0] = 1f ; obstacleCreated[0] = 3; coordinatesX[0] = pos3;
        coordinatesY[1] = 2f; obstacleCreated[1] = 3; coordinatesX[1] = pos3;
        coordinatesY[2] = 3f; obstacleCreated[2] = 3; coordinatesX[2] = pos3;
        coordinatesY[3] = 4f; obstacleCreated[3] = 3; coordinatesX[3] = pos3;
        coordinatesY[4] = 5f; obstacleCreated[4] = 3; coordinatesX[4] = pos3;
        coordinatesY[5] = 6f; obstacleCreated[5] = 3; coordinatesX[5] = pos3;
        coordinatesY[6] = 7f; obstacleCreated[6] = 3; coordinatesX[6] = pos3;
        coordinatesY[7] = 8f; obstacleCreated[7] = 3; coordinatesX[7] = pos3;
        coordinatesY[8] = 9f; obstacleCreated[8] = 3; coordinatesX[8] = pos3;
        coordinatesY[9] = 10f; obstacleCreated[9] = 3; coordinatesX[9] = pos3;

        coordinatesY[10] = 11f; obstacleCreated[10] = 3; coordinatesX[10] = pos3;
        coordinatesY[11] = 12f; obstacleCreated[11] = 3; coordinatesX[11] = pos3;
        coordinatesY[12] = 13f; obstacleCreated[12] = 3; coordinatesX[12] = pos3;
        coordinatesY[13] = 14f; obstacleCreated[13] = 3; coordinatesX[13] = pos3;
        coordinatesY[14] = 15f; obstacleCreated[14] = 3; coordinatesX[14] = pos3;
        coordinatesY[15] = 16f; obstacleCreated[15] = 3; coordinatesX[15] = pos3;
        coordinatesY[16] = 17f; obstacleCreated[16] = 3; coordinatesX[16] = pos3;
        coordinatesY[17] = 18f; obstacleCreated[17] = 3; coordinatesX[17] = pos3;
        coordinatesY[18] = 19f; obstacleCreated[18] = 3; coordinatesX[18] = pos3;
        coordinatesY[19] = 20f; obstacleCreated[19] = 3; coordinatesX[19] = pos3;
        




        //Obstacles Creation

        /*
        
        coordinatesY[0] = 2.77f + 0.24f; obstacleCreated[0] = 0; coordinatesX[0] = pos3;

        coordinatesY[1] = 5.73f + 0.08f; obstacleCreated[1] = 2; coordinatesX[1] = pos3;
        coordinatesY[2] = 6.94f + 0.30f; obstacleCreated[2] = 3; coordinatesX[2] = pos3;
        coordinatesY[3] = 8.30f + 0.30f; obstacleCreated[3] = 4; coordinatesX[3] = pos3;
        coordinatesY[4] = 9.67f + 0.30f; obstacleCreated[4] = 3; coordinatesX[4] = pos3;

        
        coordinatesY[5] = 11.29f + 0.34f; obstacleCreated[5] = 0; coordinatesX[5] = pos3;

        coordinatesY[6] = 12.69f + 0.05f; obstacleCreated[6] = 4; coordinatesX[6] = pos3;

      
        
        //Arrows
        coordinatesY[7] = 14.20f + 0.20f; obstacleCreated[7] = 7; coordinatesX[7] = pos3;
        coordinatesY[8] = 14.65f + 0.20f; obstacleCreated[8] = 8; coordinatesX[8] = pos3;
        //
  
        coordinatesY[9] = 16.99f + 1.15f; obstacleCreated[9] = 1; coordinatesX[9] = pos3;

        coordinatesY[10] = 18.00f + 1.04f; obstacleCreated[10] = 2; coordinatesX[10] = pos3;

        coordinatesY[11] = 19.58f + 1.21f; obstacleCreated[11] = 3; coordinatesX[11] = pos3;


        coordinatesY[12] = 21.03f + 1.49f; obstacleCreated[12] = 0; coordinatesX[12] = pos3;

        
        coordinatesY[13] = 22.07f + 1.6f; obstacleCreated[13] = 3; coordinatesX[13] = pos3;
        coordinatesY[14] = 22.514f + 1.6f; obstacleCreated[14] = 2; coordinatesX[14] = pos3;
        coordinatesY[15] = 23.19f + 1.6f; obstacleCreated[15] = 3; coordinatesX[15] = pos3;
        coordinatesY[16] = 23.88f + 1.6f; obstacleCreated[16] = 2; coordinatesX[16] = pos3;
        coordinatesY[17] = 24.571f + 1.6f; obstacleCreated[17] = 1; coordinatesX[17] = pos3;
        coordinatesY[18] = 25.271f + 1.6f; obstacleCreated[18] = 2; coordinatesX[18] = pos3;
        coordinatesY[19] = 25.96f + 1.6f; obstacleCreated[19] = 3; coordinatesX[19] = pos3;
        coordinatesY[20] = 26.64f + 1.6f; obstacleCreated[20] = 2; coordinatesX[20] = pos3;
        coordinatesY[21] = 27.335f + 1.6f; obstacleCreated[21] = 1; coordinatesX[21] = pos3;
     
        coordinatesY[22] = 27.509f + 1.6f; obstacleCreated[22] = 8; coordinatesX[22] = pos3;
        coordinatesY[23] = 28.030f + 1.6f; obstacleCreated[23] = 5; coordinatesX[23] = pos3;
        
     /*
     //Stars Creation
     offset = 0.28f;

     coordinatesY[13] = 13.901f + offset; obstacleCreated[13] = 9; coordinatesX[13] = pos5;

     offset = -0.25f;
     coordinatesY[14] = 15.950f + offset; obstacleCreated[14] = 9; coordinatesX[14] = pos4;
     coordinatesY[15] = 16.29f + offset; obstacleCreated[15] = 9; coordinatesX[15] = pos3;
     coordinatesY[16] = 16.64f + offset; obstacleCreated[16] = 9; coordinatesX[16] = pos2; 
     coordinatesY[17] = 16.99f + offset; obstacleCreated[17] = 9; coordinatesX[17]  = pos1;

     */

        /*   coordinates[15] = 17.34f + offset; obstacleCreated[15] = 2;
           coordinates[16] = 17.68f + offset; obstacleCreated[16] = 3;
           coordinates[17] = 18.01f + offset; obstacleCreated[17] = 4;

          coordinates[18] = 18.53f + offset; obstacleCreated[18] = 3;
          coordinates[19] = 18.89f + offset; obstacleCreated[19] = 2;
          coordinates[20] = 19.24f + offset; obstacleCreated[20] = 1;

          coordinates[21] = 19.57f + offset; obstacleCreated[21] = 2;
          coordinates[22] = 19.75f + offset; obstacleCreated[22] = 2;

          coordinates[23] = 20.10f + offset; obstacleCreated[23] = 3;
          coordinates[24] = 20.44f + offset; obstacleCreated[24] = 2;
          coordinates[25] = 21.10f + offset; obstacleCreated[25] = 0;

          coordinates[26] = 21.10f + offset; obstacleCreated[26] = 6;
          coordinates[27] = 22.10f + offset; obstacleCreated[27] = 6;
          coordinates[28] = 23.10f + offset; obstacleCreated[28] = 6;
          coordinates[29] = 24.10f + offset; obstacleCreated[29] = 6;

          /*
          coordinates[26] = 18.01f + offset; obstacleCreated[26] = 4;
          coordinates[27] = 18.01f + offset; obstacleCreated[27] = 4;
          coordinates[28] = 18.01f + offset; obstacleCreated[28] = 4;
          */
        //coordinates[18] = 11.65f; obstacleCreated[18] = 3;
        //30.05011 move -z


    }

}
