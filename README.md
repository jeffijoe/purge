# purge

Utility for deleting directories that contain files/subdirectories
with long path names.

## Get it

Download [purge.exe](/dist) from the dist folder.

Or, build it yourself.

## Usage

Pretty simple. It takes one argument; the path to the folder or file you want to delete.
```
purge <path>
```

Path can be absolute, or relative to the current working directory.

## Why?

Because deleting `node_modules` manually is a pain.

## Wishlist

* Explorer Shell integration. Probably not happening because I don't C++.

## Author

Purge written by Jeff Hansen <jeff@jeffijoe.com> - [@jeffijoe](https://twitter.com/Jeffijoe)

Purge uses portions of the [Microsoft .NET Framework Base Class Libraries](https://bcl.codeplex.com/),
in particular classes from the `Microsoft.Experimental.IO` namespace.
