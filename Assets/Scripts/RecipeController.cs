using UnityEngine;

public class RecipeController : MonoBehaviour
{
    public RecipeSO[] AllRecipes;
    public GameObject Original;

    public void CheckRecipes()
    {
        bool bSuccess = false;

        foreach (var recipe in AllRecipes)
        {
            foreach (var ingredient in recipe.Ingredients)
            {
                if (!Inventory.playerInventory.Contains(ingredient.Item))
                {
                    bSuccess = false;
                    break;
                }

                bSuccess = true;
            }

            if (bSuccess)
            {
                Manage(recipe);
                break;
            }
        }
    }

    public void Manage(RecipeSO recipe)
    {
        foreach (var ingredient in recipe.Ingredients)
        {
            ITagResponse tagResponse = ingredient.Item.Container;

            if (tagResponse == null)
            {
                Debug.LogError($"Unknow response from : {ingredient.Item.Name}");
                continue;
            }

            tagResponse.Add(ingredient.AddedTag);
            tagResponse.Remove(ingredient.RemoveTag);
        }
    }
}
