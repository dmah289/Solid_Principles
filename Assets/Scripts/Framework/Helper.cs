using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public static class Helper
    {
        private static readonly Dictionary<float, WaitForSeconds> WaitDict = new();

        public static WaitForSeconds GetWait(float time)
        {
            if(WaitDict.TryGetValue(time, out var result))
                return result;
            
            WaitDict[time] = new(time);
            return WaitDict[time];
        }
    }
}