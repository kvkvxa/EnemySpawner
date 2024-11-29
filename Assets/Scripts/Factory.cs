using UnityEngine;

public class Factory : MonoBehaviour
{
    public Enemy Create(Enemy enemyPrefab, Vector3 position, Color color)
    {
        Enemy newEnemy = Instantiate(enemyPrefab, position, Quaternion.identity);
        newEnemy.SetColor(color);

        return newEnemy;
    }
}