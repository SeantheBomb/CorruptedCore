using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Corrupted
{

    [CreateAssetMenu(fileName = "GameObjectKeyRegister", menuName = "Corrupted/KeyRegisters/GameObject", order = 0)]

    public class KR_GameObject : CorruptedKeyRegister<GameObject>
    {
    }

    public class KR_GameObject_Ref : CorruptedKeyRegRef<GameObject> { }
}
