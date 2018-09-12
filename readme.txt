
--| DS Gadget 2.3
--| https://github.com/JKAnderson/DS-Gadget

A multi-purpose testing tool for Dark Souls 1. Compatible with both the Steam and debug versions.
Requires .NET 4.6.2: https://www.microsoft.com/net/download/thank-you/net462
and VC Redist 2012 x86: https://my.visualstudio.com/Downloads?pid=1452
You probably already have both.


--| Credits

Fasm.NET by Jämes Ménétrey
https://github.com/ZenLulz/Fasm.NET

LowLevelHooking by Joseph N. Musser II
https://github.com/jnm2/LowLevelHooking

Octokit by GitHub
https://github.com/octokit/octokit.net

Semver by Max Hauser
https://github.com/maxhauser/semver


--| Special Thanks

Wulf2k, for writing Gizmo and memlocs.ods, without which I would be nothing.

AndrovT, for figuring out how the heck event flags work.

Meowmaritus, for MeowDSIO, which was used to build the item lists.

Pav, for spoonfeeding me so many function pointers.

And all of the other wonderful people in the SpeedSouls discord.


--| Changelog

2.3
	Add create item hotkey
	Search for game by window title, not filename
	Allow stamina editing
	Fix gestures button
	Fix filters

2.2
	Added a button to warp to last bonfire (like a bone, but a button)
	Options will only be reapplied when they're not in the default state (so if you leave them off, they won't conflict with Debug)
	Item spawner improvements
		Spawned items now go straight into your inventory
		You can spawn upgraded pyromancy flames
		You can no longer infuse shields and crossbows with infusions they can't be infused with
		Removed some items that didn't actually exist

2.1
	Added a button to unlock all gestures to Misc tab
	Added a very awkwardly-placed button to reset your hair slot to Internals tab, because flexing permanently hecks it up
	Added stored quantity (for quantity storage ^:) to Internals tab
	Fixed (probably) problems with aiming bows while No Death was on
	Fixed some misconfigured items

2.0
	Gadget now supports the debug version
	Fixed window seemingly disappearing forever sometimes
	Editing your stats will now update health and stamina properly
	New tab: Internals, with readouts for some random technical things you don't care about
	Added basic event flag reading and writing to the Misc tab

1.6
	Added new hotkeys: Quit to Menu, Move Up, Move Down, Toggle No Death
	Option to store HP with position now includes stamina and death cam state
	Said option is now in the Players tab where it should have been anyways
	Closing the app should no longer require quitting and loading to completely clear modifications
	Fix no death and speed being overwritten in some cases (heck off Manus)
	Fix crash if not connected to internet

1.5
	Camera state is now stored along with position
	Fixed body type being overwritten

1.4
	HP can now be edited
	Added option to store and restore HP along with position (ur welcome Milt :V)
	Fixed missing bonfire ID for Seath's prison (again)

1.3
	Hotkeys can be globally enabled or disabled
	Hotkeys can be passed to the game as well or not
	Hotkeys can be unbound with escape
	Cheats have tooltips now
	Fixed filter turning on when you close the app

1.2
	Permanent changes are now cleaned up on app exit; quit out to clear the rest
	App indicates if there's an update available
	Window position is saved
	Settings actually work now
	Ambiguous items like Firekeeper Souls are no longer ambiguous

1.1
	Fixed maxing your stats against your will

1.0
	Reorganized and expanded cheats
	Added phantom and team type
	Added missing Painted World respawn
