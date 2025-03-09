using Exiled.API.Interfaces;
using MapEditorReborn.API.Features;
using System;
using UnityEngine;

namespace LobbySchematic
{
	public class Config : IConfig
	{
		public bool IsEnabled { get; set; } = true;
		public bool Debug { get; set; } = false;
		public bool EnableLobby { get; set; } = true;
		public string SchematicName { get; set; } = "LobbySchematic";
		public Vector3 LobbyPosition { get; set; } = new Vector3(0, 0, 0);
		public Vector3 LobbyRotation { get; set; } = new Vector3(0, 0, 0);
	}
}