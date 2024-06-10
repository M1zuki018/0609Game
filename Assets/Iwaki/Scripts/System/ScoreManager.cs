using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    //protected static ScoreManager Instance;
    [SerializeField] Collider2D mushroomArea, bambooArea;
    //protected static Collider2D MushroomArea => Instance.mushroomArea;
    //protected static Collider2D BambooArea => Instance.bambooArea;

    [SerializeField] int score, mushroomCitizens, bambooCitizens;
    public int Score { get => score; set { score = value; } }

    //protected static int Score { get => Instance.score; set => Instance.score = value; }
    //protected static int MushroomCitizens => Instance.mushroomCitizens;
    //protected static int BambooCitizens => Instance.bambooCitizens;

    //private void Awake()
    //{
    //    if (Instance != null && Instance != this)
    //    {
    //        Destroy(Instance);
    //        Instance = this;
            
    //    }
    //    else if(Instance == null)
    //    {
    //        Instance = this;
    //    }
    //}
    public void AddScore(int point)
    {
        score += point;
    }

    public void AddMushrooms(int count)
    {
        mushroomCitizens += count;
    }

    public void AddBamboo(int count)
    {
        bambooCitizens += count;
    }

    public int GetContainsArea(Vector3 position)
    {
        if (mushroomArea.bounds.Contains(position))
        {
            return 0;
        }
        else if (bambooArea.bounds.Contains(position))
        {
            return 1;
        }
        return -1;
    }
}
