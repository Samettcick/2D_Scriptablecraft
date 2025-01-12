using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Recipe")]
public class SCRecipe : ScriptableObject
{   
    public SCItem output;

    public SCItem[] Recipe = new SCItem[9];
    
}


