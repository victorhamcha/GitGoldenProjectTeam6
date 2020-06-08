using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeChecker : MonoBehaviour
{
    static public TimeSpan interval;
    
    DateTime todayDate;
    private int year = 2100;
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
            year = PlayerPrefs.GetInt("year");
        }

        DateTime previousDate = new DateTime(year, month, day);
        todayDate = DateTime.Today;

        // Calcul de différence de temps
        interval = todayDate - previousDate;

        year = todayDate.Year;
        month = todayDate.Month;
        day = todayDate.Day;

        // Stocke les variables d'aujourd'hui dans les playerprefs
        PlayerPrefs.SetInt("year", year);
        PlayerPrefs.SetInt("month", month);
        PlayerPrefs.SetInt("day", day);

        
    }
}
