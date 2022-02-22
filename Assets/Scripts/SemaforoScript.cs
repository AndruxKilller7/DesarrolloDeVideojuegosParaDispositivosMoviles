using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;
using System;

public class SemaforoScript : MonoBehaviour
{
    public int time;
    SpriteRenderer jugador;
    Thread hilo;
    public float tiempoSinCorutina;
    public int contadorSinCo;
    public bool activeThread=false;
    public bool activarSinCorutina;
    public int timeAsync;
    public float timeSin;
    public float timeS=0;
    public float timeF;
    public int contadorThread;

    void Start()
    {
        hilo = new Thread(() => ThreadMethod(timeF));
        jugador = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (hilo.IsAlive)
        {
            Debug.Log("Activo");
        }

        CambiarColorThread();
        SinCorutina(timeSin);
       



    }


    public void ActivarCorutine()
    {
        StartCoroutine(SemaforoCorutne());
    }


    IEnumerator SemaforoCorutne()
    {
        yield return new WaitForSeconds(time);
        jugador.color = Color.red;
        yield return new WaitForSeconds(time);
        jugador.color = Color.white;
        yield return new WaitForSeconds(time);
        jugador.color = Color.red;
        yield return new WaitForSeconds(time);
        jugador.color = Color.white;
        yield return new WaitForSeconds(time);
        jugador.color = Color.red;
        yield return new WaitForSeconds(time);
        jugador.color = Color.white;
        yield return new WaitForSeconds(time);
        jugador.color = Color.green;
        yield return new WaitForSeconds(time);
        jugador.color = Color.white;
        Debug.Log("CorutinaTerminada");
    }

    void ThreadMethod(float time)
    {

        while (activeThread)
        {
            timeS += 0.01f;
            Debug.Log(timeS);
            if (timeS >= time)
            {
                contadorThread += 1;
                timeS = 0;
               

            }

            if(contadorThread==9)
            {
                activeThread = false;
            }





        }
    }

    public void ActivarThread()
    {
        activeThread = true;
        hilo.Start();
        jugador.color = Color.white;


    }

    void CambiarColorThread()
    {
        if(activeThread)
        {
            if (contadorThread == 1)
            {

                jugador.color = Color.red;

            }

            if (contadorThread == 2)
            {

                jugador.color = Color.white;

            }

            if (contadorThread == 3)
            {

                jugador.color = Color.red;

            }

            if (contadorThread == 4)
            {

                jugador.color = Color.white;

            }

            if (contadorThread == 5)
            {

                jugador.color = Color.red;

            }

            if (contadorThread == 6)
            {

                jugador.color = Color.white;

            }

            if (contadorThread == 7)
            {

                jugador.color = Color.green;

            }
            if (contadorThread == 8)
            {

                jugador.color = Color.white;

            }
        }
       
    }
    public void SinCorutinaOn()
    {
        activarSinCorutina = true;
    }

    void SinCorutina(float time)
    {
        if (activarSinCorutina)
        {
            tiempoSinCorutina += 0.1f * Time.deltaTime;
            Debug.Log(tiempoSinCorutina);

            if (tiempoSinCorutina >= time)
            {
                contadorSinCo += 1;
                tiempoSinCorutina = 0;
            }
            if (contadorSinCo == 1)
            {

                jugador.color = Color.red;

            }

            if (contadorSinCo == 2)
            {

                jugador.color = Color.white;

            }

            if (contadorSinCo == 3)
            {

                jugador.color = Color.red;

            }

            if (contadorSinCo == 4)
            {

                jugador.color = Color.white;

            }

            if (contadorSinCo == 5)
            {

                jugador.color = Color.red;

            }

            if (contadorSinCo == 6)
            {

                jugador.color = Color.white;

            }

            if (contadorSinCo == 7)
            {

                jugador.color = Color.green;

            }
            if (contadorSinCo == 8)
            {

                jugador.color = Color.white;

            }

            if (contadorSinCo == 9)
            {
                activarSinCorutina = false;
            }



        }




       
    }

    public void ActivarAsync()
    {
        MyAsync(timeAsync);
    }

    private async void MyAsync(int time)
    {
       
        jugador.color = Color.red;
        await Task.Delay(TimeSpan.FromSeconds(time));
        jugador.color = Color.white;
        await Task.Delay(TimeSpan.FromSeconds(time));
        jugador.color = Color.red;
        await Task.Delay(TimeSpan.FromSeconds(time));
        jugador.color = Color.white;
        await Task.Delay(TimeSpan.FromSeconds(time));
        jugador.color = Color.red;
        await Task.Delay(TimeSpan.FromSeconds(time));
        jugador.color = Color.white;
        await Task.Delay(TimeSpan.FromSeconds(time));
        jugador.color = Color.green;
        await Task.Delay(TimeSpan.FromSeconds(time));
        jugador.color = Color.white;

    }


}
