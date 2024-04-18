using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted.UIFactory
{

    [CreateAssetMenu(fileName = "UIKit", menuName = "Corrupted/UIFactory/Kit/Module")]
    public class UIKitModule : UIKit
    {
        [SerializeField]
        private UIView[] _prefabs;

        public override UIView[] prefabs => _prefabs;
    }
}
