# C# Utilities
A collection of various utilities.

## Integer
...

## String
...

## Vector
...

## Vector -- Collision & Miscellaneous
The intended use of the functions found in `Vector_Collision` & `Vector_Miscellaneous` is for fast prototyping & testing.
In production, it would be wise to copy the code out of such functions and create tailored functions for your usecase.

For example:
  * Using `PointVsLine()` to test if the mouse is selecting a line.
  * Then, if `PointVsLine() = true`, you use `Project()` to get the nearest point on the line.
  * Those 2 functions contain many of the same operations, repeating that work in production code is silly.

I would rather keep these functions as primal as possible.
As apposed to `return`ing a complex object with various parameters of the collision event (there can be quite a few parameters with 3D collisions).
Parameters, of which, many would go unused in a particular event, but _could_ be used in any given event.
Ugh, just create tailored functions when you are done prototyping. :P
