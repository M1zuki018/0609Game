using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private static int score, mushroomCitizen, bambooCitizen;

    public static void AddScore(int point)
    {
        score += point;
    }

    public static int GetScore()
    {
            return score;
    }

    public static void Init()
    {
        score = 0;
        mushroomCitizen = 0;
        bambooCitizen = 0;
    }

    public static void AddMushrooms(int count)
    {
        mushroomCitizen += count;
    }

    public static void AddBamboo(int count)
    {
        bambooCitizen += count;
    }
}