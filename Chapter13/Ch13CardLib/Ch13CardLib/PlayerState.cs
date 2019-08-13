using System;

namespace Ch13CardLib
{
    [Serializable]
   public enum PlayerState
    {
        Inactive,
        Active,
        MustDiscard,
        Winner,
        Loser
    }
}
