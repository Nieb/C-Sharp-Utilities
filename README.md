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
As apposed to returning complex objects with various parameters of the collision event (with 3D collisions, the parameters can get particularly complex).

Parameters, of which, many would not be used in a particular event, but could be used in any given event.
Ugh, just create tailored functions when you are done prototyping. :P
