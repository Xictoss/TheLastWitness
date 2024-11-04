using LTX.Singletons;
using UnityEngine;

namespace TheLastWitness.Core.Camera
{
    public class GameCamera : MonoSingleton<GameCamera>
    {
        public static Vector3 Forward => Instance.transform.forward;
    }
}