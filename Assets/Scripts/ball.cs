using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Ensure this is included to use UI Text
using UnityEngine.SceneManagement;



public class ball : MonoBehaviour
{
    public float force;
    public GameObject splash;  // Corrected to GameObject
    public Text score_txt;
    private int score = 0;  // Declare and initialize score variable
    public GameObject GameOverMenu;
    bool addforce;

    public Text highscore_txt;
    private int highscore;  // Declare and initialize score variable


    public GameObject LevelCompleted_Menu;

    void Start()
    {
        addforce = true;
        highscore = PlayerPrefs.GetInt("highscore", 0);  // Default to 0 if not found
        
        highscore_txt.text = "Highest Score: " + PlayerPrefs.GetInt("highscore");
        Debug.Log("Start - Highscore loaded: " + highscore);  // Debugging line


    }


    void OnTriggerEnter(Collider col)
    {


        if (col.gameObject.tag == "score")
        {
            // saving the score in storeage for mobile and pc both
            score=score+100;
            Debug.Log("OnTriggerEnter - Score updated: " + score);  // Debugging line

            //int highscore = PlayerPrefs.GetInt("highscore");
            if (score> PlayerPrefs.GetInt("highscore"))
            {
                //highscore = score;
                PlayerPrefs.SetInt("highscore", score);
                //highscore_txt.text = "Highest Score: " + PlayerPrefs.GetInt("highscore") + "";

                Debug.Log("OnTriggerEnter - New highscore! Updated highscore: " + highscore);  // Debugging line

            }
            score_txt.text = "Score: " + score + " ";
            //score_txt.text = score.ToString();  // Update the text component

        }
    }

    void Update()
    {
        // added + factor so camera move with ball and camera dont jerk on movement while ball bounce
        if (transform.position.y +2.62f < Camera.main.transform.position.y)
        {
            Vector3 pos = Camera.main.transform.position;
            pos.y = transform.position.y +2.62f;
            Camera.main.transform.position = pos;
        }
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "helix_piece" && addforce)
        {
            addforce = false;
            Invoke("fix", 0.5f);


            gameObject.GetComponent<AudioSource>().Play();
            // Corrected method name to GetComponent
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1f, 0) * Time.deltaTime * force);

            // Corrected the method name to Instantiate
            GameObject splash1 = Instantiate(splash);  // Instantiate at the ball's position with no rotation
            // instantiate at specific location where ball collide
            Vector3 pos = transform.position;
            pos.y = pos.y - 0.2f;
            splash1.transform.position = pos;


            splash1.transform.SetParent(GameObject.Find("helix").transform);




            //    GameObject helix = GameObject.Find("helix");
            //    if (helix != null)
            //    {
            //        splash1.transform.SetParent(helix.transform);
            //    }
            //    else
            //    {
            //        Debug.LogWarning("Helix object not found!");
            //    }

            //    // Optionally, set the splash's local position (relative to "helix") if needed
            //    splash1.transform.localPosition = Vector3.zero;  // Set it to the center of "helix" if needed

            //}
        }


         else if (col.gameObject.tag == "game_over")
        {
            GameOverMenu.SetActive(true);
        }


        else if (col.gameObject.tag == "completed")
        {
            LevelCompleted_Menu.SetActive(true);
        }


    }

    public void Retry_btn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void NextLevel_btn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void quit_btn()
    {
        Application.Quit();
    }


    // Method for going to the Main Menu
    public void GoToMainMenu()
    {
        // Load the Main Menu scene (ensure it's in Build Settings)
        SceneManager.LoadScene("MainMenu");
    }


    void fix()
    {
        addforce = true;
    }

}
