# 🎮 تعليمات إعداد لعبة Critter Quest
## Setup Instructions for Critter Quest Game

---

## ⚡ البدء السريع | Quick Start

### الخطوة 1: استنساخ المشروع | Step 1: Clone Project
```bash
git clone https://github.com/ela397829-oss/unity-critter-quest-game.git
```

### الخطوة 2: فتح في Unity | Step 2: Open in Unity
1. افتح Unity Hub
2. انقر على "Open Project"
3. اختر المجلد المستنسخ
4. انتظر تحميل المشروع

---

## 📋 الخطوات التفصيلية | Detailed Setup Steps

### الخطوة 3: إنشاء البنية الأساسية | Create Folder Structure

في مجلد `Assets`، أنشئ هذه المجلدات:

```
Assets/
├── Scripts/
│   ├── Player/
│   ├── Game/
│   ├── UI/
│   ├── Collectibles/
│   ├── Hazards/
│   └── Audio/
├── Prefabs/
├── Scenes/
├── Sprites/
├── Audio/
└── Resources/
```

### الخطوة 4: استيراد TextMeshPro | Import TextMeshPro

1. اذهب إلى **Window > TextMeshPro > Import TMP Essential Resources**
2. انقر **Import**
3. انتظر انتهاء الاستيراد

### الخطوة 5: إضافة Tags | Add Tags

1. اذهب إلى **Edit > Project Settings > Tags and Layers**
2. اضغط على **+** تحت "Tags"
3. أضف هذه Tags:
   - `Player`
   - `Collectible`
   - `Hazard`

---

## 🎬 إنشاء المشاهد | Creating Scenes

### المشهد الأول: القائمة الرئيسية | Main Menu Scene

#### الخطوة 1: إنشاء المشهد
1. **File > New Scene**
2. احفظه باسم `MainMenu.unity` في `Assets/Scenes/`

#### الخطوة 2: إضافة عناصر الواجهة
1. **GameObject > UI > Canvas**
2. أضف عنصر **Text - TextMeshPro**:
   - اكتب: "Critter Quest"
   - اجعل الحجم كبير (60+)
   - رتب في الأعلى

