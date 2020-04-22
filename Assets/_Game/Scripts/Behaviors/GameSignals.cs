using Utils;

namespace Sequence
{
    public static class GameSignals
    {
        public static readonly TypedEvent<IGameControllerReceiver> REQUIRE_GAME_CONTROLLER = new TypedEvent<IGameControllerReceiver>();
        public static readonly TypedEvent<object> START_GAME = new TypedEvent<object>();
    }
}