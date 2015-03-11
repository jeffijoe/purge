# purge

Utility for deleting directories that contain files/subdirectories
with long path names.

## Get it

Download purge.exe from the dist folder.

## Usage

Pretty simple. It takes one argument; the folder path.

```
purge <folder>
```

Or, build it yourself.

## Why?

Because deleting `node_modules` manually is a pain.

## Wishlish

* Explorer Shell integration. Probably not happening because I don't C++.

## Author

Purge written by Jeff Hansen <jeff@jeffijoe.com> - [@jeffijoe](https://twitter.com/Jeffijoe)

Purge uses portions of the [Microsoft .NET Framework Base Class Libraries](https://bcl.codeplex.com/),
in particular classes from the `Microsoft.Experimental.IO` namespace.