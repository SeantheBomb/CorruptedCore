using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using Corrupted;



[NodeWidth(250), NodeTint(130, 30, 20), CreateNodeMenu("SFX/NarratorSubtitle")]
public class NarratorSubtitleNode : NarratorStackNode
{
    //public KeyVariable key;
    public StringVariable subtitle;
    public KeyVariable viewKey;


    public override IEnumerator PlayNode(SequenceSystemManager view)
    {
        DynamicInfoPanelView panel = DynamicInfoPanelView.GetInstance(viewKey);
        panel.Show();
        panel.UpdateText(subtitle);
        yield return base.PlayNode(view);
    }


}
