using Scripts.VictoryCondition;
using System;
using Scripts.Enums;
using Scripts.Balls;

namespace Scripts.Factory
{
    public class VictoryConditionFactory
    {
        public VictoryCondition.VictoryCondition Create(TypeCondition type, BallsController ballsController)
        {
            switch(type)
            {
                case TypeCondition.AllColor:
                    return new AllColorVictory(ballsController);

                case TypeCondition.OneColor:
                    return new OneColorVictory(ballsController);

                default:
                    throw new ArgumentException(nameof(type));
            }    
        }
    }
}