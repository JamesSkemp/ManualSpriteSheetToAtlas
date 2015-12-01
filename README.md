# Manual Sprite Sheet to Atlas
Tool to manually create an atlas file from a sprite sheet.

This may be beneficial if you have a sprite sheet but it did not include an atlas file (JSON format).

## Current Features
Currently this application can generate a JSON atlas for use by [Phaser](http://phaser.io/). Support for [libGDX](https://libgdx.badlogicgames.com/) may be coming in the future.

## Running
To run this application either:

1. Download version 1.0 from https://jamesrskemp.com/applications/ManualSpriteSheetToAtlas-1.0.zip . Unzip to where ever you would like and run ManualSpriteSheetToAtlas.exe
2. Download and build a copy of the source (either the v1.0 tag or the current code). [Microsoft Visual Studio Community 2015](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx) can be used.

Sprites are defined by dragging your cursor around the loaded image. Left-click to start defining an area, and release to finish. If you've started drawing and wish to cancel, right-click and then release the left mouse button.

Currently names of the sprites are generated automatically (see Next Steps below). If you'd like to customize the prefix used update the value of `DefaultNamingPrefix` in ManualSpriteSheetToAtlas.exe.config.

## Next Steps for Version 1.1
1. Allow naming of rectangular sections.

## Contributing
Feel free to submit bug or feature requests.
