# Donkey Kong - Git Workflow Exercise

This project is designed to teach **Git** while working in a team. It's not a complete game - it's intentionally designed to create conflicts so you can learn how to resolve them!

## 📁 Project Classes

All classes are in `Assets/Scripts/`:

1. **ScoreManager.cs** - Manages the score
2. **PlayerLives.cs** - Manages player lives
3. **GameUI.cs** - Displays score and lives on screen
4. **LevelManager.cs** - Controls win/lose conditions
5. **PlayerController.cs** - Moves the player
6. **BarrelController.cs** - Moves the barrels
7. **DonkeyKongController.cs** - Spawns barrels
8. **PlatformController.cs** - Moving platforms

## 👥 Who Works on What

Each student works on ONE class for 15-20 minutes.

### Student 1: ScoreManager.cs
**Tasks:**
- [ ] Complete the `AddSmashPoints()` method
- [ ] Complete the `AddBonusPoints()` method


---

### Student 2: PlayerLives.cs
**Tasks:**
- [ ] Add game over check in `LoseLife()`
- [ ] Complete the `AddLife()` method


---

### Student 3: GameUI.cs
**Tasks:**
- [ ] Complete the `UpdateLives()` method
- [ ] Complete the `ShowGameOver()` method


---

### Student 4: LevelManager.cs
**Tasks:**
- [ ] Add victory check in `Update()`
- [ ] Complete the `LevelComplete()` method
- [ ] Add GameUI call in `GameOver()`


---

### Student 5: PlayerController.cs
**Tasks:**
- [ ] Add barrel collision check in `OnCollisionEnter2D()`
- [ ] Complete the `SmashBarrel()` method


---

### Student 6: BarrelController.cs
**Tasks:**
- [ ] Complete movement in `Update()`
- [ ] Add direction reversal for walls in `OnTriggerEnter2D()`
- [ ] Add points when player jumps over barrel in `OnTriggerEnter2D()`


---

### Student 7: DonkeyKongController.cs
**Tasks:**
- [ ] Add timer check in `Update()`
- [ ] Complete the `SpawnBarrel()` method


---

### Student 8: PlatformController.cs
**Tasks:**
- [ ] Complete platform movement in `Update()`


Good luck! 🎮
