# WinAccentHold
**"Teaching Old Windows New Mac Tricks"**
[![Demo](https://archive.org/download/misc-objects-storage/winaccenthold-demo.jpg)](https://archive.org/download/misc-objects-storage/winaccenthold-demo.mp4)

<img width="100" alt="designed-for-microsoft-windows-xp-logo" src="https://github.com/user-attachments/assets/cb97213a-3c8b-4c47-b943-b00a04827f8c" />
<img width="100" height="140" alt="vista-capable-rectangle" src="https://github.com/user-attachments/assets/8273d636-2e46-45d3-8dd7-5089e43cd818" />

**Note: Windows XP requires Service Pack 3 or a later update and the corresponding language packs for the Unicode characters you intend to type/display. This is probably not as necessary on Vista or later.**

WinAccentHold is a press-and-hold utility, inserting accents and special symbols when the corresponding key is held down. If the symbol isn't available, there is an additional `Alt+<key>` map layer containing additional symbols. Once the menu comes up, symbols can be selected with the arrow keys, the number keys (either top-row or numpad keys), or the mouse, with it easily being dismissed with `Escape`. It is written in C# with .NET Framework 4.0 and therefore can run on Windows XP and later. It was built out of frustration of this feature that has never once been implemented by Microsoft; it was added to Mac OS X Lion 10.7, released in 2011, and has been present since in Apple's Mac OS X/macOS.

## System Requirements
- Windows XP or later, if copying the executable manually
- Windows Vista or later, if using the installer, as Inno Setup 6.x dropped Windows XP support

Additionally, if building from source or developing:
- Windows XP or later
- Visual Studio 2010 or later
- Visual C# workload
- .NET Framework 4.0 targeting pack
- 40 GB of disk space or more

If compiling or developing the installer:
- Windows Vista or later
- Inno Setup 6.0 or later

## Installing
If using the installer:
1. Download the installer
2. Run it - select administrative installer if you want it to work on programs running as Administrator

If manually installing:
1. Download the executable
2. Put it in a folder, either in `Program Files` or `Public Desktop` if running as admin
3. Put a shortcut to it in the startup folder. `shell:startup` only works on user programs, so if you want it to run as admin, put it in the system startup folder.
4. Start the program for the first time, in admin mode if you need it to work with programs with that privilege.

Afterwards, you should be able to use it by pressing and holding keys. See the introduction about information on using it.

## Building
1. Clone the repository
2. If using Visual Studio, open up the solution at `WinAccentHold\WinAccentHold.sln` and build, selecting the desired configuration before building (Debug or Release)
3. If building from CLI, change the working directory to the `WinAccentHold` folder within the repository, before running MSBuild (run it with `/?` to display help options, which can guide you in how to select the configuration)

## License
This program is licensed under the 3rd version of the GNU General Public License. For more information, see `license.txt`.
