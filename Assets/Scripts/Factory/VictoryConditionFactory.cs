using Scripts.Balls;
using Scripts.Interfaces;
using Scripts.VictoryCondition;
using Zenject;
using System;

namespace Scripts.Factory
{
    public class VictoryConditionFactory
    {
        private IInstantiator _instantiator;

        public VictoryConditionFactory(IInstantiator instantiator) =>
            _instantiator = instantiator;

        public VictoryCondition.VictoryCondition Create(TypeCondition type, BallsController ballsController, IBallBurster ballBurster)
        {
            switch(type)
            {
                case TypeCondition.AllColor:
                    return new AllBurstVictory(ballsController, ballBurster);

                case TypeCondition.OneColor:
                    return new OneColorVictory(ballsController, ballBurster);

                default:
                    throw new ArgumentException(nameof(type));
            }    
        }
    }
}