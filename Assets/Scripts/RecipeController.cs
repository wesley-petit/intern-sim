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
            ITagResponse[] tagResponses = ingredient.Item.Container;

            foreach (var tagResponse in tagResponses)
            {
                foreach (var addTag in ingredient.AddedTags)
                {
                    tagResponse.Add(addTag);
                }

                foreach (var removeTag in ingredient.AddedTags)
                {
                    tagResponse.Remove(removeTag);
                }
            }
        }
    }
}
