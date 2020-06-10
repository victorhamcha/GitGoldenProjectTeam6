using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeChecker : MonoBehaviour
{
    static public int intervalYear;
    static public int intervalMonth;
    static public int intervalDay;
    
    
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

        DateTime previousDate = new DateTime(year, month, day);
        DateTime todayDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

        // Calcul de différence de temps
        intervalYear = todayDate.Year - previousDate.Year;
        intervalMonth = todayDate.Month - previousDate.Month;
        intervalDay = todayDate.Day - previousDate.Day;

        year = todayDate.Year;
        month = todayDate.Month;
        day = todayDate.Day;

        // Stocke les variables d'aujourd'hui dans les playerprefs
        PlayerPrefs.SetInt("year", year);
        PlayerPrefs.SetInt("month", month);
        PlayerPrefs.SetInt("day", day);

        
    }
}
