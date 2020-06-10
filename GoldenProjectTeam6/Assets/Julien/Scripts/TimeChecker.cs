using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class TimeChecker : MonoBehaviour
{
    
    static public double intervalDay;
    [SerializeField]
    static public bool isTuto = true;

    private int year = 2018;
    private int month = 06;
    private int day = 05;

    void Start()
    {
        
        // Cherche les variables si elles sont déjà stockées
        if (PlayerPrefs.HasKey("year") && PlayerPrefs.HasKey("month") && PlayerPrefs.HasKey("day"))
        {
            // Prend les variables
            year = PlayerPrefs.GetInt("year");
            month = PlayerPrefs.GetInt("month");
            day = PlayerPrefs.GetInt("day");
        }
        else
        {
            isTuto = true;
        }

        DateTime previousDate = new DateTime(year, month, day);
        DateTime todayDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

       intervalDay = (todayDate - previousDate).TotalDays;
        if(SceneManager.GetActiveScene().name.ToString()=="MenuModifVic")
       isTuto = intervalDay > 7;
        // Calcul de différence de temps
       

        year = todayDate.Year;
        month = todayDate.Month;
        day = todayDate.Day;

        // Stocke les variables d'aujourd'hui dans les playerprefs
        PlayerPrefs.SetInt("year", year);
        PlayerPrefs.SetInt("month", month);
        PlayerPrefs.SetInt("day", day);

        
    }
}
