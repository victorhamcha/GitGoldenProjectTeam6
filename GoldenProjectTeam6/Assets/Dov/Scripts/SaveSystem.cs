﻿using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer (ContainAllObjectTree objectTree, GameManager cardsAlreadyDraw, PauseMenu option)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        Debug.Log(path);

        PlayerData data = new PlayerData(objectTree, cardsAlreadyDraw, option);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveCards(CardValuesWithScriptable cardValue, SuccesManager allSucces)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/cards.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        Debug.Log(path);

        CardsData data = new CardsData(cardValue, allSucces);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SavePassport(ContratsPanel contrat)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/passport.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        Debug.Log(path);

        PassportData data = new PassportData(contrat);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PassportData LoadPassport()
    {
        string path = Application.persistentDataPath + "/passport.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PassportData data = formatter.Deserialize(stream) as PassportData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

    public static CardsData LoadCards()
    {
        string path = Application.persistentDataPath + "/cards.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CardsData data = formatter.Deserialize(stream) as CardsData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}
