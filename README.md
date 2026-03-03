# Donkey Kong Level 1 - Git Workflow Exercise

This is a **skeleton codebase** for teaching git workflows with parallel development and merge conflicts. This is NOT a complete game - students will implement TODOs to create meaningful merge conflicts and practice resolving them.

## 🎯 Learning Objectives

- Practice working on parallel feature branches
- Experience real merge conflicts caused by interdependent code
- Learn to resolve conflicts and coordinate with teammates
- Understand the importance of communication in collaborative development

## 📁 Project Structure

All classes are located in `Assets/Scripts/`:

```
Assets/Scripts/
├── ScoreManager.cs          - Manages scoring and multipliers
├── PlayerLives.cs           - Manages player health and respawn
├── GameUI.cs                - Displays score, lives, and game state
├── LevelManager.cs          - Controls level flow and win/lose conditions
├── PlayerController.cs      - Player movement and collision
├── BarrelController.cs      - Individual barrel behavior
├── DonkeyKongController.cs  - DK barrel throwing logic
└── PlatformController.cs    - Platform and ladder mechanics
```

## 🔗 Class Dependencies (Conflict Zones!)

These interdependencies are **intentional** - when students work in parallel, they will need to coordinate on shared interfaces:

```
LevelManager
├── depends on: ScoreManager, PlayerLives, GameUI, DonkeyKongController
└── coordinates: level completion, game over, resets

PlayerController
├── depends on: ScoreManager, PlayerLives
├── interacts with: BarrelController, PlatformController
└── conflict zone: score point values, damage handling

ScoreManager
├── depends on: GameUI
├── called by: PlayerController, LevelManager, BarrelController
└── conflict zone: point values, method signatures

PlayerLives
├── depends on: GameUI, LevelManager
├── called by: PlayerController
└── conflict zone: respawn behavior, invincibility duration

DonkeyKongController
├── depends on: BarrelController (spawns them)
├── controlled by: LevelManager
└── conflict zone: barrel spawn frequency, difficulty ramping

BarrelController
├── depends on: PlayerController (jump detection)
├── called by: DonkeyKongController (spawning)
└── conflict zone: collision detection, speed values

PlatformController
├── interacts with: PlayerController
└── conflict zone: platform types, movement behavior

GameUI
├── called by: ScoreManager, PlayerLives, LevelManager
└── conflict zone: display format, panel management
```

## 👥 Student Assignments (8 Students)

Each student should create a branch and work on ONE class for 20-30 minutes. Students working on related classes will likely create merge conflicts!

### Pair 1: Core Game State
- **Student 1: LevelManager.cs**
  - TODOs: Level timer, goal checking, level complete flow, game over handling
  - Will conflict with: Student 2, 3, 4

- **Student 2: ScoreManager.cs**
  - TODOs: Multiplier reset logic, complete point-adding methods
  - Will conflict with: Student 1, 5, 6

### Pair 2: Player Systems
- **Student 3: PlayerLives.cs**
  - TODOs: Invincibility timer, respawn logic, add life feature
  - Will conflict with: Student 1, 5

- **Student 4: GameUI.cs**
  - TODOs: Multiplier display, game over screen, level complete screen, temporary messages
  - Will conflict with: Student 1, 2, 3

### Pair 3: Player & Enemies
- **Student 5: PlayerController.cs**
  - TODOs: Hammer timer, ladder climbing, damage handling, barrel smashing
  - Will conflict with: Student 2, 3, 6, 8

- **Student 6: BarrelController.cs**
  - TODOs: Jump detection, platform edge behavior, collision handling
  - Will conflict with: Student 2, 5, 7

### Pair 4: Level Elements
- **Student 7: DonkeyKongController.cs**
  - TODOs: Animation triggers, difficulty ramping, reset logic
  - Will conflict with: Student 6

- **Student 8: PlatformController.cs**
  - TODOs: Moving platform logic, breaking platform, conveyor belt force
  - Will conflict with: Student 5

## ✅ TODO Summary by Class

### ScoreManager.cs (Student 2)
- [ ] Implement multiplier reset logic in `Update()`
- [ ] Complete `AddSmashBarrelPoints()` method
- [ ] Complete `AddCollectItemPoints()` method
- [ ] Complete `AddLevelCompletePoints()` method
- [ ] Add multiplier UI updates in `IncreaseMultiplier()` and `ResetMultiplier()`

### PlayerLives.cs (Student 3)
- [ ] Implement invincibility timer countdown in `Update()`
- [ ] Complete `LoseLife()` - call GameOver on LevelManager
- [ ] Implement `Respawn()` method with delay and invincibility
- [ ] Complete `AddLife()` method
- [ ] Add blinking effect trigger in `ActivateInvincibility()`

