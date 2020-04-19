using UnityEngine;

namespace Sequence.Board
{
    public class SequenceBoard : MonoBehaviour
    {
        private void Start()
        {
            gameObject.layer = LayerMask.NameToLayer("SequenceBoard");
        }
    }
}