using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;

public class hitManager : MonoBehaviour {

    private Ray ray;
    private RaycastHit hit;
    public GameObject player;
    //-------------------------------

    public float speed = 25;//Default 25 speed
    public float jumpSpeed = 40;// default 40
    public float jumphigh = 8f;//Default hight 8f

    private int currentPosition = 3;//Default position
    
    // FIX  LERP
    public Transform F_startMarker;
    public Transform F_endMarker;

    private float F_startTime;
    private float F_journeyLength;
    float F_distCovered;

    bool F_runOnce = true;
    bool F_boolean = false;
    // END FIX LERP


    //-------------------------------------------
    //JUMP LERP
    public Transform jumpStartMarker;
    public Transform jumpEndMarker;

    private float jumpStartTime;
    private float jumpJourneyLength;
    float jumpDistCovered;

    bool jumpRunOnce = true;
    bool jumpBoolean = false;
    // END JUMP LERP
  //  public static bool stillJumpling = false;
    
    //Buttons to size
    public Button btnLeft;
    public Button btnRight;
    public Button btnJump;
    public Button btnPause;

    public Text Cronotext;
    public Text Startext;
    private bool pauseBool=false;
    public Image imgStar;
    public Slider sldProgress;

    public float x;
    public float y;
    public Material matPlay;
    public Material matPause;

    void Start()
    {
        //Set Sizes & Positions in Buttons according to Screen Size

        // make float variables of Screen Dimensions
        float screenWidth = float.Parse(Screen.width.ToString());
        float screenHeight = float.Parse(Screen.height.ToString()); 


        btnLeft.image.rectTransform.sizeDelta = new Vector2((screenWidth * 0.25f), screenHeight);  // |↔: 25% | ↕: 100% |
        btnLeft.image.rectTransform.position = new Vector2((screenWidth * 0.125f), (screenHeight * 0.50f)); // |→: 12.5% | ↑: 50.00% |

        btnJump.image.rectTransform.sizeDelta = new Vector2((screenWidth * 0.50f), screenHeight);  // |↔: 50% | ↕: 100% |
        btnJump.image.rectTransform.position = new Vector2((screenWidth * 0.50f), (screenHeight * 0.50f));// |→: 50% | ↑: 50.00% |

        btnRight.image.rectTransform.sizeDelta = new Vector2((screenWidth * 0.25f), screenHeight);  // |↔: 25% | ↕: 100% |
        btnRight.image.rectTransform.position = new Vector2((screenWidth * 0.875f), (screenHeight * 0.50f));// |→: 87.5% | ↑: 50.00% |


        Cronotext.rectTransform.sizeDelta = new Vector2(screenWidth * 0.19f, screenHeight * 0.125f);    // |↔: 19% | ↕: 12.50% |
        Cronotext.rectTransform.position = new Vector2(screenWidth * 0.80f, screenHeight * 0.90f);      // |→: 80% | ↑: 90.00% |
        Cronotext.fontSize = (Screen.height / 10);

        imgStar.rectTransform.sizeDelta = new Vector2(screenHeight * 0.16f, screenHeight * 0.16f); // |↕↔: 16.00% |


        btnPause.image.rectTransform.sizeDelta = new Vector2(screenHeight * 0.10f, screenHeight * 0.10f);  // |↕↔: 10.00% |

        Startext.rectTransform.sizeDelta = new Vector2(screenWidth * 0.90f, (screenHeight * 0.1557f) ); // |↔: 90% | ↕: 15.57% |
        Startext.rectTransform.position = new Vector2((screenWidth * 0.10f), (screenHeight ) * 0.975f); // |→: 10% | ↑: 97.50% |
        Startext.fontSize = (Screen.height / 10);



        RectTransform RT = GameObject.Find("Slider").GetComponent(typeof(RectTransform)) as RectTransform;

        RT.sizeDelta= new Vector2(screenHeight * 0.0667f, screenHeight * 0.50f); // |↕↔:6.667% | ↕:  50% |
        RT.position = new Vector2((screenHeight * 0.0667f), (screenHeight) * 0.2639f); // |→: 6.667% | ↑: 26.39% |

        RectTransform BG = GameObject.Find("Background").GetComponent(typeof(RectTransform)) as RectTransform;

        BG.sizeDelta = new Vector2(screenHeight * 0.0667f, screenHeight * 0.50f); // |↕↔:6.667% | ↕:  50% |
        BG.position = new Vector2((screenHeight * 0.0667f), (screenHeight) * 0.2639f); // |→: 6.667% | ↑: 26.39% |

        //  sldProgress.rectTransform.sizeDelta = new Vector2(screenWidth * 0.90f, (screenHeight * 0.1557f)); // |↔: 90% | ↕: 15.57% |
        //sldProgress.rectTransform.position = new Vector2((screenWidth * 0.10f), (screenHeight) * 0.975f); // |→: 10% | ↑: 97.50% |

    }


