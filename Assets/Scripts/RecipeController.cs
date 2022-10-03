using UnityEngine;
using UnityEngine.Events;

public class RecipeController : MonoBehaviour
{
    public RecipeSO[] AllRecipes;
    public UnityEvent<RecipeSO> OnCompleteRecipe = null;
    public UnityEvent OnFailedRecipe;
    
    public void CheckRecipes()
    {
        RecipeSO recipe = GetRecipe();

        if (recipe)
        {
            Execute(recipe);
            Inventory.playerInventory.Empty();
        }
        else if (Inventory.playerInventory.IsFull())
        {
            OnFailedRecipe?.Invoke();
            Inventory.playerInventory.Empty();
        }
    }
    
    public RecipeSO GetRecipe()
    {
        RecipeSO recipeFound = null;
        bool bSuccess = false;

        foreach (var recipe in AllRecipes)
        {
            foreach (var ingredient in recipe.Ingredients)
            {
                if (!Inventory.playerInventory.Contains(ingredient.ItemIn))
                {
                    bSuccess = false;
                    break;
                }
                
                bSuccess = true;
            }

            if (bSuccess)
            {
                recipeFound = recipe;
                break;
            }
        }

        return recipeFound;
    }
    
    public void Execute(RecipeSO recipe)
    {
        OnCompleteRecipe?.Invoke(recipe);

        foreach (var ingredient in recipe.Ingredients)
        {
            ItemContainer itemContainer = ingredient.ItemIn.Container;
            if (itemContainer == null)
            {
                Debug.LogError($"Unknow response from : {ingredient.ItemIn.Name}");
                continue;
            }

            itemContainer.Load(ingredient.ItemOut);
        }
    }
}
