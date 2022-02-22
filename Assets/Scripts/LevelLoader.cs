using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject loadingScreen;
    public Slider slider;
    public bool pasarDeNivel1;
    public bool pasarDeNivel2;
    public Text progressText;
    public bool activarCargaConProgresseBar;
    public bool activarCargaPorBackground;
    static public int indexScene=0;
    public int examinarIndex;
    
    void Start()
    {
        
    }

    //public void loadLevel(int sceneIndex)
    //{
    //    StartCoroutine(LoadAsynchronously(sceneIndex));
    //}
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";
            Debug.Log(operation.progress);
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        examinarIndex = indexScene;
        if(activarCargaConProgresseBar && pasarDeNivel1)
        {
            
            StartCoroutine(LoadSceneProgresseBar(indexScene));
        }


        if (activarCargaPorBackground && pasarDeNivel2)
        {

            StartCoroutine(CargaEnBackground(indexScene));
        }

        
    }


    IEnumerator LoadSceneProgresseBar(int sceneIndex)
    {
       
       
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);


        while (operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / .9f) ;
            slider.value = progress;
            progressText.text = progress * 100f + "%";
            Debug.Log(operation.progress);
          
           
            //operation.allowSceneActivation = true;
            yield return null;
        }
    
    }


    IEnumerator CargaEnBackground(int sceneIndex)
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            
            //slider.value = asyncOperation.progress * 100;
            Debug.Log(asyncOperation.progress);
            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
               
                //Wait to you press the space key to activate the Scene
                if (pasarDeNivel2)
                {
                    //Activate the Scene
                    asyncOperation.allowSceneActivation = true;
                }
                    
            }

            yield return null;
        }
    }

    public void ActiveLoadProgresseBar()
    {
       
            activarCargaConProgresseBar = true;
           
        
        
    }

    public void ActiveLoadBackgroundr()
    {
        
      
            indexScene += 1;
            activarCargaPorBackground = true;
            StartCoroutine(CargaEnBackground(indexScene));
        
        
       
      

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("door"))
        {
           
            Debug.Log("Abierto");
            if(activarCargaConProgresseBar)
            {
                
                    indexScene += 1;
               
               
               
                pasarDeNivel1 = true;
            }
            if (activarCargaPorBackground)
            {
                pasarDeNivel2 = true;
            }

            //StartCoroutine(LoadAsynchronously(indexScene)); 
            //StartCoroutine(LoadSceneProgresseBar(indexScene));
            //StartCoroutine(CargaEnBackground(indexScene));

        }
    }
}
