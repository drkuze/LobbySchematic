using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using MapEditorReborn.API.Features.Objects;
using MapEditorReborn.API.Features;
using System.Linq;
using System;
using UnityEngine;


namespace LobbySchematic
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "LobbySchematic";
        public override string Author => "Kuze";
        public override string Prefix => "lobby_schematic";
        public override Version Version => new Version(1, 0, 0);

        private SchematicObject _lobbySchematic;

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers += OnWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStart;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers -= OnWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStart;
            base.OnDisabled();
        }

        private void OnWaitingForPlayers()
        {
            if (!Config.EnableLobby) return;

            _lobbySchematic = ObjectSpawner.SpawnSchematic(Config.SchematicName, Config.LobbyPosition, Quaternion.Euler(Config.LobbyRotation), null, null, true);
            Log.Info($"Lobby Schematic '{Config.SchematicName}' wurde gespawnt.");
        }

        private void OnRoundStart()
        {
            if (_lobbySchematic != null)
            {
                _lobbySchematic.Destroy();
                Log.Info("Lobby Schematic wurde entfernt.");
            }
        }
    }
}