    void Fix_Morph(bool MrphBool, Transform startMrkr, Transform endMrkr)
    {
        //Debug.Log("MrphBool:"  + MrphBool + "  startMrkr:" + startMrkr + "  endMrkr:" + endMrkr + "  F_runOnce"+ F_runOnce);

        if (MrphBool) // is Fix is Called?
        {
            if (F_runOnce) // Initialize the values of a new Tween
            {
                F_startTime = Time.time;
                F_journeyLength = Vector3.Distance(startMrkr.position, endMrkr.position);
                F_runOnce = false;
            }


            F_distCovered = (Time.time - F_startTime) * speed;
            float fracJourney = F_distCovered / F_journeyLength;

            player.transform.position = Vector3.Lerp(startMrkr.position, endMrkr.position, fracJourney);

            //Rotate
            //player.transform.Rotate(new Vector3(-200, 0, 0) * Time.deltaTime);//TEMP REMOVED
            // ....</LERP>

          //  Debug.Log(Time.time+ "   -   " + F_startTime + "  *  " + speed);
            //Arrived to Target
            if (F_distCovered >= F_journeyLength)
            {
                F_boolean = false;

              //  Debug.Log("F_distCovered:" + F_distCovered + " / F_journeyLength:" + F_journeyLength);
            }
        }
    }


    void JumpMorph(bool MrphBool, Transform startMrkr, Transform endMrkr)
    {
        if (jumpBoolean)
        {

            if (jumpRunOnce) // Initialize the values of a new Tween
            {
                jumpStartTime = Time.time;
                jumpJourneyLength = Vector3.Distance(startMrkr.position, endMrkr.position);
                jumpRunOnce = false;
            }

            jumpDistCovered = (Time.time - jumpStartTime) * jumpSpeed;
            float fracJourney = jumpDistCovered / jumpJourneyLength;

            player.transform.position = Vector3.Lerp(startMrkr.position, endMrkr.position, fracJourney);

            //Rotate
            player.transform.Rotate(new Vector3(-200, 0, 0) * Time.deltaTime);
            // ....</LERP>

            //Arrived to Target
            if (jumpDistCovered > jumpJourneyLength) jumpBoolean = false;
          
        }

    }


    void Update() {

        


        JumpMorph(jumpBoolean, jumpStartMarker, jumpEndMarker);

#if UNITY_EDITOR

        if (Input.GetKeyDown("up"))
            OnJump();
        

        if (Input.GetKeyDown("left"))
            OnLeft();

        if (Input.GetKeyDown("right"))
            OnRight();

        if (Input.GetKeyDown("space"))
            OnPauseGame();

        
        

#endif


        if (arrow.collisionDetected) { 
            if(arrow.arrowright == true)
            {
                OnLeft();
                OnLeft();
                OnLeft();
                OnLeft();
                arrow.arrowright = false;
            }
            else if (arrow.arrowright == false)
            {
                OnRight();
                OnRight();
                OnRight();
                OnRight();
                arrow.arrowright = true;
            }
            arrow.collisionDetected = false;
        }

        if (SwipeScript.swipeLeft)
        {
            OnLeft();
            SwipeScript.swipeLeft = false;
        }
        else if (SwipeScript.swipeRight)
        {
            OnRight();
            SwipeScript.swipeRight = false;
        }
        else if (SwipeScript.swipeUp)
        {
            OnJump();
            SwipeScript.swipeUp = false;
        }

        //Rotate if positon is more than 11.75 floor
        if (F_startMarker.position.y > 12f)
        {
            player.transform.Rotate(new Vector3(-200, 0, 0) * Time.deltaTime);
        }

        FixPosition(currentPosition);
        
        Fix_Morph(F_boolean, F_startMarker, F_endMarker);
        



    }
    
