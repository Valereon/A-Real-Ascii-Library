// make sprites read from files


make scenese save to a file and read from a file
easy collision detection based on how close they are to eachother? would that be more efficent than just looping over every collison possible? # SPATIAL HASHING
making terrain from files
animations from files
prefabs
make a bunch of public events for debug and other stuff
make an audio manager 
wrap all of the dumbass raylib functions so the user never has to touch system.numerics.vector2/3 so i dont have to do a buncha bullshit and just wrap them for ease anyway



//make a custom vector class that has stuff like "drop x" to make a vector two instead of doing the whole
//"new Vector2(vectorVar.x, vectorVar.y)" just "Vector2.dropZ(vectorVar)" and it will return a vector two of vectorVar x and y

make premade UI widgets like buttons and text areas

make required component shit



A real ascii library 


Needed things
- Collisions
- Tile map generation 
- Reading sprites from files
- Reading animations from file
- Particle system
- Prefabs
- Component system
- UI widgets 
- Debug shit
- Wrap audio methods for easy use 
- The ability to take a text file and either turn it into a level or something and be able to interact with everything
- Scene management and files
- Events 





MAYBE 
- A gui editor thats
- Inspector
- Hierarchy
- Scene view ( with simple widgets such as Move, scale, rotate)
- Inspector ( literally unity style ) 
- Project view



# GLYHPS
so pretty much i want each character or glpyh to be its own thing, probably a struct of some kind that is just attached and trasnlated around via the host, and then the host can have materials applied to it and such and have the glyphs react based on materials as well as like being able to explode things and such but they need to be very lightweight structs to hold the actual vectors and translate them alongside probably will be apart of the sprite renderer class that i can expose

# INPUT SYSTEM 
the input system that allows contexts to be pushed like for example 
Jump Action(Key.space, Controller.LeftJoystick, key.userbound) // whatever
and then you can do stuff like  
Input.ispressed(actions.jump)
or 
input.pushContext(context.menu)
and then it uses a new bindings with new names like maybe 
Jump Action(Key.space, Controller.LeftJoystick, key.userbound) // whatever
becomes
Select Action(Key.space, Controller.LeftJoystick, key.userbound) // whatever

a kind of robust UI system that allows for boxes and buttons

# MATERIALS 
easy materials that are as simple as like 
mat.trigger = method or event
mat.gradient = "#$%^&"
mat.max = 100 // this is based on the trigger but there should also be a field for changing color based on a trigger, so this would make something bigger or smaller by glpyhs based on the distance of the player being the furthest he can be 100 units but if i wanted to change the color of something as i moved away thats something else 
mat.min = 0 

and then based on the trigger it will interpolate between the gradient from max to min based on steps im sure theres more to do there

and add a bunch of triggers that are like Dist(gameobject1, gameobject2) or LightFalloff(gameobject) to be like oh take the light i recivie from this source to apply to my material or based on the distance between two game objects without a real bunch of code to write just some simple ones

add a few base gradients as well like 
thick to thin
light to dark
reverse or like a .reverseOrder = true


# fluid sims


# procedrual materials 
i wonder if some stuff would be wayyyy easier in ascii like repeating tiling or generating a ascii rock based on a perlin noise like the texture of the rock, this could be a thing to look into like can i make this brick wall look different every time its generated via a pallate and a noise function and some rules? 


# maybe make a kind of shader language for this engine? it should be pretty simple but im sure you could get into the nitty gritty of per pixel on the actual ascii characters 


could be kind of cool to make some sort of spatial hashing thing thats like minecraft @e or something where i want to send out a message to an enemy in the game to take damage based on a radius but so i could just do Enemy.Broadcast(Damage, 15) and then it would broadcast within 15 units that message to all enemy types



# strucutre
so the plan is for inter component communciaton to be just straight referneces like getcomponent<health>().takedamage(5) based on the hitbox reciving a on trigger enter thing, but then when we need to talk betwene objects so lets say i hit the player as an enemy the data that i need to send to the player of HEY i hit you adn the damage you need to take is via events or a message bus and not direct calls




# make a render queue
# make a gameobject change queue based on changes made"?