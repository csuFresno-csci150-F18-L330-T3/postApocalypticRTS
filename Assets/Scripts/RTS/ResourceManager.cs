using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RTS
{
    public static class ResourceManager
    {
        
        private static Vector3 invalidPosition = new Vector3(-99999, -99999, -99999);
        private static Bounds invalidBounds = new Bounds(new Vector3(-99999, -99999, -99999), new Vector3(0, 0, 0));
        public static Vector3 InvalidPosition { get { return invalidPosition; } }
        public static Bounds InvalidBounds { get { return invalidBounds; } }
    }
}