    public void setStillJumpOff()
    {
       // stillJumpling = false;

    }
    public void OnJump()
    {


        if (CollisionDetector.death == false) { // when Player not dead

           if (CollisionDetector.allowToJump)// Just Jump when grouded
            {
              //  Debug.Log("Entered to OnJump | CollisionDetector.allowToJump :" + CollisionDetector.allowToJump);
                Transform PtargetAlfa = GameObject.Find("MainPlayer").GetComponent(typeof(Transform)) as Transform;
                jumpStartMarker = PtargetAlfa;

                Transform PtargetOmega = GameObject.Find("end2").GetComponent(typeof(Transform)) as Transform;
                jumpEndMarker = PtargetOmega;

                jumpBoolean = true;
                jumpRunOnce = true;
              //  stillJumpling = true;
            }
        }

       
    }

    public void OnRight()
    {
        if (CollisionDetector.death == false)// when Player not dead
        {

           
            if (currentPosition < 5)
                {
                    currentPosition += 1;

                //Transform PtargetAlfa = GameObject.Find("position" + (currentPosition - 1)).GetComponent(typeof(Transform)) as Transform;
                Transform PtargetAlfa = GameObject.Find("MainPlayer").GetComponent(typeof(Transform)) as Transform;
                F_startMarker = PtargetAlfa;

                    Transform PtargetOmega = GameObject.Find("position" + currentPosition).GetComponent(typeof(Transform)) as Transform;
                    F_endMarker = PtargetOmega;

              //  Debug.Log("Targets Setted from OnRight");
                /*
                R_boolean = true;
                    L_boolean = false; //Should set The BOOLEAN RIGHT TO FALSE IN ORDER  TO STOP LERPING

                    R_runOnce = true;
                  */
                F_boolean = false;// canel last fix update
                F_runOnce = true;

            }
       }
    }

    public  void OnLeft()
    {
        if (CollisionDetector.death == false)// when Player not dead
        {
           
            if (currentPosition > 1)
                {
                    currentPosition -= 1;

                    //  Transform PtargetAlfa = GameObject.Find("position" + (currentPosition + 1)).GetComponent(typeof(Transform)) as Transform;
                    Transform PtargetAlfa = GameObject.Find("MainPlayer").GetComponent(typeof(Transform)) as Transform;
                    F_startMarker = PtargetAlfa;

                    Transform PtargetOmega = GameObject.Find("position" + currentPosition).GetComponent(typeof(Transform)) as Transform;
                    F_endMarker = PtargetOmega;

              //  Debug.Log("Targets Setted from OnLeft");
                /*
                L_boolean = true;
                    R_boolean = false; //Should set The BOOLEAN RIGHT TO FALSE IN ORDER  TO STOP LERPING   

                    L_runOnce = true;
                */
                F_boolean = false;// canel last fix update
                F_runOnce = true;
            }
        }
    }

    public void FixPosition(int currentPos)
    {
        if (true/*L_boolean == false && R_boolean == false*/) // Is L and R are not pressed then fix
        {
           // Debug.Log("Entered Current pos" + currentPos);
            switch (currentPos)
            {
                case 1:
                    if (GameObject.Find("MainPlayer").transform.position.x < 13.8f || GameObject.Find("MainPlayer").transform.position.x > 14.8f)
                    {//Do the fix  
                   //     Debug.Log("Fix 1  :" + 13.8f + " slould be < " + GameObject.Find("MainPlayer").transform.position.x + " < " + 14.8f);
                        OnFix(currentPos);
                    }
                    break;
                case 2:
                    if (GameObject.Find("MainPlayer").transform.position.x < 7.799999f || GameObject.Find("MainPlayer").transform.position.x > 8.799999f)
                    {//Do the fix
                     //   Debug.Log("Fix 2  :" + 7.799999f + " slould be < " + GameObject.Find("MainPlayer").transform.position.x + " < " + 8.799999f);
                        OnFix(currentPos);
                    }
                    break;
                case 3:
                    if (GameObject.Find("MainPlayer").transform.position.x < 1.799999f || GameObject.Find("MainPlayer").transform.position.x > 2.799999f)
                    {//Do the fix
                      //  Debug.Log("Fix 3  :" + 1.799999f + " slould be < " + GameObject.Find("MainPlayer").transform.position.x + " < " + 2.799999f);
                        OnFix(currentPos);
                    }
                    break;
                case 4:
                    if (GameObject.Find("MainPlayer").transform.position.x < -4.200002f || GameObject.Find("MainPlayer").transform.position.x > -3.200002f)
                    {//Do the fix
                    //    Debug.Log("Fix 4  :" + -4.200002f + " slould be < " + GameObject.Find("MainPlayer").transform.position.x + " < " + -3.200002f);
                        OnFix(currentPos);
                    }
                    break;
                case 5:
                    if (GameObject.Find("MainPlayer").transform.position.x < -10.200003f || GameObject.Find("MainPlayer").transform.position.x > -9.200003f)
                    {//Do the fix
                      //  Debug.Log("Fix 5  :" + -10.200003f + " slould be < " + GameObject.Find("MainPlayer").transform.position.x + " < " + -9.200003f);
                        OnFix(currentPos);
                    }
                    break;
            }


        }

    }

