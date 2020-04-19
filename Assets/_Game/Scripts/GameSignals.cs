using Utils;

namespace Sequence
{
    public static class GameSignals
    {
        public static readonly TypedEvent<IGameSettingsReceiver> REQUIRE_GAME_SETTINGS_EVENT = new TypedEvent<IGameSettingsReceiver>();
    }
}