3. أضف **Button - TextMeshPro** باسم "StartButton":
   - النص: "Start Game"
   - لون أخضر (#00AA00)

4. أضف **Button - TextMeshPro** باسم "QuitButton":
   - النص: "Quit"
   - لون أحمر (#AA0000)

#### الخطوة 3: إضافة Controller
1. انقر بزر الماوس الأيمن على Canvas > **Create Empty**
2. سمه "MenuController"
3. أضف سكريبت **MainMenuController.cs**
4. اسحب StartButton و QuitButton إلى الحقول المقابلة

---

### المشهد الثاني: Level 1 (السهل)

#### الخطوة 1: إنشاء خريطة اللعبة

1. **File > New Scene** وأنشئ مشهد جديد
2. احفظه باسم `Level1.unity`
3. **GameObject > 2D Object > Sprites > Square**
4. سمه "Background"
5. في Inspector:
   - Scale: (20, 20, 1)
   - Color: ألون أخضر فاتح (#90EE90)

#### الخطوة 2: إضافة اللاعب

1. **GameObject > 2D Object > Sprites > Circle**
2. سمه "Player"
3. أضف Components:
   - **Rigidbody2D**:
     - Body Type: Dynamic
     - Gravity Scale: 0
     - Constraints: Freeze Rotation Z
   - **CircleCollider2D**:
     - Is Trigger: FALSE
   - Script: **PlayerController.cs**
4. أضف Tag "Player"
5. ضع الموقع عند (0, 0, 0)
6. **عمل Prefab**: اسحب Player إلى `Assets/Prefabs/Player.prefab`

#### الخطوة 3: إضافة الأشياء المجمعة | Collectibles

كرر هذا 5 مرات:
1. **GameObject > 2D Object > Sprites > Circle**
2. سمه "Collectible"
3. Scale: (0.5, 0.5, 1)
4. Color: أصفر (#FFFF00)
5. أضف Components:
   - **CircleCollider2D**: Is Trigger = TRUE
   - Script: **Collectible.cs**
6. أضف Tag "Collectible"
7. ضع في مواقع مختلفة حول الخريطة
8. **عمل Prefab**: `Assets/Prefabs/Collectible.prefab`

#### الخطوة 4: إضافة المخاطر | Hazards

للمستوى الأول: أضف 2 مخاطر

1. **GameObject > 2D Object > Sprites > Square**
2. سمه "Hazard"
3. Scale: (0.7, 0.7, 1)
4. Color: أحمر (#FF0000)
5. أضف Components:
   - **BoxCollider2D**: Is Trigger = TRUE
   - **Rigidbody2D**: Body Type = Kinematic
   - Script: **Hazard.cs**
6. أضف Tag "Hazard"
7. ضع في مواقع مختلفة
8. **عمل Prefab**: `Assets/Prefabs/Hazard.prefab`

#### الخطوة 5: إضافة الجدران | Walls

1. أنشئ GameObject فارغ اسمه "Walls"
2. أضف 4 Squares كأبناء (أعلى، أسفل، يمين، يسار)
3. ضع عند حدود اللعبة
4. أضف **BoxCollider2D** + **Rigidbody2D** (Static) لكل واحد

#### الخطوة 6: إضافة واجهة المستخدم | UI Canvas

1. **GameObject > UI > Canvas**
2. أضف **Text - TextMeshPro** للنقاط:
   - اسم: "ScoreText"
   - النص: "Score: 0"
   - موقع أعلى يسار

3. أضف **Text - TextMeshPro** للأرواح:
   - اسم: "LivesText"
   - النص: "Lives: 3"
   - موقع أعلى وسط

4. أضف **Text - TextMeshPro** للمؤقت:
   - اسم: "TimerText"
   - النص: "Time: 90s"
   - موقع أعلى يمين

#### الخطوة 7: إضافة شاشة Game Over

1. انقر بزر الماوس الأيمن على Canvas > **UI > Panel**
2. اسمه "GameOverPanel"
3. Color: أسود شفاف (0,0,0,128)
4. أضف ابن **Text - TextMeshPro**: "GAME OVER"
5. أضف ابن **Button**: "Restart"
6. أضف ابن **Button**: "Menu"

#### الخطوة 8: إضافة شاشة Win

1. انقر بزر الماوس الأيمن على Canvas > **UI > Panel**
2. اسمه "WinPanel"
3. أضف ابن **Text - TextMeshPro**: "LEVEL COMPLETE!"
4. أضف ابن **Button**: "Next Level"

#### الخطوة 9: إضافة Managers

أنشئ 4 GameObjects فارغة وأضف Scripts:

1. **"GameManager"** + Script: **GameManager.cs**
   - Max Lives: 3
   - Level Time Limit: 90

2. **"ScoreSystem"** + Script: **ScoreSystem.cs**

3. **"LevelManager"** + Script: **LevelManager.cs**
   - Level Number: 1

4. **"UIManager"** + Script: **UIManager.cs**
   - اسحب كل عنصر UI إلى الحقول المقابلة

#### الخطوة 10: إضافة AudioManager

1. أنشئ GameObject فارغ: "AudioManager"
2. أضف Script: **AudioManager.cs**
3. لا تضيف أصوات الآن (اختياري)

---

## 📊 إنشاء Level 2 و Level 3

### Level 2 (متوسط):
1. انقر بزر الماوس الأيمن على Level1.unity > **Duplicate**
2. أعد تسميته إلى `Level2.unity`
3. غير في LevelManager:
   - Level Number: 2
   - Items To Collect: 8
   - Time Limit: 75
4. أضف 2 مخاطر إضافية (الإجمالي: 4)
5. أضف 3 أشياء مجمعة إضافية (الإجمالي: 8)

### Level 3 (صعب):
1. نسخ Level2 واسمه `Level3.unity`
2. غير في LevelManager:
   - Level Number: 3
   - Items To Collect: 10
   - Time Limit: 60
3. أضف 2 مخاطر إضافية (الإجمالي: 6)
4. أضف 2 شيء مجمع إضافي (الإجمالي: 10)

---

## 🔧 تكوين Build Settings

1. **File > Build Settings**
2. اسحب المشاهد بهذا الترتيب:
   - 0: MainMenu
   - 1: Level1
   - 2: Level2
   - 3: Level3

---

## ✅ اختبار اللعبة

1. افتح MainMenu.unity
2. اضغط **Play** في الأعلى
3. اختبر التنقل بين المستويات
4. تأكد من أن كل الأزرار تعمل

---

## 🎨 إضافة رسومات وأصوات (اختياري)

### الرسومات:
1. استخدم: Aseprite أو Piskel (مجاني أونلاين)
2. أنشئ صور 16x16 أو 32x32
3. ضعها في `Assets/Sprites/`

### الأصوات:
1. حمل من:
   - Freesound.org
   - Zapsplat.com
   - OpenGameArt.org
2. ضعها في `Assets/Audio/`
3. أضفها في AudioManager

---

## 🚀 نصائح للتطوير

1. **إضافة power-ups**: اصنع سكريبت جديد يمتد من Collectible
2. **إضافة أعداء ذكيين**: استخدم Pathfinding في Hazard
3. **إضافة رسوم متحركة**: استخدم Animator component
4. **إضافة أصوات**: اسحب ملفات الصوت إلى AudioManager
5. **تحسين الرسومات**: استخدم أدوات تصميم احترافية

---

## ❓ استكشاف الأخطاء

### الزر لا يعمل:
- تحقق من أن EventSystem موجود في Canvas
- تأكد من أن GraphicRaycaster موجود في Canvas

### اللاعب لا يتحرك:
- تحقق من Rigidbody2D settings
- تأكد من أن Script متصل بشكل صحيح

### الأشياء لا تجمع:
- تحقق من Is Trigger في Collectible
- تأكد من أن Tags صحيحة

---

**تم! المشروع جاهز للعمل والتطوير! 🎉**
