using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Corrupted.UIFactory
{

    [CreateAssetMenu(fileName = "UIPack", menuName = "Corrupted/UIFactory/Kit/Pack")]
    public class UIKitPack : UIKit
    {

        [SerializeField]
        private UIKit[] kits;

        public override UIView[] prefabs => kits.SelectMany((k)=>k.prefabs).ToArray();
    }
}
