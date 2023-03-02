# PiThreads
A simple console application that approximates pi by using the ratio of the area of a square to the area of a circle, or rather, the number of darts that land on a circular dartboard.

## How
We simplified this by only considering one quarter of the square. It starts by using a random number generator to generate points on a square grid, then counting the number of points that are within a circle inscribed into the square. If we let n = the number of points within the circle and t = the number of points tested, we can use the formula 4*(n/t) to calculate pi. This works best if the points we are testing are fairly spread out.

## Features
PiDarts utilizes threading to speed up the calculation and displays the result to the user. The user can enter the number of threads to use and the number of points (darts) to use for the calculation. The time taken to complete the calculation is also calculated and displayed to the user.