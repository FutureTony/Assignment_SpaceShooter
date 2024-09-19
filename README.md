# Assignment_SpaceShooter
 In this assignment I have used the DOTS System in unity in order to maximize the performance of the game.
 Some of the usecases shown are converting gameobjects to enitites, by incorporating entities I also used multiThreading.
 making the cpu run on multiple threads at once maximising performance. 
 then by deviding the scripts into groups on when they are loaded can ensure only the things you wanna load are structured well.
 & it might also make it easier to keep the product modular.
 Another thing Are Unity entities Jobs which are made to run multiple code bits simutaniously.
 these are some of the functions used in the code to minimize the bloating of the garbage collector & maximising the performance of the game.

 Some possible future additions for the game.

 Despawning if done correctly  would benefit performance as this project currently by infinetly spawning unitys would result in performance beeing tanked.
 this could be done by calculation when the bullet would hit the enemy either by collisions or by calculating the enemy distance & the distance of the bullet & when the offset is small enough delete both.

 & by having the screen size set like the game currently is you could delete the bullets as the pass the borders of the set screen size.
