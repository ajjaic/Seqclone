using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sequence.Board 
{
    public class SequenceBoard : MonoBehaviour
    {
        void Start()
        {
            gameObject.layer = LayerMask.NameToLayer("SequenceBoard");
        }
    }

}