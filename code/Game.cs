using Sandbox;
using System;
using System.Linq;

/// <summary>
/// This is the heart of the gamemode. It's responsible
/// for creating the player and stuff.
/// </summary>
[Library( "ascension", Title = "Ascension" )]
partial class DeathmatchGame : Game
{
	DeathmatchHud DmHUD;
	public DeathmatchGame()
	{
		//
		// Create the HUD entity. This is always broadcast to all clients
		// and will create the UI panels clientside. It's accessible 
		// globally via Hud.Current, so we don't need to store it.
		//
		if ( IsServer )
		{
			DmHUD = new DeathmatchHud();
		}
	}

	[Event.Hotload]
	public void UpdateHUD()
	{
		if( !IsServer ) { return; }
		DmHUD.Delete();
		DmHUD = new DeathmatchHud();
	}	

	public override void PostLevelLoaded()
	{
		base.PostLevelLoaded();

		ItemRespawn.Init();
	}

	public override void ClientJoined( Client cl )
	{
		base.ClientJoined( cl );

		var player = new DeathmatchPlayer();
		player.Respawn();

		cl.Pawn = player;
	}
}
