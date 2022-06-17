using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Corrupted
{

    [CreateAssetMenu(fileName = "GameObjectIntToIntMap", menuName = "Corrupted/Maps/IntToInt", order = 0)]

    public class Map_Int_Int : CorruptedMap<int, int>
    {
    }

    public class Map_Int_Int_Ref : CorruptedMapRef<int, int> { }
}
