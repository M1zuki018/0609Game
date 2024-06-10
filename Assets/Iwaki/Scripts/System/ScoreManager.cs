using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Collider2D mushroomArea, bambooArea;
    [SerializeField] int score, mushroomCitizens, bambooCitizens;

    protected static ScoreManager Instance;
    protected static Collider2D MushroomArea => Instance.mushroomArea;
    protected static Collider2D BambooArea => Instance.bambooArea;

    protected static int Score { get => Instance.score; set => Instance.score = value; }
    protected static int MushroomCitizens { get => Instance.mushroomCitizens; set => Instance.mushroomCitizens = value; }
    protected static int BambooCitizens { get => Instance.bambooCitizens; set => Instance.bambooCitizens = value; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
            Instance = this;

        }
        else if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    public static void AddScore(int point)
    {
        Score += point;
    }

    public static void AddMushrooms(int count)
    {
        MushroomCitizens += count;
    }

    public static void AddBamboo(int count)
    {
        BambooCitizens += count;
    }

    public static int GetContainsArea(Vector3 position)
    {
        if (MushroomArea.bounds.Contains(position))
        {
            return 0;
        }
        else if (BambooArea.bounds.Contains(position))
        {
            return 1;
        }
        return -1;
    }
}
