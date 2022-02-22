using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class EjemploThreads : MonoBehaviour
{
    Animator control;
    Thread hilo;
    SpriteRenderer playerComponent;

    public int contador = 0;
    void Start()
    {
        playerComponent = GetComponent<SpriteRenderer>();
        control = GetComponent<Animator>();
        hilo = new Thread(() => ThreadMethod());
        hilo.Start();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        CambioColor();
    }

    void ThreadMethod()
    {

        while (true)
        {
            
            contador += 1;
            if (contador > 12)
            {
                contador = 0;
            }
        }
    }


    void CambioColor()
    {
        if(contador==6)
        {
            playerComponent.color = Color.red;
        }
        if(contador==1)
        {
            playerComponent.color = Color.blue;
            
        }
       
    }

}
