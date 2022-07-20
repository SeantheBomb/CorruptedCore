using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyCommandListener : CorruptedCommandListener<Rigidbody>
    {
        public override Rigidbody GetReceiver()
        {
            return GetComponent<Rigidbody>();
        }


        //private void FixedUpdate()
        //{
        //    foreach(CommandListener cl in buttons)
        //    {
        //        if (cl.command is CorruptedCommandFixed<Rigidbody>)
        //            (cl.command as CorruptedCommandFixed<Rigidbody>).WhileFixedExecute(receiver);
        //    }
        //    foreach (CommandAxisListener cal in axes)
        //    {
        //        if (cal.command is CorruptedAxisCommandFixed<Rigidbody>)
        //            (cal.command as CorruptedAxisCommandFixed<Rigidbody>).WhileFixedExecute(receiver);
        //    }
        //}

        private void FixedUpdate()
        {
            foreach(CommandListener cl in buttons)
            {
                if (cl.command is IFixedUpdateListener<Rigidbody>)
                    (cl.command as IFixedUpdateListener<Rigidbody>).OnFixedUpdate(receiver);
            }
            foreach(CommandAxisListener cl in axes)
            {
                if (cl.command is IFixedUpdateListener<Rigidbody>)
                    (cl.command as IFixedUpdateListener<Rigidbody>).OnFixedUpdate(receiver);
            }
        }
    }

    
}
