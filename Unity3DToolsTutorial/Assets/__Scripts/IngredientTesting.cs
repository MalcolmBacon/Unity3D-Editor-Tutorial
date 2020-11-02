using UnityEngine;

public enum IngredientUnit { Spoon, Cup, Bowl, Piece }

// Custom serializable class
[System.Serializable]
public class Ingredient
{
    public string name;
    public int amount = 1;
    public IngredientUnit unit;
}

//This is not an editor script
class IngredientTesting : MonoBehaviour
{
    [Range(1, 10)]
    public int myInt;
    public Ingredient potionResult;
    public Ingredient[] potionIngredients;

    void Update()
    {
        // Update logic here...
    }
}
