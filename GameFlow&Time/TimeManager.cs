using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager timeManager;
    public enum Estaciones { Primavera, Verano, Invierno }
    public UnityEvent añoNuevo;
    public UnityEvent preAñoNuevo;
    public UnityEvent pauseEvent,playEvent;
    public bool pause = false;//is the game paused?
    public float timeIncrement=0;//acummulative source of time    
    public float year=0;//displayed year
    [Range(1,2.5f)]
    public float deltaIncrement=1;//fastforwarding, rewind.
    public float aYearForMe;//the number a year is to me, in relative terms to the delta increment.   
    public Estaciones estacion;
    public Image timeSliderUI;    
    public int centinela;

    private void Awake()//finish the Singleton properly******
    {
        timeManager = this;
    }

    private void Update()
    {
        if (!pause)//if game not paused
        {
            timeIncrement += Time.deltaTime * deltaIncrement; //frame to frame increment
            timeSliderUI.fillAmount = (timeIncrement / aYearForMe);
            if (timeIncrement < 60)
            {
                estacion = Estaciones.Primavera;
            }
            else
            {
                if (timeIncrement < 120)
                {
                    estacion = Estaciones.Verano;
                }
                else
                {
                    estacion = Estaciones.Invierno;
                }
            }
            if (centinela != year)
            {
                preAñoNuevo.Invoke();
                centinela=Mathf.RoundToInt(year);
            }
            

            if (timeIncrement >= aYearForMe)
            {              
                timeIncrement =0;
                year++;
                añoNuevo.Invoke();
            }
        }
    }

    public void PauseUnpause()
    {
        pause=!pause;
        if (pause)
        {
            pauseEvent.Invoke();
        }
        else
        {
            playEvent.Invoke();
        }
    }



}
