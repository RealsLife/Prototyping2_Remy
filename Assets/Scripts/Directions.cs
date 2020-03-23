using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
        [System.Serializable]
        class Directions//Richtingen zijn relatief tegenover de grid
        {
        [Header("Left")]
        public bool LeftEnabled;
        [Header("Right")]
        public bool RightEnabled;
        [Header("Up")]
        public bool UpEnabled;
        [Header("Down")]
        public bool DownEnabled;
    }
}
