using UnityEngine;

using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionDetector : MonoBehaviour
{
    public static bool allowToJump = false;
    public static bool death = false;


    public static int starCount;
    private ParticleSystem PDrag;

    public Text starText;
    void Start()
    {
        PDrag = GameObject.Find("PSystemDrag").GetComponent<ParticleSystem>();
    
    }

    void Update()
    {
        // Particle Drag
        PDrag.transform.position = GameObject.Find("MainPlayer").transform.position;
        PDrag.transform.position = new Vector3(PDrag.transform.position.x , PDrag.transform.position.y - 1.05f, PDrag.transform.position.z + 1.5f);
        //

      //  Color lerpedColor;//     171 138 10

      //  lerpedColor = Color.Lerp(new Color32(70, 163, 255, 255), new Color32(140, 87, 240, 255), Mathf.PingPong(Time.time, 1));
      //  Global.color = lerpedColor;

        //Debug.Log("allowToJump: " + allowToJump + Time.frameCount);
    }
    void OnCollisionStay(Collision collisionInfo)
    {
        foreach (ContactPoint contact in collisionInfo.contacts)
        {
           // Debug.Log("Collider name: " + collisionInfo.collider.name + Time.frameCount);

            if (collisionInfo.collider.name.Contains("PlaneRoad"))
            {
                allowToJump = true;

              
                if (!death)
                         PDrag.Play();
            }
        }
    }
    
    void OnCollisionExit(Collision collisionInfo)
    {
      allowToJump = false;

       
        PDrag.Stop();
    }
   
    IEnumerator Restart_SlowMotion()
    {

      // Vibration.Vibrate();

        MeshRenderer mesh = GameObject.Find("RubikDone").GetComponent(typeof(MeshRenderer)) as MeshRenderer;
        TrailRenderer trail = GameObject.Find("Trail").GetComponent(typeof(TrailRenderer)) as TrailRenderer;
        var playerParticle = GameObject.Find("PlayerTorch").GetComponent<ParticleSystem>();
   
        
        mesh.enabled= false;
        trail.enabled = false;
        playerParticle.Stop();
        
        var exp = GameObject.Find("Explosion04b").GetComponent<ParticleSystem>();
        exp.transform.position = GameObject.Find("MainPlayer").transform.position;
        exp.transform.position = new Vector3(exp.transform.position.x, exp.transform.position.y + 2.5f, exp.transform.position.z); 
        exp.Play();


        var exp2 = GameObject.Find("PSystem").GetComponent<ParticleSystem>();
        exp2.transform.position = exp.transform.position;
        exp2.Play();

        PDrag.Stop();

        AudioSource auSource = GameObject.Find("MainCamera").GetComponent(typeof(AudioSource)) as AudioSource;
        if (auSource != null)
            auSource.Stop();


        yield return new WaitForSeconds(0.01f);
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        death = false;

        starCount = 0;
        Time.timeScale = 1.0f;
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag); 
        if ((other.name == "Barricade" && !death) || (other.tag == "Barricade" && !death)) // detect Collision just when still alive
        {
            
           death = true;
           // hitManager.stillJumpling = false;
            allowToJump = false;

            AudioSource auSourcePlayer = GameObject.Find("MainPlayer").GetComponent(typeof(AudioSource)) as AudioSource;
            if (auSourcePlayer != null)
                auSourcePlayer.Play();

           
           StartCoroutine(Restart_SlowMotion()); // Restart Level

         }
        if (other.tag == "Star")
        {

            starCount++;

            starText.text = "" + starCount;
            Destroy(other.gameObject);
         

        }

        if (other.name == "TriggerColor1")
        {
            //Global.color = new Color32(0, 255, 55, 255);

        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "PlaneLava") // Rango de tolerancia por rebote
        {
            //   allowToJump = false;
        }
    }




}
