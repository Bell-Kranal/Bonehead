using UnityEngine;

namespace Data.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Player/AnimationStaticData", fileName = "AnimationsData")]
    public class AnimationsPlayerStaticData : ScriptableObject
    {
        public string[] AnimationNames;
    }
}