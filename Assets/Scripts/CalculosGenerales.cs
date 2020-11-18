using UnityEngine;

public class CalculosGenerales : ICalculosGenerales
{
    public int CalcularintRandom(int min, int max)
    {
        return Random.Range(min, max);
    }
}