    public void OnFix(int cp)
    {

               // Debug.Log("OnFix");

        /*
                Transform PtargetAlfa = GameObject.Find("MainPlayer").GetComponent(typeof(Transform)) as Transform;
    F_startMarker = PtargetAlfa;

                Transform PtargetOmega = GameObject.Find("position" + cp).GetComponent(typeof(Transform)) as Transform;
    F_endMarker = PtargetOmega;
    */

                F_boolean = true; // Go an fix
                jumphigh = 4.0f;

        
      
     }
    public void OnTest()
    {
        Debug.Log("Test");
    }

    public void OnRestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void OnPauseGame()
    {
        if (!pauseBool)
        {
            Time.timeScale = 0.0f;//pause
            pauseBool = true;
                
            AudioSource  auSource = GameObject.Find("MainCamera").GetComponent(typeof(AudioSource)) as AudioSource;
            if (auSource != null)
                auSource.Pause();

            AudioSource auSourcePlayer = GameObject.Find("MainPlayer").GetComponent(typeof(AudioSource)) as AudioSource;
            if (auSourcePlayer != null)
                auSourcePlayer.Pause();

            // change material in btn 
            btnPause.image.material = matPlay ;

        }
        else {
            Debug.Log("resumed");
            Time.timeScale = 1; //resume
            pauseBool = false;

            AudioSource auSource = GameObject.Find("MainCamera").GetComponent(typeof(AudioSource)) as AudioSource;
            if (auSource != null)
                auSource.UnPause();

            AudioSource auSourcePlayer = GameObject.Find("MainPlayer").GetComponent(typeof(AudioSource)) as AudioSource;
            if (auSourcePlayer != null)
                auSourcePlayer.UnPause();

            // change material in btn 
            btnPause.image.material = matPause;
        }



        
    }

}




/* //------------------------------Touch Handler-------------------------------------------used to go in Update

 if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
 {
     ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
     Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);

     if (Physics.Raycast(ray, out hit, Mathf.Infinity))
     {
         Debug.Log(hit.transform.gameObject.name);

         if (hit.transform.gameObject.name == "btnLeft") // If pressing left
         {
             Debug.Log("Left");

             //the_animator.Play("move1", -1, 0f);
             //the_animator.enabled = true;
             // player.transform.position = new Vector3(player.transform.position.x + 10f, player.transform.position.y, player.transform.position.z);
         }
            else if (hit.transform.gameObject.name == "btnRight")// If pressing right
            {
                Debug.Log("Right");
                //  player.transform.position = new Vector3(player.transform.position.x - 10f, player.transform.position.y, player.transform.position.z);
            }

            else if (hit.transform.gameObject.name == "btnJump")// If pressing jump
            {
                Debug.Log("Jump From Touch");
                //OnJump();
                //Remove Commets Now
                if (startMarker.position.y < 12f)// just jum when grouded
                {
                    Debug.Log("Jump");
                    boolean = true;
                    Start();
                }

                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 10, player.transform.position.z);
                player.transform.Rotate(new Vector3(-200, 0, 0) * Time.deltaTime);

}
}
}
//-------------------------------------------------------------------------*/
