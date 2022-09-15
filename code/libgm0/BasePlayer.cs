/*
 * part of the gm0 (w.i.p name) gamemode
 * library used across the board gamemode & minigames
 * - last updated indev:3
 * - lotuspar, 2022 (github.com/lotuspar)
 */
namespace libgm0;
using Sandbox;

public abstract partial class BasePlayer : AnimatedEntity
{
	[Net]
	public PlayerData Data { get; set; }

	/// <summary>
	/// Initial constructor for Player
	/// </summary>
	public BasePlayer( PlayerData data = null )
	{
		Camera = new ArbCamera();
		Transmit = TransmitType.Always;
		Data = data;
	}

	/// <summary>
	/// Set active client for player
	/// </summary>
	/// <param name="client">New active client</param>
	public void SetClient( Client client )
	{
		if ( Client != null )
		{
			Log.Warning( $"Setting Client == {client} for Player with Client == {Client}. Previous one will be detached." );
			Client.Pawn = null;
		}

		client.Pawn = this;
		Initialize();
	}

	/// <summary>
	/// Player extension initializer
	/// This should only be called when the Player has a Client
	/// </summary>
	public abstract void Initialize();
}