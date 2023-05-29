using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandeler : MonoBehaviour
{
    AudioSource sound;
    [SerializeField] float SceneDelay = 1f;
    [SerializeField] AudioClip ExplosionSound; 
    [SerializeField] AudioClip VictorySound;

    [SerializeField] ParticleSystem ExplosionParticles; 
    [SerializeField] ParticleSystem VictoryParticles;

    bool isTransitioning = false;
    bool CollisionDesabled = false;
    void Start()
    {
       
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        bool LoadNextSceneCheat = Input.GetKey(KeyCode.L);
        if(LoadNextSceneCheat)
        {
            Invoke("LoadNextScene",SceneDelay);
        }
        else if(Input.GetKey(KeyCode.C))
        {
            CollisionDesabled = !CollisionDesabled;//отключение действий при коллизии
        }

    }

    void OnCollisionEnter(Collision other) 
   {
        if(isTransitioning || CollisionDesabled)
        {return;}

        if(!isTransitioning)
        {
            switch(other.gameObject.tag)
            {
                case "Friendly":
                    {
                        break;
                    }
                case "Finish":
                    {
                        
                        CompleteLvl();
                        break;
                    }
                default:
                    {
                        StartCrush();
                        break;
                    }  
            }
        }
   }

   void StartCrush()
   {
        isTransitioning = true;
        sound.Stop();
        sound.PlayOneShot(ExplosionSound);
        ExplosionParticles.Play();
        //*моя версия*
        // if(isTransitioning == false)
        // {
        //     sound.PlayOneShot(ExplosionSound);
        //     isTransitioning = true; 
        // }    
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene",SceneDelay);
   }

   void ReloadScene()
   {
        string CurrentSceneName =  SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(CurrentSceneName);
        Debug.Log("Scene " + CurrentSceneName + " is restarting");
   }

   void CompleteLvl()
   {    
        isTransitioning = true;
        sound.Stop();
        sound.PlayOneShot(VictorySound);
        VictoryParticles.Play();
        //*моя версия*
        // if(isTransitioning == false)
        // {
        // sound.PlayOneShot(VictorySound);
        // isTransitioning = true; 
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextScene",SceneDelay);
   }

   void LoadNextScene()
   {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        int NextSceneIndex = CurrentSceneIndex + 1;
        if(NextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Congrats! You complete level number "+ (NextSceneIndex));   
            NextSceneIndex = 0;
        }
        else
        {
            Debug.Log("Congrats! You complete level number "+ (NextSceneIndex));
        }
        SceneManager.LoadScene(NextSceneIndex);
   }
}