### GameUI.cs (Student 4)
- [ ] Implement `UpdateMultiplier()` - show/hide based on value
- [ ] Complete `ShowGameOver()` with panel display and pause
- [ ] Complete `ShowLevelComplete()` with panel display
- [ ] Implement `ShowTemporaryMessage()` with fade effect
- [ ] Optional: Implement `UpdateTimer()` for timed levels

### LevelManager.cs (Student 1)
- [ ] Implement level timer countdown in `Update()`
- [ ] Implement goal proximity check in `Update()`
- [ ] Complete `InitializeLevel()` - start DK throwing barrels
- [ ] Complete `LevelComplete()` - add bonus, show UI, load next level
- [ ] Complete `GameOver()` - stop game, show UI
- [ ] Implement `LoadNextLevel()` with error handling

### PlayerController.cs (Student 5)
- [ ] Implement hammer timer countdown in `Update()`
- [ ] Complete `ClimbLadder()` method
- [ ] Complete `SmashBarrel()` - points, destruction, effects
- [ ] Complete `TakeDamage()` - call PlayerLives, play animations
- [ ] Add pickup points in `PickupHammer()`
- [ ] Implement `SetBlinking()` for invincibility visual

### BarrelController.cs (Student 6)
- [ ] Implement jump detection in `Update()` using OverlapCircle
- [ ] Add platform edge detection in `FixedUpdate()` with raycasts
- [ ] Complete `HandlePlatformCollision()` - determine collision type
- [ ] Add destruction effects in `Smash()`
- [ ] Optional: Add debris spawn in `OnDestroy()`

### DonkeyKongController.cs (Student 7)
- [ ] Add animation trigger in `ThrowBarrel()`
- [ ] Implement difficulty ramping in `ThrowBarrel()` - speed and interval
- [ ] Complete `ResetState()` method
- [ ] Hook up barrel destruction tracking with `OnBarrelDestroyed()`

### PlatformController.cs (Student 8)
- [ ] Implement `UpdateMovingPlatform()` - ping-pong movement
- [ ] Add visual feedback in `UpdateBreakingPlatform()` - shake/color
- [ ] Complete `ApplyConveyorForce()` method
- [ ] Implement `BreakPlatform()` - disable, effects, schedule respawn
- [ ] Implement `RespawnPlatform()` - re-enable everything

## 🔥 Expected Merge Conflicts

When students merge their branches, expect conflicts in these areas:

1. **Point Values**: Student 2 (ScoreManager) and Student 5 (PlayerController) might choose different point values for actions
2. **Method Signatures**: If Student 2 changes how points are added, Student 5's calls will conflict
3. **Respawn Flow**: Student 1 (LevelManager) and Student 3 (PlayerLives) need to agree on respawn coordination
4. **UI Updates**: Student 4 (GameUI) changes to display methods will conflict with Students 1, 2, 3 calling them
5. **Barrel Spawning**: Student 6 (BarrelController) and Student 7 (DonkeyKongController) must agree on initialization
6. **Jump Detection**: Student 5 (PlayerController) and Student 6 (BarrelController) need consistent jump detection logic

## 🚀 Workflow Instructions

### Phase 1: Setup (Instructor)
```bash
# Each student clones the repo
git clone <repo-url>
cd assigment-working-pipeline

# Create feature branch
git checkout -b feature/student-name-classname
```

### Phase 2: Development (20-30 min)
- Each student implements their TODOs on their branch
- Students should NOT merge yet - everyone works in parallel
- Encourage students to make design decisions independently

### Phase 3: Integration (The Fun Part!)
```bash
# Student 1 merges first (establish baseline)
git checkout main
git merge feature/student1-levelmanager

# Students 2-8 merge in sequence
git merge feature/student2-scoremanager
# ... resolve conflicts ...
```

### Phase 4: Conflict Resolution
- Students encounter merge conflicts based on dependencies
- Practice resolving conflicts together
- Discuss why conflicts happened and how to communicate better

## 💡 Teaching Tips

1. **Don't tell students about conflicts beforehand** - let them discover dependencies naturally
2. **Encourage different implementations** - e.g., different point values, timing parameters
3. **Have students document their design decisions** in commit messages
4. **Use this as a discussion starter** about API design and team communication
5. **Live coding** conflict resolution as a group is highly educational

## 🎮 This is NOT a Complete Game

This codebase will NOT run without:
- Unity scene setup (platforms, sprites, prefabs)
- Tagged game objects (Player, Barrel, Platform, Ladder, etc.)
- Sprite assets and animations
- Input system configuration

The goal is **learning git workflows**, not building a complete game. The code is educational skeleton code with realistic interdependencies.

## 📚 Additional Resources

- [Unity MonoBehaviour Lifecycle](https://docs.unity3d.com/Manual/ExecutionOrder.html)
- [Git Merge Conflict Resolution](https://git-scm.com/docs/git-merge)
- [Collaborative Git Workflows](https://www.atlassian.com/git/tutorials/comparing-workflows)

---

**Good luck, and may your merges be conflict-free!** (Just kidding, we WANT conflicts here! 😄)
