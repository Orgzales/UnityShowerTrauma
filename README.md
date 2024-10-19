# UnityShowerTrauma
In Shower Trauma, you play as a young child who is terrified of bathing due to a past trauma. Each day, you must face this fear and survive terrifying encounters in the bathroom, where malevolent forces manifest as monsters, shadows, and other horrors. The evil in the bathroom grows stronger with each passing day, but you must clean yourself or face even worse consequences.

- Survival Mechanics: Each shower or bath is a roguelike level where you must avoid or combat manifestations of your trauma, using limited resources like soap, water, or light to fend off the horrors.
- Psychological Horror: The game focuses on the mental strain of a abused child. As the trauma intensifies, hallucinations blur the line between what is real and imagined.
- Randomized Encounters: Every time you enter the shower, the layout, enemies, and challenges are different, keeping the you on edge.
- Progressive Fear: Over time, the child’s trauma intensifies, and the dangers become more severe, with deeper mysteries to unravel about the origin of their fear.

## Plans To Do

# Step 1: 
 - 🗸 Organize project
 - 🗸 Create Default FPS Controller 
 - 🗸 Create default scene for template
	- 🗸 Make layout for bathroom
	- 🗸  Make doors, vents, walls, and roof
	- 🗸  Create blocks for testing now
# Step 2:
- Create Event manager Script
	- 🗸 Dirty and Instanity bar
		- 🗸 When in shower the dirty bar decreases 
		- 🗸 When in bathroom Instanity bar rises, Only when the shower started
		- 🗸 When out of shower, dirty increases 
	- 🗸 Washing face decreases the Dirty bar rapidly but increases the chance for somethine to happen 
		- 🗸 Make invisble colliders:
			- 🗸 Enter shower area 
			- 🗸 Washing face to press Each
			- 🗸 Turning the shower on/off
	- 🗸 Debug everything for logs 
# Step 3:
- Make Interatiable system
	- 🗸 Make a hud with dot in middle for now
	- 🗸 Whenever player looks at interactable object, display hud text and outline
	- 🗸 Each object will have a script object 
		- 🗸 When pressing shower, should wash face for step 4
		- 🗸 When looking at shower, should turn on/off 
			- 🗸 This will start the cleaning count down 
	
# Step 4:
- 🗸 Create Script for Blink mechanic
	- 🗸 Make object overlay for pressing "E"
	- 🗸 Player screen should go black for a minute 
	- 🗸 Create UI for "Press E to wash Face" 
- 🗸 Washing face should decrease dirty level
	- 🗸 Only able to do it if the shower is on
	- 🗸 Decrese by 20 for now 
- When washing face, random events have a chance of happening
	- Based off of insane level
	- Instance Events (low)
		- Creppy jumpscares
		- Hidden monsters that run when looked at
		- Sound events 
	- Interactable Events (Medium)
		- Monsters that need to hid from
		- Need to mash a button to not die
		- Turning shower off/On to survive
	- Level Changing Events (High)
		- Moving into a different area through closets 
		- Getting transfer to a whole new area for a events
		- Monsters that need to be constantly monitored 

# Step 5:
- Create anitmations + Interactable for objects:
	- 4 Doors (Closets, back door, side door) (Opening/Closing) 
	- Sink cabnets (Opening/Closing) 
	- Shower Head (make it shower)
		- Shower controls (hot & Cold)
	- toilet (to flush)
	- Sink Faucet (on/off)
	- Light Switch (on/off)